using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{

    [SerializeField] Transform player;

    [SerializeField]
    private SoundManager soundManager;

    NavMeshAgent agent;

    private PlayerAwarenessController playerAwarenessController;

    //--------------

    private Transform origin;

    private Rigidbody2D rb;

    public float moveSpeed = 2f;
    private Vector2 wanderDirection;

    public float wanderInterval = 2f;

    private float wanderTimer;

    public float wanderRadius = 3f;

    private float attackRange = 0.35f;

    private bool isAttacking = false;

    private Animator animator;

    private Vector2 lastDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
        origin = transform;
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {

        if (playerAwarenessController.awareOfPlayer)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                Debug.Log("Attack");

                isAttacking = true;
                animator.SetFloat("MoveX", lastDirection.x);
                animator.SetFloat("MoveY", lastDirection.y);
                animator.SetBool("isAttacking", isAttacking);
                if (lastDirection.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                StartCoroutine(CheckPlayerAfterDelay());

            }
            else
            {
                isAttacking = false;
                animator.SetBool("isAttacking", isAttacking);
                agent.SetDestination(player.position);
                UpdateMovementAnimation();
            }

        }
        else
        {
            isAttacking = false;
            animator.SetBool("isAttacking", isAttacking);
            ReturnOrigin();
            UpdateMovementAnimation();

            // Check if the enemy has reached its origin
            if (Vector2.Distance(transform.position, origin.position) < 0.1f)
            {
                Wander();
            }
        }

        UpdateAnimation();

    }

    private IEnumerator CheckPlayerAfterDelay()
    {
        yield return new WaitForSeconds(0.75f);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            soundManager.PlayOneTimeSFX(soundManager._death);
            player.GetComponent<Player>().Die();
        }
        else
        {
            isAttacking = false;
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    private void UpdateMovementAnimation()
    {
        Vector3 direction = agent.velocity.normalized;

        if (direction.magnitude > 0)
        {
            lastDirection = direction;

            if (direction.y > 0)
            {
                Debug.Log("Up");
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 1);
                transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                Debug.Log("Down");
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
                transform.localScale = new Vector3(1, 1, 1);

            }

        }
    }

    private void ReturnOrigin()
    {
        agent.SetDestination(origin.position);
    }

    private void Wander()
    {
        wanderTimer -= Time.deltaTime;

        if (wanderTimer <= 0)
        {
            Vector2 randomPoint = new Vector2(origin.position.x, origin.position.y) + Random.insideUnitCircle * wanderRadius;
            wanderDirection = (randomPoint - (Vector2)transform.position).normalized;

            wanderTimer = wanderInterval;
        }

        agent.SetDestination(transform.position + (Vector3)wanderDirection * 2);
    }

    private void UpdateAnimation()
    {
        animator.SetBool("isAttacking", isAttacking);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Moveable"))
        {
            Debug.Log("Hit");
            soundManager.PlayOneTimeSFX(soundManager._kill);
            other.gameObject.GetComponent<Moveable>().toggleScripts();
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<Player>().controlZone.gameObject.SetActive(false);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
