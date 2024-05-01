using System.Collections;
using UnityEditor;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public Camera playerCamera;

    public float sensitivity = 5f;
    public float rotationX = 0f;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (playerCamera == null)
            playerCamera = GetComponent<Camera>();

    }
    void Update()
    {
    }
}
