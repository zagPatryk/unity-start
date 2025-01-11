using System;
using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] private float minFlySpeed = 6f;
    [SerializeField] private float maxFlySpeed = 10f;
    [SerializeField] private GameObject explosionEffect;
    private float closeDistance = 3f;

    private Transform player;
    private bool isCloseToPlayer = false;
    private Vector3 currentDirection;

    // [SerializeField] Transform player;
    // private Vector3 playerPosition;

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
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        float flySpeed = Mathf.Lerp(minFlySpeed, maxFlySpeed, Mathf.InverseLerp(0f, 20f, distance));

        if (isCloseToPlayer || distance < closeDistance)
        {
            isCloseToPlayer = true;
            transform.Translate(currentDirection * flySpeed * Time.deltaTime, Space.World);
        }
        else
        {
            currentDirection = (player.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(
                transform.position, 
                player.transform.position, 
                flySpeed * Time.deltaTime
            );
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
