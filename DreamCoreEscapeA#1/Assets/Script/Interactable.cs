using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject interactionHint;
    public GameObject interactiveUI;

    void Start()
    {
        interactionHint.SetActive(false);
        interactiveUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionHint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionHint.SetActive(false);
            interactiveUI.SetActive(false);
        }
    }

    void Update()
    {
        if (interactionHint.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            interactiveUI.SetActive(!interactiveUI.activeSelf);
        }
    }
}
