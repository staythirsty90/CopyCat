using UnityEngine;

public class TileOffsetOnUpdate : MonoBehaviour, IOnUpdate, IOnGameOver, IOnGameRestart {
    public Vector2 offset = new Vector2(-1, 0);
    SpriteRenderer spriteRenderer;
    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }
    readonly int ID = Shader.PropertyToID("_Offset");

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnGameRestart();
    }

    public void OnGameRestart() {
        spriteRenderer.sharedMaterial.SetVector(ID, Vector4.zero);
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnGameOver() {
        RemoveThisFromUpdater = true;
    }

    public void OnUpdate() {
        var _offset = spriteRenderer.sharedMaterial.GetVector(ID);
        //if (_offset.x >= 1) {
        //    _offset.x = 0;
        //}
        //else {
        //    _offset += (Vector4)offset * Time.smoothDeltaTime;
        //}
        _offset += (Vector4)offset * Time.smoothDeltaTime;

        spriteRenderer.sharedMaterial.SetVector(ID, _offset);
    }
}
