using UnityEngine;

public class Key : PowerUp
{
    public Inventory playerInventory;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.numberOfKeys += 1;
            powerupSignal.Raise();
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
        }
    }
}
