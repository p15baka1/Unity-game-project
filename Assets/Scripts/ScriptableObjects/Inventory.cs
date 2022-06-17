using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;
    public int coins;
    public float maxArrows = 10;
    public float currentArrows;

    public void OnEnable()
    {
        currentArrows = maxArrows;
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void ReduceArrows(float arrowCost)
    {
        currentArrows -= arrowCost;
    }
    public bool ItemCheck(Item item)
    {
        if (items.Contains(item))
        {
            return true;
        }
        return false;
    }
    public void AddItem(Item itemToAdd)
    {
        //is the item a key?
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        else
        {
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
