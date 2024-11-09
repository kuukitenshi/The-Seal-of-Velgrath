using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLockerHidder : MonoBehaviour
{
    void Start()
    {
        if (!GameState.DoorUnlocked)
        {
            gameObject.SetActive(false);
        }
    }
}
