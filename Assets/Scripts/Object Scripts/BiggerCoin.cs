using UnityEngine;

public class BiggerCoin : PowerUp
{
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        powerupSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.coins += 10;
            powerupSignal.Raise();
            Destroy(this.gameObject);
            FindObjectOfType<AudioManager>().Play("PurpleCoin");
        }
    }
}
