using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;

    private GameController gameController;

    private float spawnY;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        spawnY = transform.position.y;
    }

    void FixedUpdate()
    {
        float newX = transform.position.x - movementSpeed * Time.deltaTime * gameController.GameSpeed;
        float newY = Mathf.Sin(transform.position.x) * 3 + spawnY;

        transform.position = new Vector2(newX, newY);

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

    public virtual void Give(Player player)
    {
        Debug.Log("This should be overridden");
    }
}
