using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    [SerializeField]
    private GameObject _pedraOverlay;

    public GameObject cubo;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.PickupStatueFragment.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            Debug.Log("Interacted with statue");
            _pedraOverlay.SetActive(true);
            cubo.SetActive(true);
            // gameObject.SetActive(false);
        });
    }
}
