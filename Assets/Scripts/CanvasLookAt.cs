using UnityEngine;

public class CanvasLookAt : MonoBehaviour
{
    private Camera _main;

    private void Start()
    {
        _main = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(_main.transform.position);
    }
}
