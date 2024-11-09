using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacherDialog : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameState.CurrentQuest != null && GameState.CurrentQuest.Id == GlobalQuests.GoToPotionClass.Id)
        {
            Dialogue dialogue = StoryScript.ProfPotions;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (GameState.CurrentQuest != null && GameState.CurrentQuest.Id == GlobalQuests.GoToPotionClass.Id)
        {
            gameObject.SetActive(false);
        }
    }
}
