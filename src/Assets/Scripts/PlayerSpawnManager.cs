using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    void Awake()
    {
        PlayerSpawner[] spawners = FindObjectsOfType<PlayerSpawner>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        foreach (PlayerSpawner spawner in spawners)
        {
            Debug.Log($"Comparing {spawner.spawnerName} with {GameState.LastScene} result: {spawner.spawnerName == GameState.LastScene}");
            if (spawner.spawnerName == GameState.LastScene)
            {
                player.transform.position = spawner.transform.position;
                break;
            }
        }

    }
}
