using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // No magic numbers and no public fields to make something visible in the inspector.
    [SerializeField] private float horizontalMouseSensitivity = 0.75f;
    [SerializeField] private float verticalMouseSensitivity = 0.75f;

    void Update()
    {
        Debug.Log($"Mouse X: {Input.GetAxis("Mouse X")}");
        Debug.Log($"Mouse Y: {Input.GetAxis("Mouse Y")}");

        // Use descriptive variable names to break complex code into easier to follow parts. Many
        // times, that will eliminate the need for comments!
        float deltaMouseHorizontal = Input.GetAxis("Mouse X") * horizontalMouseSensitivity;
        float deltaMouseVertical = Input.GetAxis("Mouse Y") * verticalMouseSensitivity;
        float newCameraRotY = transform.eulerAngles.y + deltaMouseHorizontal;
        float newCameraRotX = transform.eulerAngles.x - deltaMouseVertical;

        transform.eulerAngles = new Vector3(newCameraRotX, newCameraRotY, 0);
    }
}
