using UnityEngine;

[RequireComponent(typeof(IJump))]
public class PlayAnimationOnFalling : MonoBehaviour, IOnGameRestart, IOnPlayerJump, IOnFall, IOnGameOver {
    private Animator thisAnimator;
    private readonly int deadHash = Animator.StringToHash("Dead");

    void Awake() {
        thisAnimator = GetComponent<Animator>();
    }

    public void OnPlayerJump() {
        thisAnimator.SetBool(deadHash, false);
        thisAnimator.speed = 3f;
    }

    public void OnFall() {
        thisAnimator.SetBool(deadHash, true);
    }

    public void OnGameRestart() {
        thisAnimator.SetBool(deadHash, false);
        thisAnimator.speed = 1f;
    }

    public void OnGameOver() {
        thisAnimator.SetBool(deadHash, true);
    }
}
