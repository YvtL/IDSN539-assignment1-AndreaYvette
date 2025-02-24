using UnityEngine; // This line is necessary for MonoBehaviour and Collider

public class DialogueTrigger : MonoBehaviour
{
    public string[] dialogue;
    private bool dialogueStarted = false;

    void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueStarted)
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogueStarted)
        {
            dialogueStarted = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
