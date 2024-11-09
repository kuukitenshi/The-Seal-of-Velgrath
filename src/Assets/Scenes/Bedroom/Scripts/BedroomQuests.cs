using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomQuests : MonoBehaviour
{
    bool _dialogShown = false;
    float _seconds = 0;
    bool _shouldDisplayDialog = false;

    void Start()
    {
        if (GameState.CurrentQuest == null)
        {
            GameState.CurrentQuest = GlobalQuests.GoToSchool;
            _shouldDisplayDialog = true;
        }
    }

    void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds > 0.5 && !_dialogShown && _shouldDisplayDialog)
        {
            _dialogShown = true;
            Dialogue dialogue = StoryScript.BedroomStart;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
