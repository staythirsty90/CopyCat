using UnityEngine;

public class CopyCatIdleAnimate : MonoBehaviour, IOnUpdate, IOnGameRestart, IOnGameInitialized, IOnGamePlaying {
    private Transform thisTransform;

    public float time = 1f;
    public float amp = 1f;
    float currentLerpTime = 0;
    float done = 0;
    Vector2 pos, startPos;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
        startPos = thisTransform.position;
        pos = thisTransform.position;
        pos.y += amp;
    }
    public void OnGameRestart() {
        OnGameInitialized();
    }
    void Animate() {
        done = currentLerpTime / time;
        //pos.y += Mathf.Sin(pos.y);
        //thisTransform.position = new Vector2(thisTransform.position.x, Mathfx.Sinerp(pos.y, pos.y +amp, done));
        thisTransform.position = Vector3.Lerp(startPos, pos, done);
        currentLerpTime += Time.deltaTime;
        if (done > 1f) {
            Vector2 temp;
            done = 0;
            currentLerpTime = 0;
            temp = pos;
            pos = startPos;
            startPos = temp;
        }
    }

    public void OnGameInitialized() {
        currentLerpTime = 0;
        done = 0;
        //CopyCat.OnUpdate += Animate;
        CopyCat.Updater.AddToUpdate(this);
        thisTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnGamePlaying() {
        //CopyCat.OnUpdate -= Animate;
        RemoveThisFromUpdater = true;
    }

    public void OnUpdate() {
        Animate();
    }
}
