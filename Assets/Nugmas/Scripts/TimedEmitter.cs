using UnityEngine;

public class TimedEmitter : MonoBehaviour
{
    public GameObject snowflakeObject = null;
    public GameObject icicleObject = null;
    public GameObject presentObject = null;
    public float minimumWaitTime = 0.5f;
    public float maximumWaitTime = 3f;

    public int streakBeforePresents = 0;
    public int streakBeforeIcicles = 0;
    

    [SerializeField, Range(1, 100)]
    [Tooltip("Chance out of 100 that an icicle will fall instead of a snowflake. Only checked if a present is not falling.")]
    private int chanceOfIcicle = 1;

    private int timesSincePresent = 0;    
    private int timesSinceIcicle = 0;



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
            int streak = GameManager.score;
            string emitType = "snowflake";
            timesSincePresent += 1;
            timesSinceIcicle += 1;
            if (streak >= streakBeforePresents) {
                int PresentResult = Random.Range(1,30) + GameManager.score;
                if(PresentResult >= 30 || timesSincePresent >= 10) {
                    emitType = "present";
                    timesSincePresent = 0;
                }
            }
            if (emitType == "snowflake" && streak >= streakBeforeIcicles) {
                int IcicleResult = Random.Range(1,100);
                if(IcicleResult<=chanceOfIcicle || timesSinceIcicle >= 6) {
                    emitType = "icicle";
                    timesSinceIcicle = 0;
                }
            }
            
            switch(emitType)
            {
                case "present":
                Instantiate(presentObject, transform.position, Quaternion.identity, null);
                break;
                case "icicle":
                Instantiate(icicleObject, transform.position, Quaternion.identity, null);
                break;
                default:
                Instantiate(snowflakeObject, transform.position, Quaternion.identity, null);
                break;
            }
            
            
            

            float waitTime = Random.Range(minimumWaitTime,maximumWaitTime);  
            timeToEmit= Time.time + waitTime;
        }
    }
}
