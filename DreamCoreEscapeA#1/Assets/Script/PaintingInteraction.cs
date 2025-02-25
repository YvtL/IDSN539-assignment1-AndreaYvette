using UnityEngine;
using UnityEngine.UI;

public class PaintingInteraction : MonoBehaviour
{
    public GameObject paintingUI;  // Assign the PaintingCanvas to this in the Inspector
    private bool isPlayerInTrigger = false;

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            paintingUI.SetActive(true);  // Show the painting
        }

        if (Input.GetKeyDown(KeyCode.Escape) && paintingUI.activeSelf)
        {
            paintingUI.SetActive(false);  // Hide the painting
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            // Optionally show some UI hint that player can press 'E'
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            // Optionally hide the UI hint
            paintingUI.SetActive(false);  // Also hide the painting when player leaves the trigger
        }
    }
}
