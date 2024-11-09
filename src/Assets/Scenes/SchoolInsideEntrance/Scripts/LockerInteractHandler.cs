using System.Collections;
using UnityEngine;

public class LockerInteractHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockpick;

    [SerializeField]
    private GameObject _locker;

    [SerializeField]
    private SoundManager _soundManager;
    void Start()
    {
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            interactable.enabled = false;
            _lockpick.SetActive(true);
            FindObjectOfType<Player>().enabled = false;
            FindObjectOfType<PlayerInteractor>().enabled = false;
        });
        if (GameState.CurrentQuest == null || GameState.CurrentQuest.Id != GlobalQuests.OpenLocker.Id)
        {
            gameObject.SetActive(false);
            return;
        }
    }

    void Update()
    {
        if (Pin.pinCounter == 5)
        {
            StartCoroutine(waitLock());
            Pin.pinCounter = 0;
            _soundManager.PlayOneTimeSFX(_soundManager._lockOpened);
        }
    }

    IEnumerator waitLock()
    {
        yield return new WaitForSeconds(0.5f);
        _locker.SetActive(false);
        _lockpick.SetActive(false);
        Dialogue dialogue = StoryScript.AfterOpenLoker;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameState.CurrentQuest = GlobalQuests.TakeBookToLibrary;
    }
}
