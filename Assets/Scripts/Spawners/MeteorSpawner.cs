using UnityEngine;

public class MeteorSpawner : Spawner
{
    [SerializeField]
    private GameObject newMeteor = null;

    public override void Start()
    {
        timeOut = 3f;
        base.Start();
    }

    public override void Callback()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = (GameObject)Instantiate(newMeteor);

        anEnemy.transform.position = new Vector2(max.x + anEnemy.GetComponent<Renderer>().bounds.size.x, UnityEngine.Random.Range(min.y, max.y));
    }
}
