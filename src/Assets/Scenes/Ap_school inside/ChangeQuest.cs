using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeQuest : MonoBehaviour
{
    void Start()
    {
        GameState.CurrentQuest = GlobalQuests.ReturnToHouse;
    }
}
