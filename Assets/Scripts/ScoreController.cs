using UnityEngine;

public class ScoreController : Timer
{
    [SerializeField]
    private int textScale = 10;

    private GUIText scoreText;

    private int score;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        timeOut = 1f;
        timeLeft = timeOut;
        score = 0;
        scoreText = GetComponent<GUIText>();
        scoreText.fontSize = Mathf.Min(Screen.height, Screen.width) / textScale;
        UpdateScore();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public override void Callback()
    {
        AddScore();
    }

    public void AddScore()
    {
        score += 1;
        UpdateScore();
    }

    public override bool DoCycle()
    {
        return gameController.hasGameStarted;
    }

    public int getScore()
    {
        return score;
    }
}
