using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    private bool GameIsPaused = false;
    public GameObject panel;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Pressed");
            if (GameIsPaused)
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
        GameIsPaused = false;
        Time.timeScale = 1;
        panel.gameObject.SetActive(false);
    }
    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0;
        panel.gameObject.SetActive(true);
    }
    public void Restart()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
