using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public string mainMenuScene;
    GameObject weaponHolder;
    public static bool toMenu = false;

    public GameObject gameOverUI;
    public string gameOverScene;
    void Start()
    {
        isPaused = false;
        weaponHolder = GameObject.Find("WeaponHolder");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else 
            { 
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameObject.Find("CameraBase").GetComponent<NewCameraController>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        weaponHolder.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        GameObject.Find("CameraBase").GetComponent<NewCameraController>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        weaponHolder.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        toMenu = true;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RestartGame()
    {
        Debug.Log("Restarting level");
        Time.timeScale = 1f;
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(gameOverScene);
    }

}
