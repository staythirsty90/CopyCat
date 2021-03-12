using UnityEngine;

public class JumpController : MonoBehaviour, 
    IOnGameBegin, IOnGameOver, IOnGameRestart, IOnJumping, IOnFalling, IOnUpdate {
    public float canJumpDelay = 0.5f;
    public float jumpTime = 0.2f;
    public float rotateThreshold = 0.15f;
    public float fallAngle = -90f;
    public float jumpAngle = 90f;
    public float downRotationSpeed = 1f;
    private IJump jumpModule;
    private Transform thisTransform;
    private float currentLerpTime = 0;
    private bool canJump = false;
    private bool didJump = false;
    private float fallRotateTime = 0f;
    private float fallRotatePercentage = 0;
    private float canJumpTimer = 0f;

    float t;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
        jumpModule = GetComponent<IJump>();
    }

    public void OnGameRestart() {
        didJump = false;
        canJump = false;
    }

    public void OnGameOver() {
        canJump = false;
        fallRotatePercentage = 0;
        currentLerpTime = 0;
        RemoveThisFromUpdater = true;
    }

    public void OnGameBegin() {
        CopyCat.Updater.AddToUpdate(this);
    }

    public void Jump() {
        if (!canJump)
            return;

        jumpModule.BeginJump();
        fallRotatePercentage = 0;
        fallRotateTime = 0;
        t = 0;
        currentLerpTime = 0f;
    }
    public void OnFalling() {
        RotateDownwards();
    }

    public void OnJumping() {
        RotateUpwards();
    }

    void RotateUpwards() {
        t = currentLerpTime / jumpTime;
        fallRotateTime = 0;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, jumpAngle));
        thisTransform.localRotation = Quaternion.Lerp(thisTransform.localRotation, rotation, t);
        currentLerpTime += Time.deltaTime;
        if (t >= 1f) {
            currentLerpTime = 0;
            t = 0;
        }
    }

    void RotateDownwards() {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, fallAngle));
        if (fallRotateTime > rotateThreshold) {
            fallRotatePercentage += Time.deltaTime * downRotationSpeed;
            thisTransform.localRotation = Quaternion.Lerp(thisTransform.localRotation, rotation, fallRotatePercentage);
        }
        else {
            fallRotateTime += Time.deltaTime;
        }
    }

    public void OnUpdate() {
        if (!didJump) {
            if (!canJump) {
                canJumpTimer += Time.deltaTime;
                if (canJumpTimer > canJumpDelay) {
                    canJump = true;
                    didJump = true;
                    canJumpTimer = 0f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            Jump();
        }
    }
}
