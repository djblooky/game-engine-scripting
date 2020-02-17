using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Serialize private fields to make them show up in the inspector
    // instead of using the "public" access modifier.
    [SerializeField] float mouseSensitivityX = 1;
    [SerializeField] float mouseSensitivityY = 1;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    void Update()
    {
        // Get the amount the cursor has moved this tick of the engine.
        float deltaMouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float deltaMouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        //Debug.Log($"X: {deltaMouseX}\t Y: {deltaMouseY}");

        // Note: the y axis needs to be flipped to have non-inverted controls.
        float rotationY = transform.eulerAngles.y + deltaMouseX;
        float rotationX = transform.eulerAngles.x - deltaMouseY;

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
