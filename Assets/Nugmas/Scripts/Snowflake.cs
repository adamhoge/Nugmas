using UnityEngine;

public class Snowflake : MonoBehaviour
{

    public GameObject GetEffect = null;
    public GameObject DropEffect = null;

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
            GameObject sfx = Instantiate(DropEffect, transform.position, Quaternion.identity, GameObject.Find("GameManager").transform);
            AudioSource hiss = sfx.GetComponent<AudioSource>();
            float adj = Mathf.Round(Random.Range(-0.5f,0.25f) * 100) / 100;  
            hiss.pitch = 1 + adj;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("grab");
            GameManager.AddScore(1);
            OutsideSceneUI.instance.UpdateScore();
            GameObject sfx = Instantiate(GetEffect, transform.position, Quaternion.identity, GameObject.Find("GameManager").transform);
            AudioSource ding = sfx.GetComponent<AudioSource>();
            float adj = Mathf.Round(Random.Range(-0.15f,0.15f) * 100) / 100;  
            ding.pitch = 1 + adj;
            Destroy(this.gameObject);
        }
    }

}
