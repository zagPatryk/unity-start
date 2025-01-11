using UnityEngine;

public class Scorer : MonoBehaviour
{

    int hits = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Hit"))
        {
            return;
        }
        
        hits++;
        Debug.Log("Another collision..." + hits);
    }
}