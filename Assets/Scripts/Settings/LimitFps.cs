using UnityEngine;

public class LimitFps : MonoBehaviour
{
    void Start() => Application.targetFrameRate = Screen.currentResolution.refreshRate;
}
