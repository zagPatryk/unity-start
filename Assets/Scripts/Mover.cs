using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float scale = 10f; // [SerializeField] - accessed from unity
    [SerializeField] private float rotate = 30f; 
    
    void Start()
    {
        PrintInstructions();
    }

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * scale;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * scale;
        
        float rValue;
        if (Input.GetKey("q"))
            rValue = rotate;
        else if (Input.GetKey("e"))
            rValue = -rotate;
        else
            rValue = 0;
        
        transform.Translate(xValue, 0, zValue); // transform - move object in game
        transform.Rotate(0, rValue * Time.deltaTime, 0);
    }

    void PrintInstructions()
    {
        Debug.Log("Just play...");
    }
}
