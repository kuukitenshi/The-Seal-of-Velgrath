using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInteractable : MonoBehaviour
{

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("PlayerInteractionRange"))
        {
            Debug.Log("Player entered " + gameObject.name + " (Chest)");
            this.GetComponent<SpriteRenderer>().color = Color.red; //highlight object

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("PlayerInteractionRange"))
        {
            Debug.Log("Player exited " + gameObject.name + " (Chest)");
            this.GetComponent<SpriteRenderer>().color = Color.white; //remove highlight
        }

    }
}