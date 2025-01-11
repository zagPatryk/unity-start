using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float idleTime = 3f;
    [SerializeField] private float expectedMoveDistance = 0.1f;

    
    private Transform player;
    private Vector3 lastPlayerPosition;
    private float lastMoveTime;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("No player found");
        }
        
        if (meteorPrefab != null && player != null)
        {
            lastPlayerPosition = player.position;
            StartCoroutine(SpawnMeteors());
            Debug.Log("Start meteor spawner");
        }
        else
        {
            Debug.LogWarning("Meteor prefab or player is not assigned!");
        }
    }

    void Update()
    {
        if (Vector3.Distance(player.position, lastPlayerPosition) > expectedMoveDistance)
        {
            lastPlayerPosition = player.position;
            lastMoveTime = Time.time;
        }
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            Debug.Log("Check meteor spawner");
            if (Time.time - lastMoveTime >= idleTime)
            {
                Vector3 spawnPosition = new(
                    player.position.x,
                    player.position.y + 20f, 
                    player.position.z
                );
                Instantiate(
                    meteorPrefab, 
                    spawnPosition, 
                    Quaternion.identity
                );
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}