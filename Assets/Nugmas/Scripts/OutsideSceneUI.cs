using TMPro;
using UnityEngine;

public class OutsideSceneUI : MonoBehaviour
{
    public static OutsideSceneUI instance;

    public TextMeshPro ScoreText = null;

    public TextMeshPro HighScoreText = null;

    [SerializeField]
    private Nug _nug;

    [SerializeField]
    private DoorUser _nugDoorUser;

    [SerializeField]
    private GameObject _title;

    [SerializeField]
    private GameObject _useDoorPrompt;

    /// <summary>
    /// Standard Unity function called once when the script instance first exists in runtime of the game. Called before Start.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        _title.SetActive(OutsideScene.IsFirstLoad());
    }

    void OnEnable()
    {
        _nug.OnMoved += HandleNugMoved;
    }

    void OnDisable()
    {
        _nug.OnMoved -= HandleNugMoved;
    }

    private void Update()
    {
        _useDoorPrompt.SetActive(_nugDoorUser != null && _nugDoorUser.CanUseDoor);
    }

    public void UpdateScore()
    {
        ScoreText.text = "Streak: " + GameManager.score.ToString();
        HighScoreText.text = "Best Streak: " + GameManager.instance.highScore.ToString();
    }

    private void HandleNugMoved()
    {
        _title.SetActive(false);
    }
}
