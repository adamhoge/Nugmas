using UnityEngine;

public class Present : MonoBehaviour
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
        Debug.Log("Present Trigger");
        Debug.Log(collision.tag);
        if (collision.tag == "Ground")
        {
            Debug.Log("crash");
            GameManager.ResetScore();
            OutsideSceneUI.instance.UpdateScore();
            GameObject sfx = Instantiate(DropEffect, transform.position, Quaternion.identity, GameObject.Find("GameManager").transform);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("unwrap!");
            GameManager.AddScore(1);

            StuffManager.AddRandomItem();
            
            OutsideSceneUI.instance.UpdateScore();
            GameObject sfx = Instantiate(GetEffect, transform.position, Quaternion.identity, GameObject.Find("GameManager").transform);
            AudioSource ding = sfx.GetComponent<AudioSource>();
            float adj = Mathf.Round(Random.Range(0f,0.3f) * 100) / 100;  
            ding.pitch = 1 + adj;
            Debug.Log(ding.pitch);
            Destroy(this.gameObject);
        }
    }

}
