using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockpick;

    [SerializeField]
    private GameObject _close_door_cima;

    [SerializeField]
    private GameObject _close_door_baixo;

    [SerializeField]
    private GameObject _open_door_cima;

    [SerializeField]
    private GameObject _open_door_baixo;

    [SerializeField]
    private SoundManager _soundManager;

    void Start()
    {
        if (GameState.LastScene == "apSchoolInside")
        {
            _close_door_baixo.SetActive(false);
            _close_door_cima.SetActive(false);
            _open_door_baixo.SetActive(true);
            _open_door_cima.SetActive(true);
        }
        gameObject.SetActive(false);
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _lockpick.SetActive(true);
            FindObjectOfType<Player>().enabled = false;
            FindObjectOfType<PlayerInteractor>().enabled = false;
        });
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

        _close_door_cima.SetActive(false);
        _close_door_baixo.SetActive(false);
        // _open_door_baixo.SetActive(true);
        // _open_door_cima.SetActive(true);

        _lockpick.SetActive(false);
        gameObject.SetActive(false); //E of the lookpick door

        Dialogue dialogue = StoryScript.UnlockDoor;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
