using UnityEngine;

public class GameOverTextController : Timer
{
    [SerializeField]
    private int textScale = 10;

    private GUIText gameOverText;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        timeOut = 2f;
        timeLeft = timeOut;

        gameOverText = GetComponent<GUIText>();
        gameOverText.fontSize = Mathf.Min(Screen.height, Screen.width) / textScale;
        gameOverText.enabled = false;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (gameController.isGameOver)
        {
            gameOverText.enabled = true;
            gameOverText.text = "You've lost";
        }
        base.Update();
    }

    public override bool DoCycle()
    {
        return gameController.isGameOver;
    }

    public override void Callback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
