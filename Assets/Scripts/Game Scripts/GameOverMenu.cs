using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public FloatValue hearts;
    public FloatValue heartContainer;
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
        hearts.RuntimeValue = 8;
        heartContainer.RuntimeValue = 4;
    }

    public void RetryBossLevel()
    {
        SceneManager.LoadScene("Level Bossfight");
        hearts.RuntimeValue = 10;
        heartContainer.RuntimeValue = 5;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
