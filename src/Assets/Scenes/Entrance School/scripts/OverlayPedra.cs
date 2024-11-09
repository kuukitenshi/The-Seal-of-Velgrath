using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPedra : MonoBehaviour
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
