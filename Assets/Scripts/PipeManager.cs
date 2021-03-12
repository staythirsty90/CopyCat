using UnityEngine;

public class PipeManager : MonoBehaviour {

    [SerializeField]
    private Transform lastPipeTransform = null;

    private static Transform _lastPipeTransform;

    void Awake() {
        _lastPipeTransform = lastPipeTransform;
    }

    public static Transform GetLastPipeTransform() {
        return _lastPipeTransform;
    }
}
