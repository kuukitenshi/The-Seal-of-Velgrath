using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    bool _dialogShown = false;
    float _seconds = 0;

    void Start()
    {
        if (GameState.LastScene == "Wc_Vision")
        {
            Interactable inter = GetComponent<Interactable>();
            inter.enabled = false;
            // Dialogue dialogue = StoryScript.AfterVision;
            // FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            return;
        }
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToBathroom.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            SceneTransitionManager.TransitionToScene("Wc_Vision");
        });
    }

    void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds > 0.5 && !_dialogShown && GameState.LastScene == "Wc_Vision")
        {
            _dialogShown = true;
            Dialogue dialogue = StoryScript.AfterVision;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
