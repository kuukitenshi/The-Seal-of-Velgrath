using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameUI : MonoBehaviour
{
    [SerializeField]
    private int _fragmentsCollected = 0;
    [SerializeField]
    private bool _keyCrafted = false;
    [SerializeField]
    private string _currentQuest;

    void Update()
    {
        GameState.FragmentsCollected = _fragmentsCollected;
        GameState.KeyCrafted = _keyCrafted;
        GameState.CurrentQuest = _currentQuest == string.Empty ? null : new Quest("a", _currentQuest);
    }
}
