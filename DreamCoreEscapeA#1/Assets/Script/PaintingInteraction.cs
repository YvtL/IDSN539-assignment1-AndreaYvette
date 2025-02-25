using UnityEngine;
using UnityEngine.UI; // Or using TMPro if using TextMeshPro

public class PaintingInteraction : MonoBehaviour
{
    public GameObject paintingUI;  // The main painting zoom UI
    public GameObject hintCanvas;  // The hint canvas with "Press E to pick up"
    private bool isPlayerInTrigger = false;

    void Start()
    {
        paintingUI.SetActive(false);  // Ensure the painting UI is also hidden by default
        hintCanvas.SetActive(false);  // Hide the hint canvas on game start
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            paintingUI.SetActive(true);  // Show the painting
            hintCanvas.SetActive(false); // Hide hint when painting is picked up
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
            hintCanvas.SetActive(true);  // Show the hint canvas
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            hintCanvas.SetActive(false);  // Hide the hint canvas
            paintingUI.SetActive(false);  // Also hide the painting when player leaves the trigger
        }
    }
}
