using UnityEngine;

public class SquareInteractable : MonoBehaviour
{
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            rb.AddForce(new Vector2(0, 2));
        });
    }
}
