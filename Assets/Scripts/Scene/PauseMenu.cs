using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject crossHair;
    void Start()
    {
        Time.timeScale = 1.0f;

        if (pauseMenu.activeSelf)
            pauseMenu.SetActive(false);

        if (pauseMenu == null)
            Debug.LogWarning("Assign pause menu in inspector");

        if (crossHair == null)
            Debug.LogWarning("Assign crosshair in inspector");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();

        if (Input.GetKeyDown(KeyCode.R))
            ReloadScene();

            if (Time.timeScale == 0f)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Time.timeScale == 1f && !pauseMenu.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void TogglePauseMenu()
    {
        if (!pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            crossHair.SetActive(false);
        }
        else if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            crossHair.SetActive(true);
        }
    }
    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
