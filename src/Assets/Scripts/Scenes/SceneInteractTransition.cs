using UnityEngine;

public class SceneInteractTransition : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    void Start()
    {
        GetComponent<Interactable>().onInteract.AddListener(() =>
        {
            SceneTransitionManager.TransitionToScene(_sceneName);
        });
    }
}
