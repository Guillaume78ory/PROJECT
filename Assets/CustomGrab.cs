/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;
    Vector3 lastPosition;
    Quaternion lastRotation;
    public bool doubleRotation = false;

    private void Start()
    {
        action.action.Enable();
        foreach(CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        grabbing = action.action.IsPressed();
        Vector3 deltaPosition = transform.position - lastPosition;
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);

        if (grabbing)
        {
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                grabbedObject.position += deltaPosition;
                if(doubleRotation)
                    grabbedObject.rotation *= transform.rotation;
                else
                    grabbedObject.rotation= deltaRotation* grabbedObject.rotation;
            }
        }
        else if (grabbedObject)
            grabbedObject = null;

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        if(t && t.tag.ToLower()=="grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if( t && t.tag.ToLower()=="grabbable")
            nearObjects.Remove(t);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomGrab : MonoBehaviour
{
    public CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    private bool grabbing = false;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    public bool doubleRotation = false; 

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        grabbing = action.action.IsPressed();

        Vector3 deltaPosition = transform.position - lastPosition;
        Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(lastRotation);

        if (grabbing)
        {
            if (!grabbedObject)
            {
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;
            }

            if (grabbedObject)
            {
                ApplyCombinedManipulation(deltaPosition, deltaRotation);
            }
        }
        else if (grabbedObject)
        {
            grabbedObject = null;
        }

        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    private void ApplyCombinedManipulation(Vector3 deltaPosition, Quaternion deltaRotation)
    {
        if (otherHand != null && otherHand.grabbing && otherHand.grabbedObject == grabbedObject)
        {
            Vector3 combinedDeltaPosition = deltaPosition + (otherHand.transform.position - otherHand.lastPosition);

            Quaternion combinedDeltaRotation = deltaRotation * Quaternion.Inverse(otherHand.lastRotation) * otherHand.transform.rotation;

            if (doubleRotation)
            {
                combinedDeltaRotation *= Quaternion.Slerp(Quaternion.identity, combinedDeltaRotation, 2.0f - 1.0f); // Double the rotation magnitude
            }

            grabbedObject.position += combinedDeltaPosition;
            grabbedObject.rotation = combinedDeltaRotation * grabbedObject.rotation;
        }
        else
        {
            if (doubleRotation)
            {
                deltaRotation *= Quaternion.Slerp(Quaternion.identity, deltaRotation, 2.0f - 1.0f); // Double the rotation magnitude
            }

            grabbedObject.position += deltaPosition;
            grabbedObject.rotation = deltaRotation * grabbedObject.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.transform;
        if(t && t.CompareTag("Grabbable"))
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if(t && t.CompareTag("Grabbable"))
            nearObjects.Remove(t);
    }
}




