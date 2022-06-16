using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;
    public SignalSystem raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    public GameObject minimapMarker;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (!isOpen)
            {
                StartCoroutine(OpenChestCo());
            }
        }
    }

    private IEnumerator OpenChestCo()
    {
        //dialog window on
        dialogBox.SetActive(true);
        //dialog text = contents text
        dialogText.text = contents.itemDescription;
        //add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        //raise the signal to the player to animate
        raiseItem.Raise();
        //raise the clue
        clue.Raise();
        //set the chest to opened
        isOpen = true;
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
        yield return new WaitForSeconds(4f);
        ChestAlreadyOpen();
    }
    private void ChestAlreadyOpen()
    {
        playerInRange = false;
        //dialog off
        dialogBox.SetActive(false);
        //raise signal to the player to stop animating
        raiseItem.Raise();
        minimapMarker.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            clue.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            clue.Raise();
            playerInRange = false;
        }
    }
}
