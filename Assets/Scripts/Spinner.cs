using UnityEngine;

public class Spinner : MonoBehaviour
{
    
    [SerializeField] private float rotate = 2f; 

    void Update()
    {
        transform.Rotate(0, rotate * Time.deltaTime, 0);
    }
}
