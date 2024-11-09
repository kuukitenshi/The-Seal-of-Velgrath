using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 moveDir = new Vector2(moveX, moveY);
        rb.velocity = moveDir * moveSpeed * Time.fixedDeltaTime;
    }
}
