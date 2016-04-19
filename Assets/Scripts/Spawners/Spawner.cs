using UnityEngine;

public abstract class Spawner : Timer
{
    protected GameController gameController;

    protected float startingTimeOut;

    // Use this for initialization
    public virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        timeLeft = timeOut;
        startingTimeOut = timeOut;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        float spawnTimer = startingTimeOut - Mathf.Log10(startingTimeOut * Mathf.Pow(gameController.GameSpeed, gameController.GameSpeed));
        timeOut = spawnTimer > 0.3f ? spawnTimer : 0.3f;
    }

    public override bool DoCycle()
    {
        return gameController.hasGameStarted;
    }
}
