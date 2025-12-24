using System;
using UnityEngine;

public class SantaClaus : MonoBehaviour
{
    public static SantaClaus instance = null;
    public GameObject presentPrefab = null;
    public float waitTime = 5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }

    void Start()
    {
        if (!StuffManager.GotEmAll())
        {
            string nextPresentTime;
            DateTime sysnow = System.DateTime.Now;
            if (PlayerPrefs.HasKey("nextPresentTime"))
            {
                nextPresentTime = PlayerPrefs.GetString("nextPresentTime");
                Debug.Log("Time: " + sysnow.ToString("yyyy-MM-dd HH:mm:ss"));
                Debug.Log("saved nextPresentTime: " + nextPresentTime);
            }
            else
            {
                nextPresentTime = SetNextPresentTime(sysnow, -5);
            }

            if (sysnow >= DateTime.Parse(nextPresentTime))
            {
                Instantiate(
                    presentPrefab,
                    GameObject.Find("PresentWaypoint").transform.position,
                    Quaternion.identity
                );
                //presentPrefab.GetComponent<Rigidbody2D>().gravityScale = 0;
                //SetNextPresentTime(sysnow, waitTime);
            }
        }
    }

    public string SetNextPresentTime(DateTime inputTime, float offSet)
    {
        DateTime next = inputTime.AddSeconds(offSet);

        string nextString = next.ToString("yyyy-MM-dd HH:mm:ss");
        Debug.Log("Time: " + inputTime.ToString("yyyy-MM-dd HH:mm:ss"));
        Debug.Log("nextPresentTime: " + nextString);

        PlayerPrefs.SetString("nextPresentTime", nextString);
        return nextString;
    }
}
