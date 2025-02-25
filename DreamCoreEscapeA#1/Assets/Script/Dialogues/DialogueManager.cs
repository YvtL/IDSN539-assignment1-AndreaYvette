using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text npcDialogueText;
    public TMP_Text playerDialogueText;
    public Dialogue dialogue;
    private int index = 0;
    public GameObject dialoguePanel; // Assign the panel or the background object that covers the dialogue area

    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Allows the dialogue box to detect mouse clicks
        if (Input.GetMouseButtonDown(0) && dialoguePanel.activeSelf)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        index = 0;
        ShowDialogue(index);
    }

    void DisplayNextSentence()
    {
        if (index < dialogue.npcLines.Length - 1)
        {
            index++;
            ShowDialogue(index);
        }
        else
        {
            // Hide the dialogue box after the last sentence
            dialoguePanel.SetActive(false);
        }
    }

    void ShowDialogue(int lineIndex)
    {
        npcDialogueText.text = dialogue.npcLines[lineIndex];
        playerDialogueText.text = dialogue.playerLines[lineIndex];
    }
}
