using System;
using UnityEngine;

public class NewJump : MonoBehaviour, IJump, IOnGameOver, IOnUpdate {
    Transform thisTransform;
    public float jumpSpeed;
    public float fallingSpeed;
    public float CeilingLimit;
    public float maximumFallRate = -5000;
    public float floorLimit;
    float verticalSpeed = 0;
    float previousY;
    Vector3 pos = new Vector3();
    bool startedFalling = false;
    bool startedJump = false;
    CopyCat copyCat;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
        copyCat = FindObjectOfType<CopyCat>();
    }

    public void OnUpdate() {
        Jump();
    }

    public void OnGameOver() {
        verticalSpeed = 0f;
        startedFalling = false;
        startedJump = false;
    }

    public void BeginJump() {
        if (!startedJump) {
            startedJump = true;
            CopyCat.Updater.AddToUpdate(this);
        }
        copyCat.EventManager.NotifyListeners_OnPlayerJump();
        verticalSpeed = jumpSpeed;
        previousY = thisTransform.position.y;
    }

    public void EndJump() {
        RemoveThisFromUpdater = true;
        pos.y = floorLimit;
        thisTransform.position = pos;
        copyCat.EventManager.NotifyListeners_OnPlayerHitGround();
    }

    private void Jump() {
        pos = new Vector3(thisTransform.position.x, verticalSpeed * Time.smoothDeltaTime, thisTransform.position.z);
        if (thisTransform.position.y + pos.y <= floorLimit) {
            EndJump();
            return;
        }
        pos.y += thisTransform.position.y;
        thisTransform.position = pos;
        startedFalling = false;
        if (thisTransform.position.y > CeilingLimit) {
            pos.y = CeilingLimit;
            thisTransform.position = pos;
        }
        if (thisTransform.position.y - previousY <= 0.01f && !startedFalling) {
            copyCat.EventManager.NotifyListeners_OnFall();
            startedFalling = true;
        }
        if (thisTransform.position.y < previousY) {
            copyCat.EventManager.NotifyListeners_OnFalling();
        }
        else {
            copyCat.EventManager.NotifyListeners_OnJumping();
        }
        verticalSpeed -= fallingSpeed * Time.smoothDeltaTime;
        if (verticalSpeed < maximumFallRate) {
            verticalSpeed = maximumFallRate;
        }
        previousY = pos.y;
    }
}
