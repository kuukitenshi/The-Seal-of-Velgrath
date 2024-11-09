using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{

    private Rigidbody2D rb;

    private bool isBeingControlled = false;

    private Vector2 moveDirection;

    public float moveSpeed = 1f;

    private Player player;

    private PlayerInteractor interactor;

    private float controlRange = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Interactable interactable = GetComponent<Interactable>();
        player = FindObjectOfType<Player>();
        interactor = player.GetComponent<PlayerInteractor>();
        interactable.onInteract.AddListener(() =>
        {
            Debug.Log("Interacted with moveable object");
            GetComponent<SpriteRenderer>().color = new Color(0f, 0.837f, 0.9245283f, 1f);
            isBeingControlled = !isBeingControlled;
            player.controlZone.gameObject.SetActive(isBeingControlled);
            toggleScripts();
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            if (!isBeingControlled)
            {
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
            }
            else
            {
                Debug.Log("setting kinematic false");
                rb.isKinematic = false;
            }

        });

    }

    public void toggleScripts()
    {
        if (player != null)
        {
            player.enabled = !player.enabled;
        }
        if (interactor != null)
        {
            interactor.enabled = !interactor.enabled;
        }

    }

    private void Update()
    {
        if (isBeingControlled)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized * moveSpeed;

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
            {
                toggleScripts();
                GetComponent<SpriteRenderer>().color = Color.white;
                player.GetComponent<Rigidbody2D>().isKinematic = false;
                isBeingControlled = false;
                player.controlZone.gameObject.SetActive(isBeingControlled);
                rb.isKinematic = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isBeingControlled)
        {
            Vector2 newPosition = rb.position + moveDirection * Time.fixedDeltaTime;

            Vector2 directionFromPlayer = newPosition - (Vector2)player.transform.position;
            if (directionFromPlayer.magnitude > controlRange)
            {
                newPosition = (Vector2)player.transform.position + Vector2.ClampMagnitude(directionFromPlayer, controlRange);
            }

            rb.MovePosition(newPosition);
        }

    }

}
