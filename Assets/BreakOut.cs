/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;


public class Breakout : MonoBehaviour
{
    Vector3 m_NewPosition;
    Vector3 zero_Position;
    public InputActionReference actionReference; 
    private bool isActionTriggered = false;

    private void Start()
    {
        m_NewPosition = new Vector3(0.0f, 20.0f, -40.0f);
        zero_Position = transform.position;

        actionReference.action.Enable();
        actionReference.action.performed += ctx => isActionTriggered = true;
    }

    private void Update()
    {
        if (isActionTriggered)
        {
            if (transform.position == m_NewPosition)
            {
                transform.position = zero_Position;
            }
            else
            {
                transform.position = m_NewPosition;
            }
            isActionTriggered = false;
        }
    }

    private void OnDisable()
    {
        actionReference.action.Disable();
        actionReference.action.performed -= ctx => isActionTriggered = true;
    }
}

*/


using UnityEngine;
using UnityEngine.UIElements;

public class Breakout : MonoBehaviour
{
    Vector3 m_NewPosition;
    Vector3 Zero_Position;
    public float m_XPosition;

    void Start()
    {
        m_NewPosition = new Vector3(0.0f, 20.0f, -40.0f);
        Zero_Position = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position == m_NewPosition)
            {
                transform.position = Zero_Position;
            }
            else
                transform.position = m_NewPosition;

        }

    }
}
