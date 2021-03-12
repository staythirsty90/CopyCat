using UnityEngine;

public class GameDigits : MonoBehaviour {
    [SerializeField]
    private Sprite[] gameDigits = new Sprite[10];
    public Sprite[] GameDigit {
        get { return gameDigits; }
    }
}
