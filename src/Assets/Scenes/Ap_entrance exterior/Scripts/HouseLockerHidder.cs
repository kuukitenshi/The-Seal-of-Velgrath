using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLockerHidder : MonoBehaviour
{
    void Start()
    {
        if (!GameState.ApHouseUnlocked)
        {
            gameObject.SetActive(false);
        }
    }
}
