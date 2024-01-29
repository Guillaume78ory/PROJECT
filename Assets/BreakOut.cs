using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.A))
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