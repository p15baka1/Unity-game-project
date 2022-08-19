using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject pausePanel;

     void Update()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            TriggerDialogue();
            Destroy(gameObject);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
