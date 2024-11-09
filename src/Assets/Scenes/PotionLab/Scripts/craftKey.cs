using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftKey : MonoBehaviour
{
    [SerializeField]
    private GameObject _questIndicate;

    [SerializeField]
    private SoundManager _soundManager;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.CraftKey.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _soundManager.PlayOneTimeSFX(_soundManager._crafting);
            interactable.enabled = false;
            _questIndicate.SetActive(false);
            GameState.CurrentQuest = GlobalQuests.GoToBasement;
            GameState.KeyCrafted = true;
            Dialogue dialogue = StoryScript.AfterCraftKey;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        });
    }
}
