using System;
using UnityEngine;

public class MoveableController
{
    private Player player;
    private Color highlightColor;
    private SpriteRenderer objectSpriteRenderer;

    public MoveableController(Player player, Color highlightColor)
    {
        this.player = player;
        this.highlightColor = highlightColor;

    }

    public void ToggleControl(Moveable_old moveable, bool isControllingObject)
    {
        Debug.Log("Toggling control");
        if (isControllingObject)
        {
            // player.StopPlayerMovement();

            objectSpriteRenderer = moveable.GetComponent<SpriteRenderer>();
            if (objectSpriteRenderer != null)
            {
                objectSpriteRenderer.color = highlightColor;
            }
            else
            {
                Debug.LogError("Interactable object does not have a SpriteRenderer component.");
            }

            if (moveable != null)
            {
                moveable.playerTransform = player.transform;
                moveable.enabled = true;
                moveable.SetControl(true);
            }
        }
        else
        {
            Debug.Log("Stopped controlling object");
            RevertObject(moveable);
            if (moveable != null)
            {
                moveable.SetControl(false);
            }
        }
    }

    public void RevertObject(Moveable_old moveable)
    {
        Debug.Log("Reverting object");
        if (objectSpriteRenderer != null)
        {
            Debug.Log("Reverting color");
            Debug.Log("Object to revert color is : " + moveable.name);

            moveable.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (moveable != null)
        {
            moveable.enabled = false;
        }
    }

}
