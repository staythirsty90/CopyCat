﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Compilation;
using UnityEditor;
using System.IO;
using System.Text;

/// <summary>
/// Generates an EventManager class that aggregates and calls interfaces starting with "IOn", excluding some Unity specific ones.
/// </summary>
[ExecuteInEditMode]
public class EventInterfaceGenerator : MonoBehaviour {

    [Tooltip("Generate the file regardless if it is already up to date.")]
    [SerializeField] bool ForceGeneration = false;

    const string GeneratedName      = "EventManager";
    readonly string OutputFilePath  = $"Assets/Scripts/{GeneratedName}.cs";
    
    readonly HashSet<System.Type> GeneratedInterfaces = new HashSet<System.Type>();

    void Update() {
        if(ForceGeneration) {
            GenerateFile();
        }
    }

    void OnEnable() {
        CompilationPipeline.compilationFinished += OnCompilationFinished;
    }

    void OnDisable() {
        CompilationPipeline.compilationFinished -= OnCompilationFinished;
    }

    public void OnCompilationFinished(object obj) {
        GenerateFile();
    }

    /// <summary>
    /// Checks the interfaceName to see if it should be ignored.
    /// </summary>
    /// <param name="interfaceName">The name of the Interface to check.</param>
    /// <returns>Whether or not to ignore this interface.</returns>
    static bool ShouldIgnore(string interfaceName) {
        return  interfaceName == "IOnPaint"         || 
                interfaceName == "IOnInspectorGUI"  || 
                interfaceName == "IOnSceneGUI";
    }

    /// <summary>
    /// Generates the EventManager file.
    /// </summary>
    void GenerateFile() {
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies()) {
            var types = assembly.GetTypes();
            foreach (var type in types) {
                if (type.IsInterface && type.Name.StartsWith("IOn") && !ShouldIgnore(type.Name)) {
                    GeneratedInterfaces.Add(type);
                }
            }
        }

        var sb = new StringBuilder();
        
        sb.AppendLine("// ******* GENERATED FILE. DO NOT MODIFY  *******");
        sb.AppendLine("// ******* SEE EventInterfaceGenerator.cs *******");
        sb.AppendLine();
        sb.AppendLine("using UnityEngine;");
        sb.AppendLine("using System.Collections.Generic;");
        
        sb.AppendLine();

        sb.AppendLine($"public class {GeneratedName} : MonoBehaviour {{");
        sb.AppendLine("\tMonoBehaviour[] monoBehaviours;");

        // List declarations.
        foreach(var interf in GeneratedInterfaces) {
            // TODO: use "new()" short-hand only.
            sb.AppendLine($"\tList<MonoBehaviour> {interf}_list = new List<MonoBehaviour>();");
        }

        sb.AppendLine();

        // Awake method.
        sb.AppendLine("\tvoid Awake() {");
        sb.AppendLine("\t\tmonoBehaviours = FindObjectsOfType<MonoBehaviour>();");
        sb.AppendLine($"\t\tforeach(var mono in monoBehaviours){{");

        foreach(var interf in GeneratedInterfaces) {
            sb.AppendLine($"\t\t\tif(mono is {interf}) {interf}_list.Add(mono);");
        }
        
        sb.AppendLine("\t\t}");
        sb.AppendLine("\t}");
        sb.AppendLine();

        // Notification methods.
        foreach (var interf in GeneratedInterfaces) {
            var methods = interf.GetMethods();
            if (methods == null) {
                Debug.LogError($"couldn't find any methods for {interf.Name}!");
                continue;
            }

            foreach (var method in methods) {
                if(method.IsSpecialName) {
                    continue;
                }
                
                var paramInfos      = method.GetParameters();
                var params_names    = string.Empty;
                var params_str      = string.Empty;

                if (paramInfos.Length > 0) {
                    foreach (var param in paramInfos) {
                        params_str += $"{param.ParameterType} {param.Name},";
                        params_names += $"{param.Name},";
                    }
                    params_str   = params_str.Substring(0, params_str.Length - 1); // remove last comma ","
                    params_names = params_names.Substring(0, params_names.Length - 1); // remove last comma ","
                }
    
                sb.Append($"\tpublic void NotifyListeners_{interf.Name.Substring(1)}");
                sb.AppendLine($"({params_str}) {{");
                sb.AppendLine($"\t\tforeach (var listener in {interf}_list){{");
                sb.AppendLine($"\t\t\t(({interf})listener).{method.Name}({params_names});");
                sb.AppendLine("\t\t}");
                sb.AppendLine("\t}");
                sb.AppendLine();
            }
        }

        sb.AppendLine("}");
        sb.AppendLine("// ******* END OF GENERATED FILE. ******* ");

        var generatedCode = sb.ToString();

        if (File.Exists(OutputFilePath)) {
            if(!ForceGeneration) {
                var existingCode = File.ReadAllText(OutputFilePath);
                if (existingCode == generatedCode) {
                    Debug.Log("EventManager is up to date.");
                    return;
                }
            }
        }
        
        File.WriteAllText(OutputFilePath, generatedCode);
        AssetDatabase.ImportAsset(OutputFilePath);
        Debug.Log("EventManager has been updated.");
        
        ForceGeneration = false;
    }
}

#endif