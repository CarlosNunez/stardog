using UnityEngine;

public class GameController : Timer
{
    [SerializeField]
    private float gameSpeedDelay = 5f;

    [SerializeField]
    private float gameSpeedStep = 0.2f;

    private float gameSpeed;

    public bool hasGameStarted { get; set; }

    public bool isGameOver { get; set; }

    public float GameSpeed
    {
        get
        {
            return gameSpeed;
        }
    }

    // Use this for initialization
    void Start()
    {
        gameSpeed = 1;
        timeOut = gameSpeedDelay;
        timeLeft = timeOut;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }

    public override void Callback()
    {
        gameSpeed += gameSpeedStep;
    }

    public override bool DoCycle()
    {
        return hasGameStarted;
    }
}
