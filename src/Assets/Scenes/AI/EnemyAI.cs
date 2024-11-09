using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] Transform player;

    NavMeshAgent agent;
    // Start is called before the first frame update

    private PlayerAwarenessController playerAwarenessController;

    //--------------
    private Animator animator;

    private Transform origin;

    private Rigidbody2D rb;

    public float moveSpeed = 2f;

    private Vector2 moveDirection;

    private Vector2 lastDirection;

    private Vector2 wanderDirection;

    public float wanderInterval = 2f; // How often to change direction

    private float wanderTimer;

    public float wanderRadius = 3f; // Radius around the original position to wander




    void Start()
    {
        animator = GetComponent<Animator>();
        origin = transform;
        playerAwarenessController = GetComponent<PlayerAwarenessController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        // perseguir player
        if (playerAwarenessController.awareOfPlayer) {
            agent.SetDestination(player.position);
            moveDirection = playerAwarenessController.directionToPlayer;
        }
        else // voltar a posicao inicial e dar wander
        {
            moveDirection = Vector2.zero;
            lastDirection = moveDirection;
            ReturnOrigin();
            Wander();
        }

        UpdateAnimation();

        
    }

    private void ReturnOrigin() 
    {
        agent.SetDestination(origin.position);
    }

    private void Wander()
    {
        wanderTimer -= Time.deltaTime;

        // If the timer has elapsed, choose a new random direction within the wander radius
        if (wanderTimer <= 0)
        {
            Vector2 randomPoint =  new Vector2(origin.position.x, origin.position.y) + Random.insideUnitCircle * wanderRadius;
            wanderDirection = (randomPoint - (Vector2)transform.position).normalized;

            wanderTimer = wanderInterval; // Reset the timer
        }

        agent.SetDestination(transform.position + (Vector3)wanderDirection * 2);
        moveDirection = wanderDirection; // Update moveDirection for animation purposes
    }

    private void UpdateAnimation() {
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
        animator.SetFloat("LastMoveX", lastDirection.x);
        animator.SetFloat("LastMoveY", lastDirection.y);
    }
}
