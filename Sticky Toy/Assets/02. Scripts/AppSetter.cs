using UnityEngine;

public class AppSetter : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
