using UnityEngine;

public class TimedEmitter : MonoBehaviour
{
    public GameObject snowflakeObject = null;
    public GameObject icicleObject = null;
    public float minimumWaitTime = 0.5f;
    public float maximumWaitTime = 3f;

    private float timeToEmit = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEmit();
    }

    void CheckEmit() 
    {
        if (Time.time >= timeToEmit)
        {
            
            Instantiate(snowflakeObject, transform.position, Quaternion.identity, null);
            float waitTime = Random.Range(minimumWaitTime,maximumWaitTime);  
            timeToEmit= Time.time + waitTime;
        }
    }
}
