using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{

    public bool awareOfPlayer {get; private set;}

    public Vector2 directionToPlayer {get; private set;}

    [SerializeField]
    private float playerAwarenessDistance = 5f;

    private Transform player;

    void Awake()
    {
        player = FindObjectOfType<Player>().transform;
        
    }


    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude <= playerAwarenessDistance) {
            awareOfPlayer = true;
        } else {
            awareOfPlayer = false;
        }

    }
}
