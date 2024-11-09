using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyFragment : MonoBehaviour
{
    public float hoverSpeed = 2f;
    public float hoverAmount = 0.5f;

    private Vector3 originalPosition;

    [SerializeField]
    private SoundManager _soundManager;

    void Start()
    {
        originalPosition = transform.position;
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _soundManager.PlayOneTimeSFX(_soundManager._pickupFragment);
            PickUp();
        });
    }

    void Update()
    {
        HoveringEffect();
    }

    private void HoveringEffect()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverAmount;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    private void PickUp()
    {
        GameState.FragmentsCollected++;
        gameObject.SetActive(false);
        GameState.CurrentQuest = GlobalQuests.GoToPotionClass;
        SceneTransitionManager.TransitionToScene("Wc");
    }
}
