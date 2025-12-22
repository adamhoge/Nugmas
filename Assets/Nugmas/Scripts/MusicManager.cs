using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if(music.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
         DontDestroyOnLoad(this.gameObject);

    }

}


    