using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CopyCat : MonoBehaviour, IOnGameRestarted, IOnJump, IOnHitGround {
    public KeyCode beginGameKey = KeyCode.Space;
    public float beginDelay = 0.5f;
    public float initializeDelay = 0.5f;

    public int fps = 30;

    public bool IsGameOver { get; private set; } = false;
    public bool DidGameBegin { get; private set; } = false;

    public bool IsGamePlaying { get; private set; } = false;
    public bool IsGameInitialized { get; private set; } = false;

    private float timer = 0;

    private Transform thisTransform;
    private Vector3 originalPosition;
    public static Updater Updater = new Updater();

    MonoBehaviour[] monoBehaviours;

    void Awake() {
        monoBehaviours = FindObjectsOfType<MonoBehaviour>();
        Screen.SetResolution(480, 800, true);
        Application.targetFrameRate = fps;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        thisTransform = transform;
        originalPosition = thisTransform.position;
    }
    public void OnJump() {
        if (IsGamePlaying) {
            return;
        }
        NotifyListeners(typeof(IOnGamePlaying));
        IsGamePlaying = true;
    }

    void Update() {
        Updater.Update();

        if (!IsGameInitialized) {
            if (timer < initializeDelay) {
                timer += Time.deltaTime;
            }
            else {
                NotifyListeners(typeof(IOnGameInitialized));
                IsGameInitialized = true;
            }
        }

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Alpha1)) {
            FindObjectOfType<ScoreManager>().OnScorePoint(1);
        }
#endif

    }

    public void OnHitGround() {
        EndGame();
    }

    public void BeginGamePlay() {
        Begin();
    }

    void begin() {
        NotifyListeners(typeof(IOnGameBegin));
        DidGameBegin = true;
    }

    void Begin() {
        if (!DidGameBegin) {
            begin();
        }
    }

    public void RestartGame() {
        NotifyListeners(typeof(IOnGameRestarted));
    }
    public void EndGame() {
        if (IsGameOver) {
            return;
        }

        NotifyListeners(typeof(IOnGameOver));
        IsGameOver = true;
    }

    public void OnGameRestarted() {
        NotifyListeners(typeof(IOnGameRestart));
        IsGameOver = false;
        timer = 0;
        DidGameBegin = false;
        IsGamePlaying = false;
        thisTransform.position = originalPosition;
        thisTransform.rotation = Quaternion.identity;
        GC.Collect();
    }

    public void NotifyListeners(Type eventType) {
        if (eventType == typeof(IOnGameRestart)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGameRestart) ((IOnGameRestart)mono).OnGameRestart();
            }
        }
        else if (eventType == typeof(IOnGameBegin)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGameBegin) ((IOnGameBegin)mono).OnGameBegin();
            }
        }
        else if (eventType == typeof(IOnGameInitialized)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGameInitialized) ((IOnGameInitialized)mono).OnGameInitialized();
            }
        }
        else if (eventType == typeof(IOnGameOver)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGameOver)
                    ((IOnGameOver)mono).OnGameOver();
            }
        }
        else if (eventType == typeof(IOnGameRestarted)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGameRestarted) ((IOnGameRestarted)mono).OnGameRestarted();
            }
        }
        else if (eventType == typeof(IOnGamePlaying)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnGamePlaying) ((IOnGamePlaying)mono).OnGamePlaying();
            }
        }
        else if (eventType == typeof(IOnFall)) {
            Debug.Log($"Event: {eventType}");
            foreach (var mono in monoBehaviours) {
                if (mono is IOnFall) ((IOnFall)mono).OnFall();
            }
        }
        else if (eventType == typeof(IOnFalling)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnFalling) ((IOnFalling)mono).OnFalling();
            }
        }
        else if (eventType == typeof(IOnJump)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnJump) ((IOnJump)mono).OnJump();
            }
        }
        else if (eventType == typeof(IOnJumping)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnJumping) ((IOnJumping)mono).OnJumping();
            }
        }
        else if (eventType == typeof(IOnHitGround)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnHitGround)
                    ((IOnHitGround)mono).OnHitGround();
            }
        }
        else {
            Debug.LogWarning($"Couldn't find listener for {eventType}");
        }
    }
    public void NotifyListeners(Type eventType, int param) {
        if (eventType == typeof(IOnWorldChanged)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnWorldChanged)
                    ((IOnWorldChanged)mono).OnWorldChanged(param);
            }
        }
        else if (eventType == typeof(IOnScorePoint)) {
            foreach (var mono in monoBehaviours) {
                if (mono is IOnScorePoint)
                    ((IOnScorePoint)mono).OnScorePoint(param);
            }
        }
        else {
            Debug.LogWarning($"Couldn't find listener for {eventType}");
        }

    }

}