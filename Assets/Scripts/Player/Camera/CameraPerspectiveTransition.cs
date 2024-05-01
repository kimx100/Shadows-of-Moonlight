using UnityEngine;

public class CameraPerspectiveTransition : CameraPerspective
{

    void Start()
    {
        if (playerCamera == null)
            playerCamera = GetComponent<Camera>();
    }

    void Update()
    {

    }
}