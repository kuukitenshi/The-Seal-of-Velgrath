using UnityEngine;

public class BookOverlay : MonoBehaviour
{
    private Player _player;
    private PlayerInteractor _interact;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
        _interact = FindObjectOfType<PlayerInteractor>();
        Debug.Log(_player);
    }

    void OnEnable()
    {
        ToggleScripts();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        ToggleScripts();
        Dialogue dialogue = StoryScript.GoToTheoryClass;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void ToggleScripts()
    {
        Debug.Log("Scripts toggled!");
        if (_player != null)
        {
            _player.enabled = !_player.enabled;
        }
        if (_interact != null)
        {
            _interact.enabled = !_interact.enabled;
        }
    }
}
