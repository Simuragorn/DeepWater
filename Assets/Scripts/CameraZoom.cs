using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float maxZoomMultiplier = 10;
    [SerializeField] private float minZoomMultiplier = 1;
    [SerializeField] private float speed = 100;
    [SerializeField] Camera camera;


    private float originalCameraSize;
    private float maxCameraSize;

    private void Start()
    {
        originalCameraSize = camera.orthographicSize;
        maxCameraSize = originalCameraSize * maxZoomMultiplier;
    }
    void Update()
    {
        HandleZoom();
    }

    void HandleZoom()
    {
        float distance = -Input.mouseScrollDelta.y * speed * Time.deltaTime;
        float size = Mathf.Min(distance + camera.orthographicSize, maxCameraSize);
        size = Mathf.Max(size, originalCameraSize / minZoomMultiplier);
        camera.orthographicSize = size;
    }
}
