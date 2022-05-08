using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public BoxCollider2D trigger;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //does the player have a key?
                FindObjectOfType<AudioManager>().Play("KeyDoorClosed");
                if (playerInventory.numberOfKeys > 0)
                {
                    //remove a player key
                    playerInventory.numberOfKeys--;
                    //call the open method
                    Open();
                    FindObjectOfType<AudioManager>().Play("KeyDoorOpen");
                }
            }
        }
    }

    public void Open()
    {
        //turn off the door sprite renderer
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turn off the door's box collider
        physicsCollider.enabled = false;
        trigger.enabled = false;
    }

    public void Close()
    {
        //turn on the door sprite renderer
        doorSprite.enabled = true;
        //set open to false
        open = false;
        //turn on the door's box collider
        physicsCollider.enabled = true;
    }
}
