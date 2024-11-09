using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyFragment_Statue : MonoBehaviour
{
    public float hoverSpeed = 2f;
    public float hoverAmount = 0.5f;

    [SerializeField]
    private SoundManager _soundManager;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;

        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() => PickUp());
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
        _soundManager.PlayOneTimeSFX(_soundManager._pickupFragment);
        GameState.FragmentsCollected++;
        gameObject.SetActive(false);

        Dialogue dialogue = StoryScript.AfterPickLastFragment;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        GameState.CurrentQuest = GlobalQuests.CraftKey;
    }
}
