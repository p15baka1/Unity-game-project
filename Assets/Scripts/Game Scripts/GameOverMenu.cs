using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public FloatValue hearts;
    public FloatValue heartContainer;
    public Inventory playerInventory;
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RetryLevel1()
    {
        SceneManager.LoadScene("Level 1");
        hearts.RuntimeValue = 6;
        heartContainer.RuntimeValue = 3;
    }

    public void RetryLevel2()
    {
        SceneManager.LoadScene("Level 2");
        hearts.RuntimeValue = 8;
        heartContainer.RuntimeValue = 4;
        playerInventory.currentArrows = playerInventory.maxArrows;
    }

    public void RetryBossLevel()
    {
        SceneManager.LoadScene("Level Bossfight");
        hearts.RuntimeValue = 10;
        heartContainer.RuntimeValue = 5;
        playerInventory.currentArrows = playerInventory.maxArrows;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
