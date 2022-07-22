#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Compilation;
using System.Reflection;
using UnityEditor;
using System.IO;

[ExecuteInEditMode]
public class EventInterfaceGenerator : MonoBehaviour {
    static HashSet<System.Type> generated_interfaces = new HashSet<System.Type>();
    static int count = 0;
    private void OnEnable() {
        CompilationPipeline.compilationFinished -= CompilationPipeline_compilationFinished;
        CompilationPipeline.compilationFinished += CompilationPipeline_compilationFinished;
    }

    private static bool Ignores(string input) {
        return input == "IOnPaint" || input == "IOnInspectorGUI" || input == "IOnSceneGUI";
    }

    public void Compile() {
        foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies()) {
            var types = assembly.GetTypes();
            foreach (var type in types) {
                if (type.Name.StartsWith("IOn") && !Ignores(type.Name)) {
                    if (type.IsInterface) {
                        generated_interfaces.Add(type);
                        //Debug.Log($"added new interface {type.Name}");
                    }
                }
            }
        }

        if (generated_interfaces.Count == count) {
            Debug.Log("no new interfaces to add");
            return;
        }

        Debug.Log("adding new interfaces.");
        count = generated_interfaces.Count;

        string file_name = "Assets/Scripts/EventManager.cs";
        string body = string.Empty;
        string awake = string.Empty;
        string header = string.Empty;
        header += "// ******* GENERATED FILE. DO NOT MODIFY *******\n//******* SEE EventInterfaceGenerator.cs *******\n";
        header += "using UnityEngine;\n";
        header += "using System.Collections.Generic;\n";

        header += "public class EventManager : MonoBehaviour {\n";
        header += "\tMonoBehaviour[] monoBehaviours;\n";
        awake += "\tvoid Awake() { \n";
        awake += "\t\tmonoBehaviours = FindObjectsOfType<MonoBehaviour>();\n";
        awake += $"\t\tforeach(var mono in monoBehaviours){{\n";


        foreach (var _event in generated_interfaces) {
            MethodInfo[] methods = _event.GetMethods();
            if (methods == null) {
                Debug.LogError($"couldn't find any methods for {_event.Name}!");
                continue;
            }
            body += $"\tpublic void NotifyListeners_{_event.Name.Substring(1)}";
            foreach (var method in methods) {
                if (method.IsSpecialName)
                    continue;
                ParameterInfo[] paramInfos = method.GetParameters();
                string params_names = string.Empty;
                string params_str = string.Empty;
                if (paramInfos.Length > 0) {
                    foreach (var param in paramInfos) {
                        params_str += $"{param.ParameterType} {param.Name},";
                        params_names += $"{param.Name},";
                    }
                    params_str = params_str.Substring(0, params_str.Length - 1); // remove last comma ","
                    params_names = params_names.Substring(0, params_names.Length - 1); // remove last comma ","
                }
                body += $"({params_str}) {{\n";
                body += $"\t\tforeach (var listener in {_event}_list){{\n";
                body += $"\t\t\t(({_event})listener).{method.Name}({params_names});\n";
                body += "\t\t}\n";
                body += "\t}\n";

                header += $"\tList<MonoBehaviour> {_event}_list = new List<MonoBehaviour>();\n";
                awake += $"\t\t\tif(mono is {_event}) {_event}_list.Add(mono);\n";
            }
        }
        body += "}\n";
        awake += "\t\t}\n";
        awake += "\t}\n";

        body += "// ******* END OF GENERATED FILE. ******* ";

        if (File.Exists(file_name)) {
            if (File.ReadAllText(file_name) == header + awake + body) {
                Debug.Log("no new events to add.");
                return;
            }
        }
        
        File.WriteAllText(file_name, header + awake + body);
        AssetDatabase.ImportAsset(file_name);
    }
    public void CompilationPipeline_compilationFinished(object obj) {
        //Debug.Log("****Ello!******");
        Compile();
    }
}

#endif