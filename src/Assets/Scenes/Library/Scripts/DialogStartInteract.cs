using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStartInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject _bookInteract;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.TakeBookToLibrary.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            Dialogue dialogue = StoryScript.PutBookSelf;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.SetActive(false);
            _bookInteract.SetActive(true);
        });
    }
}
