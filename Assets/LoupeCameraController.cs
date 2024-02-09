using UnityEngine;

public class LoupeCameraController : MonoBehaviour
{
    public Camera loupeCamera; // Assignez la caméra de la loupe
    public Transform target; // Assignez l'objet à suivre

    void Update()
    {
        if(loupeCamera != null && target != null)
        {
            loupeCamera.transform.position = target.position + new Vector3(0, 1, -1); // Ajustez selon le besoin
            loupeCamera.transform.LookAt(target.position);
        }
    }
}
