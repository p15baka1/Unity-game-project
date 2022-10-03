using UnityEngine;
using UnityEngine.UI;

public class ArrowTextManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Text arrowDisplay;

    private void Start()
    {
        UpdateArrowCount();
    }

    private void Update()
    {
        UpdateArrowCount();
    }


    public void UpdateArrowCount()
    {
        arrowDisplay.text = playerInventory.currentArrows.ToString("00");
    }

}
