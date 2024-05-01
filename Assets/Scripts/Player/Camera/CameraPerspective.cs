using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspective : PlayerCam
{
    bool isFirstPerson;
    bool isThirdPerson;

    bool isFirstPersonPositionSet;
    bool isThirdPersonPositionSet;

    private void Start()
    {
        isFirstPerson = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            TogglePerspective();
        }
        if (Time.timeScale != 0 && isFirstPerson)
            FirstPersonCamera();
        else if (Time.timeScale != 0 && isThirdPerson)
            ThirdPersonCamera();
    }
    void TogglePerspective()
    {
        isFirstPerson = !isFirstPerson;
        isThirdPerson = !isThirdPerson;
    }
    void FirstPersonCamera()
    {
        if (!isFirstPersonPositionSet) // Set the camera to the first person view
        {
            Debug.Log("Changed to first person");
            Vector3 defaultFirstPersonCameraPosition = new Vector3(0f, 0.5f, 0.5f);
            transform.localPosition = defaultFirstPersonCameraPosition;
            isFirstPersonPositionSet = true;
            isThirdPersonPositionSet = false;
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
    void ThirdPersonCamera()
    {
        if (!isThirdPersonPositionSet) // Set the camera to the third person view
        {
            Debug.Log("Changed to third person");
            Vector3 defaultThirdPersonCameraPosition = new Vector3(0f, 1.8f, -5f);
            transform.localPosition = defaultThirdPersonCameraPosition;
            transform.localRotation = Quaternion.Euler(5, 0, 0);
            isThirdPersonPositionSet = true;
            isFirstPersonPositionSet = false;
        }
       
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, 5, 35);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
