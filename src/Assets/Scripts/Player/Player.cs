using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private SoundManager soundManager;

    public float moveSpeed = 2f;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    private bool isWalking = false;

    public LayerMask interactableLayer;
    public float interactionRange = 0.5f;

    private bool IsDead = false;

    public SpriteRenderer controlZone;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (!IsDead)
        {
            Move();
            HandleWalkingSound();
        }
    }

    void Move()
    {
        Vector2 move = moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    void UpdateAnimation()
    {
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
        animator.SetFloat("MoveX", moveDirection.x);
        animator.SetFloat("MoveY", moveDirection.y);
    }

    void HandleWalkingSound()
    {
        if (moveDirection != Vector2.zero)
        {
            if (!isWalking)
            {
                soundManager.PlaySFX(soundManager._walk);
                isWalking = true;
            }
        }
        else
        {
            if (isWalking)
            {
                soundManager.StopSFX();
                isWalking = false;
            }
        }
    }

    void OnDisable()
    {
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", 0);
    }

    public void Die()
    {
        IsDead = true;
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
        animator.SetBool("IsDead", IsDead);
        StartCoroutine(restartScene());
    }

    private IEnumerator restartScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
