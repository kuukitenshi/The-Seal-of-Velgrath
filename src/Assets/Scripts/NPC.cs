using UnityEngine;

[RequireComponent(typeof(Interactable))]
public class NPC : MonoBehaviour
{
    [SerializeField]
    private Dialogue _dialogue;

    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
        });
    }
}
