using UnityEngine;

public class PowerUpSpawner : Spawner
{
    [SerializeField]
    private GameObject[] powerUps = null;

    public override void Start()
    {
        timeOut = 10f;
        base.Start();
    }

    public override void Callback()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject newPowerUp = powerUps[Random.Range(0, powerUps.Length)];

        GameObject anEnemy = (GameObject)Instantiate(newPowerUp);

        anEnemy.transform.position = new Vector2(max.x + anEnemy.GetComponent<Renderer>().bounds.size.x, UnityEngine.Random.Range(min.y, max.y));
    }
}
