using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLabQuestIndicator : MonoBehaviour
{
    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToPotionClass.Id)
        {
            gameObject.SetActive(false);
        }
    }
}
