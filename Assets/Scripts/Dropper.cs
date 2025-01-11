using System;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float timeToWait = 2f;
    
    private MeshRenderer renderer;
    private Rigidbody rigidbody;
    
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        
        renderer.enabled = false;
        rigidbody.useGravity = false;
    }

    private void Update()
    {
        if (Time.time > timeToWait)
            Drop();
    }

    private void Drop()
    {
        renderer.enabled = true;
        rigidbody.useGravity = true;
    }
}
