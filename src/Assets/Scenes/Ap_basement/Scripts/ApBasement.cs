using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApBasement : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockpick_door;

    void Start()
    {
        if (GameState.LastScene == "apSchoolInside")
        {
            gameObject.SetActive(false);
            return;
        }
        GameState.CurrentQuest = GlobalQuests.GoOutBasement;
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;

            Dialogue dialogue = StoryScript.AfterPassDoor;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.SetActive(false);
            _lockpick_door.SetActive(true);
        });
    }
}
