using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 3;

    private GameController gameController;

    private ScoreController scoreController;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        scoreController = GameObject.FindWithTag("Score").GetComponent<ScoreController>();
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime * gameController.GameSpeed);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x - GetWidth())
        {
            Destroy(gameObject);
        }
    }

    public float GetWidth()
    {
        return GetComponent<Renderer>().bounds.size.x;
    }

    public void Delete()
    {
        Destroy(gameObject);
        scoreController.AddScore();

        GameObject.FindWithTag("Player").GetComponent<Player>().myStats.MeteorsKilled += 1;
    }
}
