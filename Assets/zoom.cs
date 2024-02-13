using UnityEngine;

public class AutoZoomCamera : MonoBehaviour
{
    public Camera loupeCamera; 
    public float zoomFactor = 2f; 
    public float zoomSpeed = 0.5f; 
    private float targetFov; 
    private float originalFov; 

    void Start()
    {
        if (loupeCamera != null)
        {
            originalFov = loupeCamera.fieldOfView;
            targetFov = originalFov / zoomFactor; 
        }
        else
        {
            Debug.LogError("Loupe Camera n'est pas assignée dans l'inspecteur.");
        }
    }

    void Update()
    {
        if (loupeCamera.fieldOfView != targetFov)
        {
            loupeCamera.fieldOfView = Mathf.Lerp(loupeCamera.fieldOfView, targetFov, Time.deltaTime * zoomSpeed);
        }
        else
        {
            loupeCamera.fieldOfView = originalFov;
        }
    }
}
