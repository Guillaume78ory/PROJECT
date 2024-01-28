using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation around the Y-axis

    // Update is called once per frame
    void Update()
    {
        // Rotate the planet (and its moon) around the Y-axis every frame, scaled by rotationSpeed and time passed since last frame
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}