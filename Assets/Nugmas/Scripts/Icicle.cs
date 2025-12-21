using UnityEngine;

public class Icicle : MonoBehaviour
{

    public GameObject HitEffect = null;

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
        Debug.Log("Icicle Trigger");
        Debug.Log(collision.tag);
        if (collision.tag == "Ground")
        {
            Debug.Log("shatter");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ouchies");
            GameManager.ResetScore();
            OutsideSceneUI.instance.UpdateScore();
            GameObject sfx = Instantiate(HitEffect, transform.position, Quaternion.identity, GameObject.Find("GameManager").transform);
            Destroy(this.gameObject);
        }
    }

}
