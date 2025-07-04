using System;
using UnityEngine;

public class CopyCat : MonoBehaviour, IOnGameRestarted, IOnPlayerJump, IOnPlayerHitGround, IOnPlayerKilled {
    public KeyCode beginGameKey = KeyCode.Space;
    public float beginDelay = 0.5f;
    public float initializeDelay = 0.5f;
    public int fps = 30;
    public bool IsGameOver { get; private set; }
    public bool DidGameBegin { get; private set; }
    public bool IsGamePlaying { get; private set; }
    public bool IsGameInitialized { get; private set; }
    
    float delayTimer = 0;
    Transform thisTransform;
    Vector3 originalPosition;
    
    public EventManager EventManager { get; private set; }
    public static readonly Updater Updater = new Updater();

    void Awake() {
        Screen.SetResolution(480, 800, true);

        Application.targetFrameRate = fps;
        EventManager                = FindObjectOfType<EventManager>();
        Screen.sleepTimeout         = SleepTimeout.NeverSleep;
        thisTransform               = transform;
        originalPosition            = thisTransform.position;
    }

    public void OnPlayerJump() {
        if (IsGamePlaying) {
            return;
        }
        EventManager.NotifyListeners_OnGamePlaying();
        IsGamePlaying = true;
    }

    void Update() {
         // Score Debug helper.
        #if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Alpha1)) {
            FindObjectOfType<ScoreManager>().OnScorePoint(1);
        }
        #endif

        Updater.Update();

        if(IsGameInitialized) {
            return;
        }
        
        if (delayTimer <= initializeDelay) {
            delayTimer += Time.deltaTime;
            return;
        }
        
        EventManager.NotifyListeners_OnGameInitialized();
        IsGameInitialized = true;
    }

    public void OnPlayerHitGround() {
        EndGame();
    }

    public void BeginGamePlay() {
        Begin();
    }

    void begin() {
        EventManager.NotifyListeners_OnGameBegin();
        DidGameBegin = true;
    }

    void Begin() {
        if (!DidGameBegin) {
            begin();
        }
    }

    public void RestartGame() {
        EventManager.NotifyListeners_OnGameRestarted();
    }

    public void EndGame() {
        if (IsGameOver) {
            return;
        }
        EventManager.NotifyListeners_OnGameOver();
        IsGameOver = true;
    }

    public void OnGameRestarted() {
        GC.Collect();
        EventManager.NotifyListeners_OnGameRestart();

        IsGameOver              = false;
        delayTimer                   = 0;
        DidGameBegin            = false;
        IsGamePlaying           = false;
        thisTransform.position  = originalPosition;
        thisTransform.rotation  = Quaternion.identity;
    }

    public void OnPlayerKilled() {
        EndGame();
    }
}