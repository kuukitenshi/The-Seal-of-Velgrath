using UnityEngine;

public class BookHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _bookOverlay;

    [SerializeField]
    private GameObject _quest;

    [SerializeField]
    private SoundManager _soundManager;

    void Start()
    {
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.TakeBookToLibrary.Id)
        {
            gameObject.SetActive(false);
            return;
        }
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _soundManager.PlayOneTimeSFX(_soundManager._pickupFragment);
            interactable.enabled = false;
            GameState.FragmentsCollected++;
            _bookOverlay.SetActive(true);
            GameState.CurrentQuest = GlobalQuests.GoToTheoryClass;
            _quest.SetActive(false);
        });
    }
}
