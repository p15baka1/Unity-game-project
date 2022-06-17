using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RetryLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void RetryLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void RetryBossLevel()
    {
        SceneManager.LoadScene("Level Bossfight");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
