using UnityEngine;

public class Present : MonoBehaviour
{
    public GameObject GetEffect = null;
    public GameObject DropEffect = null;

    public GameObject ShowEffect = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Present Trigger");
        Debug.Log(collision.tag);
        if (collision.tag == "Ground")
        {
            Debug.Log("crash");
            if (GameManager.instance)
            {
                GameManager.ResetScore();
            }
            if (OutsideSceneUI.instance)
            {
                OutsideSceneUI.instance.UpdateScore();
            }

            GameObject sfx = Instantiate(DropEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("unwrap!");
            if (GameManager.instance)
            {
                GameManager.AddScore(1);
            }
            if (OutsideSceneUI.instance)
            {
                OutsideSceneUI.instance.UpdateScore();
            }
            if (SantaClaus.instance)
            {
                Debug.Log("Calling Santa.");
                SantaClaus.instance.SetNextPresentTime(
                    System.DateTime.Now,
                    SantaClaus.instance.waitTime
                );
            }

            ItemData gottenItem = StuffManager.AddRandomItem();

            if (!(gottenItem == null))
            {
                ParticleSystem presentPS = ShowEffect.GetComponent<ParticleSystem>();
                presentPS.textureSheetAnimation.SetSprite(0, gottenItem.Sprite);
                Instantiate(ShowEffect, transform.position, Quaternion.identity);
            }

            GameObject sfx = Instantiate(GetEffect, transform.position, Quaternion.identity);
            AudioSource ding = sfx.GetComponent<AudioSource>();
            float adj = Mathf.Round(Random.Range(0f, 0.3f) * 100) / 100;
            ding.pitch = 1 + adj;
            Debug.Log(ding.pitch);
            Destroy(this.gameObject);
        }
    }
}
