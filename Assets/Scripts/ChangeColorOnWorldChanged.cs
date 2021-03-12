using UnityEngine;

public class ChangeColorOnWorldChanged : MonoBehaviour, IOnWorldChanged {

    [SerializeField]
    private Color32[] worldColors = null;

    private SpriteRenderer thisSpriteRenderer;
    private MeshRenderer meshRenderer;
    private Camera thisCamera;

    void Awake() {
        thisCamera = GetComponent<Camera>();
        if (!thisCamera) {
            thisSpriteRenderer = GetComponent<SpriteRenderer>();
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    public void OnWorldChanged(int colorIndex) {
        if (worldColors.Length >= colorIndex) {
            if (thisCamera) {
                thisCamera.backgroundColor = worldColors[colorIndex];
            }
            else {
                if (thisSpriteRenderer) {
                    thisSpriteRenderer.color = worldColors[colorIndex];
                }
                if (meshRenderer) {
                    meshRenderer.sharedMaterial.color = worldColors[colorIndex];
                }
            }
        }
    }
}
