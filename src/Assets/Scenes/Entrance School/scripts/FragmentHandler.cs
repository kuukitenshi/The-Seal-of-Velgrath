using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentHandler : MonoBehaviour
{
    public GameObject keyMechanic;

    void Awake()
    {
        Debug.Log(GameState.FragmentsCollected);
        Debug.Log(GameState.CurrentQuest);
        if (GameState.CurrentQuest == GlobalQuests.PickupStatueFragment)
        {
            keyMechanic.SetActive(true);
        }
    }
}
