using UnityEngine;

public class Moveable_old : IInteractable
{
    public float moveSpeed = 1f;  // movement speed of the object
    public Transform playerTransform;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isBeingControlled = false;
    private float controlRange = 1f;  // range within which the object can be controlled

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        enabled = false;
        rb.isKinematic = true;
    }

    public override void Interact() { }

    private void Update()
    {
        if (isBeingControlled)
        {
            // Get input from WASD keys for object movement
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            // Create a movement vector
            movement = new Vector2(moveX, moveY).normalized * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (isBeingControlled)
        {
            Vector2 newPosition = rb.position + movement * Time.fixedDeltaTime;

            // calculates the distance from the player
            Vector2 directionFromPlayer = newPosition - (Vector2)playerTransform.position;
            if (directionFromPlayer.magnitude > controlRange)
            {
                // position in range
                newPosition = (Vector2)playerTransform.position + Vector2.ClampMagnitude(directionFromPlayer, controlRange);
            }
            rb.MovePosition(newPosition);
        }
    }

    // FIXME:
    // private void OnTriggerEnter2D(Collider2D other) {
    //     Debug.Log("tag: " + other.gameObject.tag);
    //     Debug.Log("being controlled: " + !isBeingControlled);
    //     if (other.gameObject.CompareTag("PlayerInteractionRange") && !isBeingControlled) {
    //         Debug.Log("Object entered interaction range.");
    //         // change color
    //         this.GetComponent<SpriteRenderer>().color = Color.red;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("PlayerInteractionRange") && !isBeingControlled) {
    //         Debug.Log("Object exited interaction range.");
    //         // change color to white if distance o player is greater than 2f

    //         this.GetComponent<SpriteRenderer>().color = Color.white;

    //     }
    // }

    public void SetControl(bool control)
    {
        Debug.Log("Setting control to " + control);
        isBeingControlled = control;
        if (!control)
        {
            if (Vector2.Distance(playerTransform.position, rb.position) > 0.5f)
            {
                Debug.Log("Distance is greater than 0.5f");
                this.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                Debug.Log("Distance is less than 0.5f");
                this.GetComponent<SpriteRenderer>().color = Color.red;

            }
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
        else
        {
            Debug.Log("setting kinematic false");
            rb.isKinematic = false;
        }
    }

}
