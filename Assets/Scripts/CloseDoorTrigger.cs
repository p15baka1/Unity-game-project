using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    public GameObject door;
    public BoxCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.SetActive(true);
            FindObjectOfType<AudioManager>().Play("CloseDoor");
            trigger.enabled = false;
        }
    }
}
