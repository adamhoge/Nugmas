using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource _musicSource = null;

    public static MusicManager Instance = null;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public void ToggleMusic()
    {
        _musicSource.enabled = !_musicSource.enabled;
    }
}
