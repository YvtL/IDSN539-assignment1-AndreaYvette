using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject computerUI;
    public GameObject hintCanvas;
    public GameObject PasswordTab;

    // Computer UI
    public Button[] puzzleButtons; // Your buttons
    public Sprite[] allSprites; // Assign all sprites here from the inspector
    public int[][] spriteIndicesPerButton; // Manually define indices for each button
    public int[] currentIndices; // Current indices of images shown

    private bool isPlayerInTrigger = false;

    void Start()
    {
        computerUI.SetActive(false);
        hintCanvas.SetActive(false);
        PasswordTab.SetActive(false);
        currentIndices = new int[puzzleButtons.Length];
        InitializeButtonImages();
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            computerUI.SetActive(true);
            hintCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && computerUI.activeSelf)
        {
            computerUI.SetActive(false);
            PasswordTab.SetActive(false); // Hide the password tab as well
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            hintCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            hintCanvas.SetActive(false);
            computerUI.SetActive(false);
        }
    }

    private void InitializeButtonImages()
    {
        for (int i = 0; i < puzzleButtons.Length; i++)
        {
            int index = i; // Local copy for closure
            puzzleButtons[i].onClick.AddListener(() => CycleImage(index));
            currentIndices[i] = 0; // Initialize index
            puzzleButtons[i].GetComponent<Image>().sprite = allSprites[spriteIndicesPerButton[i][0]]; // Set initial sprite
        }
    }

    private void CycleImage(int buttonIndex)
    {
        currentIndices[buttonIndex] = (currentIndices[buttonIndex] + 1) % spriteIndicesPerButton[buttonIndex].Length;
        puzzleButtons[buttonIndex].GetComponent<Image>().sprite = allSprites[spriteIndicesPerButton[buttonIndex][currentIndices[buttonIndex]]];

        CheckCorrectSequence();
    }

    private void CheckCorrectSequence()
    {
        int[] correctSequence = { 4, 2, 6 }; // Adjust to your needed correct sequence based on your setup

        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (currentIndices[i] != correctSequence[i])
                return; // If any is incorrect, exit without revealing the password
        }

        // If all are correct, reveal the password:
        ShowPasswordTab();
    }

    private void ShowPasswordTab()
    {
        PasswordTab.SetActive(true);
    }
}
