using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public Collider2D cuboCollider;
    public Collider2D zoneCollider;
    public Player player;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject r4;

    public GameObject top;
    public GameObject bottom;
    public GameObject keyFragment;

    void Update()
    {
        // check to see if cubo is completly inside zone
        if (IsCompletelyInside(cuboCollider))
        {
            Debug.Log("Cubo is inside zone");
            ActivateRunes();
            keyFragment.gameObject.SetActive(true);
            this.gameObject.GetComponent<Moveable>().toggleScripts();
            GetComponent<SpriteRenderer>().color = Color.white;
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.controlZone.gameObject.SetActive(false);
            Destroy(gameObject); // destroy movable
        }
    }

    private bool IsCompletelyInside(Collider2D other)
    {
        Bounds zoneBounds = zoneCollider.bounds;
        Bounds otherBounds = other.bounds;
        return zoneBounds.Contains(otherBounds.min) && zoneBounds.Contains(otherBounds.max);
    }

    private void ActivateRunes()
    {
        r1.SetActive(true);
        r2.SetActive(true);
        r3.SetActive(true);
        r4.SetActive(true);
    }
}