using UnityEngine;
using UnityEngine.UI;

public class Completed : MonoBehaviour
{
    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        _image.enabled = GameState.KeyCrafted && !GameState.DoorUnlocked;
    }
}
