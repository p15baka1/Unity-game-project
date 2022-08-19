using TMPro;


public class CoinTextManager : PowerUp
{
    void Start()
    {
        powerupSignal.Raise();
    }

    public Inventory playerInventory;
    public TextMeshProUGUI coinDisplay;
    public void UpdateCoinCount()
    {
        coinDisplay.text = playerInventory.coins.ToString("0000");
    }
}
