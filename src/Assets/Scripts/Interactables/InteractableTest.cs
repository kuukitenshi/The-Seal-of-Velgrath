using Unity.VisualScripting;
using UnityEngine;

public class InteractableTest : IInteractable
{
    public override void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name + " (Chest)");
    }

    // FIXME:
    // private void OnTriggerEnter2D(Collider2D other) {

    //     if (other.CompareTag("PlayerInteractionRange")) {
    //         Debug.Log("Player entered " + gameObject.name + " (Chest)");

    //         //highlight object
    //         this.GetComponent<SpriteRenderer>().color = Color.red;

    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {

    //     if (other.CompareTag("PlayerInteractionRange")) {
    //         Debug.Log("Player exited " + gameObject.name + " (Chest)");
    //         //remove highlight
    //         this.GetComponent<SpriteRenderer>().color = Color.white;
    //     }

    // }

}