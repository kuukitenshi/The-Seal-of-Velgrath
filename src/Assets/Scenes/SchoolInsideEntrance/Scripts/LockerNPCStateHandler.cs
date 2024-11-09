using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerNPCStateHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockerInteract;

    [SerializeField]
    private GameObject _quest;

    [SerializeField]
    private GameObject _locker;

    void Start()
    {
        if (GameState.CurrentQuest == null || (GameState.CurrentQuest.Id != GlobalQuests.GoToSchool.Id && GameState.CurrentQuest.Id != GlobalQuests.OpenLocker.Id))
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        if (GameState.CurrentQuest.Id == GlobalQuests.OpenLocker.Id)
        {
            interactable.enabled = false;
            return;
        }
        interactable.onInteract.AddListener(() =>
        {
            GameState.CurrentQuest = GlobalQuests.OpenLocker;
            _lockerInteract.SetActive(true);
            _quest.SetActive(false);
            _locker.SetActive(true);
        });
    }
}
