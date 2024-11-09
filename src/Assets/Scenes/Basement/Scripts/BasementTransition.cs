using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementTransition : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;

    [SerializeField]
    private GameObject _questIndicator;

    [SerializeField]
    private SoundManager _soundManager;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToBasement.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            _questIndicator.SetActive(false);
            GameState.KeyCrafted = true;
            Dialogue dialogue = StoryScript.BeforeOpenDoor;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            _soundManager.PlaySFX(_soundManager._door);
            GameState.CurrentQuest = GlobalQuests.EnterDoor;
            _door.SetActive(true);
            GameState.DoorUnlocked = true;
        });

    }

}
