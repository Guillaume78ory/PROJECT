using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light light;

    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            // You can insert a new color here. For example, to switch to red:
            light.color = Color.red;

            // If you want to cycle through colors, you could define a list of colors
            // and select the next one each time the Tab key is pressed.
            // For example, you could use an array of colors and a variable to keep track of the current index.
     
        }
    }
}