using UnityEngine;

public class ChangeWorldColors : MonoBehaviour, IOnGameRestart {
    public int numberOfWorldColors;
    [Range(0, 100)]
    public int chanceToChangeWorldColors;
    public int startingWorldColor = 0;
    CopyCat copyCat;
    void Awake() {
        copyCat = FindObjectOfType<CopyCat>();
    }

    void Start() {
        ChangeWorldColor(startingWorldColor);
    }

    public void OnGameRestart() {
        int random = Random.Range(0, 100);
        if (random <= chanceToChangeWorldColors) {
            int colorIndex = Random.Range(0, numberOfWorldColors);
            ChangeWorldColor(colorIndex);
        }
    }

    private void ChangeWorldColor(int colorIndex) {
        copyCat.EventManager.NotifyListeners_OnWorldChanged(colorIndex);
    }
}
