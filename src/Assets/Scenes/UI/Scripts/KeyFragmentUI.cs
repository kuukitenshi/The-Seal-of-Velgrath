using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyFragmentUI : MonoBehaviour
{
    [SerializeField]
    private int _fragmentIndex;
    [SerializeField]
    private Sprite _collectedSprite;
    [SerializeField]
    private Sprite _notCollectedSprite;
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        if (GameState.KeyCrafted || GameState.FragmentsCollected == 0)
        {
            _image.enabled = false;
            return;
        }
        _image.enabled = true;
        _image.sprite = GameState.FragmentsCollected >= _fragmentIndex ? _collectedSprite : _notCollectedSprite;
    }
}
