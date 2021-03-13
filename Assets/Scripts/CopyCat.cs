using System;
using UnityEngine;

public class CopyCat : MonoBehaviour, IOnGameRestarted, IOnPlayerJump, IOnPlayerHitGround, IOnPlayerKilled {
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
    public EventManager eventManager;

    void Awake() {
        eventManager = FindObjectOfType<EventManager>();
        Screen.SetResolution(480, 800, true);
        Application.targetFrameRate = fps;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        thisTransform = transform;
        originalPosition = thisTransform.position;
    }
    public void OnPlayerJump() {
        if (IsGamePlaying) {
            return;
        }
        eventManager.NotifyListeners_OnGamePlaying();
        IsGamePlaying = true;
    }

    void Update() {
        Updater.Update();

        if (!IsGameInitialized) {
            if (timer < initializeDelay) {
                timer += Time.deltaTime;
            }
            else {
                eventManager.NotifyListeners_OnGameInitialized();
                IsGameInitialized = true;
            }
        }

#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Alpha1)) {
            FindObjectOfType<ScoreManager>().OnScorePoint(1);
        }
#endif
    }

    public void OnPlayerHitGround() {
        EndGame();
    }

    public void BeginGamePlay() {
        Begin();
    }

    void begin() {
        eventManager.NotifyListeners_OnGameBegin();
        DidGameBegin = true;
    }

    void Begin() {
        if (!DidGameBegin) {
            begin();
        }
    }

    public void RestartGame() {
        eventManager.NotifyListeners_OnGameRestarted();
    }
    public void EndGame() {
        if (IsGameOver) {
            return;
        }
        eventManager.NotifyListeners_OnGameOver();
        IsGameOver = true;
    }

    public void OnGameRestarted() {
        eventManager.NotifyListeners_OnGameRestart();
        IsGameOver = false;
        timer = 0;
        DidGameBegin = false;
        IsGamePlaying = false;
        thisTransform.position = originalPosition;
        thisTransform.rotation = Quaternion.identity;
        GC.Collect();
    }

    public void OnPlayerKilled() {
        EndGame();
    }
}