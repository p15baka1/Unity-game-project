using UnityEngine;

public class Quiver : PowerUp
{
    public Inventory playerInventory;
    public float arrowValue;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInventory.currentArrows += arrowValue;
            powerupSignal.Raise();
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("Quiver");
        }
    }
}
