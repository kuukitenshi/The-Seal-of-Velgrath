using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneColli : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneTransitionManager.TransitionToScene(_sceneName);
        }
    }
}
