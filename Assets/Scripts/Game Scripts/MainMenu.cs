using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Inventory playerInventory;
    public Item bow;
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.items.Remove(bow);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
