using System.Collections;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Vector3 spawnPosition = new(10,10,10);

    void Start()
    {
        if (projectilePrefab != null)
        {
            StartCoroutine(SpawnProjectile());
            Debug.Log("Start projectile spawner");
        }
        else 
        {
            Debug.LogWarning("Meteor prefab is not assigned!");
        }

    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            Debug.Log("Spawn projectile");
            Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}