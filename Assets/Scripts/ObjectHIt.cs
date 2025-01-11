using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) // hitting object
        {
            gameObject.tag = "Hit"; // hit object
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

    }
}
