using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTheoricScrip : MonoBehaviour
{

    [SerializeField]
    private GameObject _quest;

    [SerializeField]
    private GameObject _blackScreen;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToTheoryClass.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            _quest.SetActive(false);
            _blackScreen.SetActive(true);
            FindObjectOfType<Player>().enabled = false;
            FindObjectOfType<PlayerInteractor>().enabled = false;
            GameState.CurrentQuest = GlobalQuests.GoToBathroom;
        });
    }

}
