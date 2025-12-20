using UnityEngine;

public class Snowflake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Snowflake Trigger");
        Debug.Log(collision.tag);
        if (collision.tag == "Ground")
        {
            Debug.Log("poof");
            GameManager.ResetScore();
            OutsideSceneUI.instance.UpdateScore();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("grab");
            GameManager.AddScore(1);
            OutsideSceneUI.instance.UpdateScore();
            Destroy(this.gameObject);
        }
    }

}
