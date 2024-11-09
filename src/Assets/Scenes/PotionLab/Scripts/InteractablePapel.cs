using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePapel : MonoBehaviour
{

    [SerializeField]
    private GameObject _paperOverlay;

    [SerializeField]
    private GameObject _quest;
    [SerializeField]
    private SoundManager _soundManager;


    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.GoToPotionClass.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _soundManager.PlayOneTimeSFX(_soundManager._paper);
            _quest.SetActive(false);
            interactable.enabled = false;
            GameState.CurrentQuest = GlobalQuests.PickupStatueFragment;
            _paperOverlay.SetActive(true);
            gameObject.SetActive(false);
        });
    }
}
