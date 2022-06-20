using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;
    public GameObject pausePanel;
    public string mainMenu;
    public string resetLevel;
    public FloatValue hearts;
    public FloatValue heartCont;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(resetLevel);
        Time.timeScale = 1f;
        hearts.RuntimeValue = hearts.initialValue;
        heartCont.RuntimeValue = heartCont.initialValue;
    }
}
