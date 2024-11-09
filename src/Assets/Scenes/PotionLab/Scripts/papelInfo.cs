using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class papelInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject _papelInteract;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToPotionClass.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            Dialogue dialogue = StoryScript.PotionPaper;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            gameObject.SetActive(false);
            _papelInteract.SetActive(true);
        });
    }
}
