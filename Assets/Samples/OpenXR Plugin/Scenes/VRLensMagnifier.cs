
/*
using UnityEngine;
using UnityEngine.XR;

public class VRLensMagnifier : MonoBehaviour
{
    public Camera Main Camera; // La caméra principale de la VR
    public Camera Camera; // La caméra qui agira comme une loupe
    public float zoomFactor = 2.0f; // Facteur de zoom de la loupe
    public bool magnifierActive = false; // État de la loupe

    void Start()
    {
        // Assurez-vous que la caméra de loupe est désactivée au démarrage
        magnifierCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Activer/désactiver la loupe
        if (Input.GetKeyDown(KeyCode.M)) // Utiliser 'M' ou un bouton du contrôleur VR pour activer/désactiver
        {
            magnifierActive = !magnifierActive;
            magnifierCamera.gameObject.SetActive(magnifierActive);
        }

        if (magnifierActive)
        {
            // Attacher la caméra de loupe à la position de la tête/casque VR
            magnifierCamera.transform.position = vrCamera.transform.position;
            magnifierCamera.transform.rotation = vrCamera.transform.rotation;

            // Ajuster le zoom
            magnifierCamera.fieldOfView = vrCamera.fieldOfView / zoomFactor;
        }
    }
}
*/
using UnityEngine;
using UnityEngine.XR;

public class VRLensMagnifier : MonoBehaviour
{
    public Camera MainCamera; // La caméra principale de la VR, renommée correctement
    public Camera MagnifierCamera; // La caméra qui agira comme une loupe, renommée pour cohérence
    public float zoomFactor = 2.0f; // Facteur de zoom de la loupe
    public bool magnifierActive = false; // État de la loupe

    void Start()
    {
        // Assurez-vous que la caméra de loupe est désactivée au démarrage
        MagnifierCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Activer/désactiver la loupe
        if (Input.GetKeyDown(KeyCode.Q)) // Utiliser 'M' ou un bouton du contrôleur VR pour activer/désactiver
        {
            magnifierActive = !magnifierActive;
            MagnifierCamera.gameObject.SetActive(magnifierActive);
        }

        if (magnifierActive)
        {
            // Attacher la caméra de loupe à la position de la tête/casque VR
            MagnifierCamera.transform.position = MainCamera.transform.position;
            MagnifierCamera.transform.rotation = MainCamera.transform.rotation;

            // Ajuster le zoom
            MagnifierCamera.fieldOfView = MainCamera.fieldOfView / zoomFactor;
        }
    }
}