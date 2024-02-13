using UnityEngine;

public class MagnifyingGlass : MonoBehaviour
{
    public Material magnifyingMaterial;
    public Transform magnifyingCenter;
    public float magnifyAmount = 3.0f;

    void Update()
    {
        if (magnifyingMaterial != null)
        {
            Vector2 newCenter = Camera.main.WorldToViewportPoint(magnifyingCenter.position);
            magnifyingMaterial.SetVector("_MagnifyCenter", new Vector4(newCenter.x, newCenter.y, 0, 0));
            magnifyingMaterial.SetFloat("_MagnifyAmount", magnifyAmount);
        }
    }
}
