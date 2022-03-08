using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiver : PowerUp
{

    public Inventory playerInventory;
    public float arrowValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInventory.currentArrows += arrowValue;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
