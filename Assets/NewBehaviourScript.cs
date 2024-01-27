using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light light; 
    private Color originalColor; 
    void Start()
    {light = GetComponent<Light>();
         originalColor = light.color;
    }

    
    void Update()
    {if (Input.GetKeyDown(KeyCode.Tab))
        {light.color = Color.green;
        }

        
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {light.color = originalColor;
        }
    }
}