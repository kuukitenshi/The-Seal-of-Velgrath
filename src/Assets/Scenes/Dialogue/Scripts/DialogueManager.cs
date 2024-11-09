using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _nameText;

    [SerializeField]
    private TMP_Text _dialogueText;

    [SerializeField]
    private GameObject _nextLabel;

    [SerializeField]
    private GameObject _dialogueUI;

    [SerializeField]
    private int _typingSpeedMilis;

    private Queue<string> sentences = new Queue<string>();
    private Coroutine _typingCoroutine = null;
    private bool _isTyping = false;
    private string _currentSentence;

    private Player _playerScript;
    private PlayerInteractor _interactorScript;

    private SoundManager _soundManager;

    private bool _isPlaying;

    public bool IsPlaying()
    {
        return _isPlaying;
    }

    void Start()
    {
        _playerScript = FindObjectOfType<Player>();
        _interactorScript = FindObjectOfType<PlayerInteractor>();
        _soundManager = FindObjectOfType<SoundManager>();
        _dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (_dialogueUI.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (_nextLabel.activeSelf)
            {
                DisplayNextSentence();
            }
            else if (_isTyping)
            {
                StopCoroutine(_typingCoroutine);
                _dialogueText.text = _currentSentence;
                StopTyping();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _isPlaying = true;
        ToggleScripts(false);
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
            _typingCoroutine = null;
        }
        _dialogueUI.SetActive(true);
        _nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        _soundManager.StopSFX();
        _soundManager.PlayOneTimeSFX(_soundManager._talk);
        if (sentences.Count == 0)
        {
            _soundManager.StopSFX();
            EndDialogue();
            return false;
        }
        string sentence = sentences.Dequeue();
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
        }
        _typingCoroutine = StartCoroutine(Typing(sentence));
        return true;
    }

    IEnumerator Typing(string sentence)
    {
        _currentSentence = sentence;
        _nextLabel.SetActive(false);
        _isTyping = true;
        _dialogueText.text = "";
        foreach (char letter in sentence)
        {
            _dialogueText.text += letter;
            yield return new WaitForSeconds(_typingSpeedMilis / 1000f);
        }
        StopTyping();
        yield return null;
    }

    void StopTyping()
    {
        _isTyping = false;
        _nextLabel.SetActive(true);
    }

    void EndDialogue()
    {
        if (_typingCoroutine != null)
        {
            StopCoroutine(_typingCoroutine);
            _typingCoroutine = null;
        }
        _dialogueUI.SetActive(false);
        ToggleScripts(true);
        _isPlaying = false;
    }

    void ToggleScripts(bool value)
    {
        if (_playerScript != null)
        {
            _playerScript.enabled = value;
        }
        if (_interactorScript != null)
        {
            _interactorScript.enabled = value;
        }
    }
}

