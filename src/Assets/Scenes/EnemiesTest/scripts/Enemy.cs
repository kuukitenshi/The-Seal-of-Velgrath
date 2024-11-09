using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float dodgeDistance = 1f;
    public float directionThreshold = 0.1f; // Threshold to prevent jiggling
    private Rigidbody2D rb;
    private Transform player;

    private Animator animator;

    private Vector2 moveDirection;
    private Vector2 lastDirection;

    private PlayerAwarenessController playerAwarenessController;

    // Wander variables
    public float wanderInterval = 2f; // How often to change direction
    private float wanderTimer;
    private Vector2 wanderDirection;
    public float wanderRadius = 3f; // Radius around the original position to wander
    private Vector2 originalPosition;

    // LayerMask for obstacle detection
    public LayerMask obstacleLayerMask;

    // States
    private enum EnemyState { Chasing, Returning, Wandering }
    private EnemyState currentState = EnemyState.Wandering;

    public float attackRange = 0.5f; // Range to trigger the attack
    private bool isAttacking = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        animator = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found. Ensure the player is tagged correctly.");
        }
        wanderTimer = wanderInterval; // Initialize the wander timer
        originalPosition = transform.position; // Store the original position
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            UpdateAnimations();
        }
    }

    private void MoveTowardsPlayer()
    {
        if (player == null)
        {
            return;
        }

        if (!playerAwarenessController.awareOfPlayer)
        {
            if (currentState == EnemyState.Chasing)
            {
                currentState = EnemyState.Returning; // Start returning if the player leaves the awareness area
            }

            if (currentState == EnemyState.Returning)
            {
                ReturnToOriginalPosition();
            }
            else if (currentState == EnemyState.Wandering)
            {
                Wander();
            }

            Debug.Log("Not aware of player, current state: " + currentState);
        }
        else
        {
            currentState = EnemyState.Chasing; // Start chasing the player
            // Calculate direction to the player
            Vector2 direction = player.position - transform.position;

            if (direction.magnitude < 0.3f)
            {
                // rb.velocity = Vector2.zero;
                // moveDirection = Vector2.zero;
                // return;
                if(!isAttacking) {
                    Debug.Log("Attacking player");
                    animator.SetBool("Attack", true);
                    isAttacking = true;
                    rb.velocity = Vector2.zero;
                    moveDirection = Vector2.zero;
                    StartCoroutine(Attack());
                } else {

                }

                return;
            } else 
            {
                animator.SetBool("Attack", false);
                StopCoroutine(Attack());
                isAttacking = false;
            }

            // Normalize the direction using Mathf.Sign to constrain values to -1, 0, or 1
            Vector2 newMoveDirection = new Vector2(Mathf.Sign(direction.x), Mathf.Sign(direction.y));

            // Apply a threshold to avoid flickering when the direction is close to zero
            float threshold = 0.05f; // You can tweak this value to suit your game
            if (Mathf.Abs(direction.x) < threshold) newMoveDirection.x = 0;
            if (Mathf.Abs(direction.y) < threshold) newMoveDirection.y = 0;

            // Prevent the enemy from constantly switching between two directions
            if (newMoveDirection != Vector2.zero)
            {
                lastDirection = moveDirection; // Store the last non-zero direction
            }

            // Update the movement direction only if it's non-zero
            if (newMoveDirection != Vector2.zero)
            {
                moveDirection = newMoveDirection;
            }

            // Check for obstacles and adjust direction
            if (IsObstacleInDirection(moveDirection))
            {
                moveDirection = GetDodgeDirection(moveDirection);
            }

            // Move the enemy
            rb.velocity = moveDirection * moveSpeed;

        }
    }

    private IEnumerator Attack()
    {
        // wait for the animation to finish
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Player dead");
    }

    private void ReturnToOriginalPosition()
    {
        // Calculate the direction back to the original position
        Vector2 direction = originalPosition - (Vector2)transform.position;

        // If close enough to the original position, switch to wandering state
        if (direction.magnitude < 0.1f)
        {
            rb.velocity = Vector2.zero;
            currentState = EnemyState.Wandering;
            return;
        }

        // Move towards the original position
        moveDirection = direction.normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Wander()
    {
        wanderTimer -= Time.deltaTime;

        // If the timer has elapsed, choose a new random direction within the wander radius
        if (wanderTimer <= 0)
        {
            Vector2 randomPoint = originalPosition + Random.insideUnitCircle * wanderRadius;
            wanderDirection = (randomPoint - (Vector2)transform.position).normalized;

            wanderTimer = wanderInterval; // Reset the timer
        }

        // Move in the current wandering direction
        rb.velocity = wanderDirection * moveSpeed;
        moveDirection = wanderDirection; // Update moveDirection for animation purposes
    }

    private bool IsObstacleInDirection(Vector2 direction)
    {
        // Use the LayerMask to filter out non-obstacle collisions
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dodgeDistance, obstacleLayerMask);
        return hit.collider != null;
    }

    private Vector2 GetDodgeDirection(Vector2 originalDirection)
    {
        Vector2[] possibleDirections = new Vector2[]
        {
            Vector2.up, Vector2.down, Vector2.left, Vector2.right,
            new Vector2(1, 1).normalized, new Vector2(1, -1).normalized,
            new Vector2(-1, 1).normalized, new Vector2(-1, -1).normalized
        };

        foreach (Vector2 dir in possibleDirections)
        {
            if (dir != originalDirection && !IsObstacleInDirection(dir))
            {
                return dir;
            }
        }

        return originalDirection; // If no dodge direction is found, keep the original direction
    }

    private void UpdateAnimations()
    {
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetFloat("LastMoveX", lastDirection.x);
        animator.SetFloat("LastMoveY", lastDirection.y);
    }
}
