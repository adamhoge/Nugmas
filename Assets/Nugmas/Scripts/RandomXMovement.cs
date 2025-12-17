using UnityEngine;

public class RandomXMovement : MonoBehaviour
{

    public float waitTime = 0.5f;
    public float minimumX = -9f;
    public float maximumX = 9f;
    
    private float timeToMove = 0f;
    void Update()
    {
        NewPosition();
    }
    void NewPosition() 
    {
        if (Time.time >= timeToMove)
        {
            float num = Mathf.Round(Random.Range(minimumX,maximumX) * 10) / 10;  
            Vector3 position = transform.position;
            transform.position = new Vector3(num, position.y, position.z);
            timeToMove = Time.time + waitTime;
        }
    }
}
