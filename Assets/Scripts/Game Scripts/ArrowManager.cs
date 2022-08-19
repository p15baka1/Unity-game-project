using UnityEngine;
using UnityEngine.UI;


public class ArrowManager : MonoBehaviour
{
    public Slider arrowSlider;
    public Inventory playerInventory;

    private void Start()
    {
        arrowSlider.maxValue = playerInventory.maxArrows;
        arrowSlider.value = playerInventory.maxArrows;
        playerInventory.currentArrows = playerInventory.maxArrows;
    }

    public void AddArrows()
    {
        //arrowSlider.value += 1;
        //playerInventory.currentArrows += 1;
        arrowSlider.value = playerInventory.currentArrows;
        if (arrowSlider.value > arrowSlider.maxValue)
        {
            arrowSlider.value = arrowSlider.maxValue;
            playerInventory.currentArrows = playerInventory.maxArrows;
        }
    }

    public void DecreaseArrows()
    {
        //arrowSlider.value -= 1;
        //playerInventory.currentArrows -= 1;
        arrowSlider.value = playerInventory.currentArrows;
        if(arrowSlider.value < 0)
        {
            arrowSlider.value = 0;
            playerInventory.currentArrows = 0;
        }
    }





}
