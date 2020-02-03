using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] float mouseSensitivityX = 1;
    [SerializeField] float mouseSensitivityY = 1;

    void Update()
    {
        float deltaMouseX = Input.GetAxis("Mouse X");
        float deltaMouseY = Input.GetAxis("Mouse Y");

        Debug.Log($"deltaMouseX:{deltaMouseX} \t deltaMouseY:{deltaMouseY}");

        float rotationY = transform.eulerAngles.y + deltaMouseX; //euler and quaternion are the 2 types of angles
        float rotationX = transform.eulerAngles.x - deltaMouseY;

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0); 
    }
}
