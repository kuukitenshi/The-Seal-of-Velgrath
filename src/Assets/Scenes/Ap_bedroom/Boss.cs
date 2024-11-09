using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Boss : MonoBehaviour
{
    private DialogueManager _dm;
    private int _countDialogs = 0;


    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.ReturnToHouse.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        _dm = FindObjectOfType<DialogueManager>();
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            // P1
            Dialogue p1 = StoryScript.Player1;
            _dm.StartDialogue(p1);
            _countDialogs++;
            interactable.enabled = false;
        });
    }

    //  p1 b1 p2 b2 p3 b3
    void Update()
    {
        //B1
        if (!_dm.IsPlaying() && _countDialogs == 1)
        {
            Dialogue b1 = StoryScript.Boss1;
            _dm.StartDialogue(b1);
            _countDialogs++;
        }
        // P2
        if (!_dm.IsPlaying() && _countDialogs == 2)
        {
            Dialogue p2 = StoryScript.Player2;
            _dm.StartDialogue(p2);
            _countDialogs++;
        }
        // B2
        if (!_dm.IsPlaying() && _countDialogs == 3)
        {
            Dialogue b2 = StoryScript.Boss2;
            _dm.StartDialogue(b2);
            _countDialogs++;
        }
        // P3
        if (!_dm.IsPlaying() && _countDialogs == 4)
        {
            Dialogue p3 = StoryScript.Player3;
            _dm.StartDialogue(p3);
            _countDialogs++;
        }
        // B3
        if (!_dm.IsPlaying() && _countDialogs == 5)
        {
            Dialogue b3 = StoryScript.Boss3;
            _dm.StartDialogue(b3);
            _countDialogs++;
        }
        if (!_dm.IsPlaying() && _countDialogs == 6)
        {
            SceneTransitionManager.TransitionToScene("EndCredits");
        }
    }
}
