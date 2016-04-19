using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int movementSpeed = 4;

    [SerializeField]
    private float rotationSpeed = 8;

    private int currentSpeed;

    private bool isGoingUp;

    public Rigidbody2D MyRigidBody { get; set; }

    private GameController gameController;

    private AttackController attackSpawner;

    private Renderer shield;

    private bool isShieldActive = false;

    public Stats myStats;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        attackSpawner = GameObject.FindWithTag("AttackSpawner").GetComponent<AttackController>();
        shield = GameObject.FindWithTag("Shield").GetComponent<Renderer>();

        shield.enabled = false;

        currentSpeed = movementSpeed;
        isGoingUp = true;
        MyRigidBody = GetComponent<Rigidbody2D>();

        myStats = GameSingleObject.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            ToggleDirection();

            gameController.hasGameStarted = true;
        }
    }

    void FixedUpdate()
    {
        CheckBounds();

        if (!gameController.hasGameStarted)
        {
            return;
        }

        if (isGoingUp)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 15), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -15), Time.deltaTime * rotationSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Meteor")
        {
            collider.gameObject.SendMessage("Delete");

            if (isShieldActive)
            {
                Nerf(global::Bluff.SHIELD);
            }
            else
            {
                Die();
            }
        }
        else if (collider.gameObject.tag == "PowerUp")
        {
            myStats.PowerUpsTaken += 1;
            collider.gameObject.SendMessage("Give", this);
        }
    }

    private void CheckBounds()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y + GetHeight() / 2 < min.y || transform.position.y - GetHeight() / 2 > max.y)
        {
            Die();
        }
    }

    private void ToggleDirection()
    {
        isGoingUp = !isGoingUp;
        currentSpeed *= -1;
        MyRigidBody.velocity = new Vector2(0, currentSpeed);
    }

    private void Die()
    {
        int currentScore = GameObject.FindWithTag("Score").GetComponent<ScoreController>().getScore();

        myStats.BestScore = currentScore > myStats.BestScore ? currentScore : myStats.BestScore;
        myStats.GlobalScore += currentScore;
        myStats.Deaths += 1;

        GameSingleObject.SaveData(myStats);

        gameController.hasGameStarted = false;
        gameController.isGameOver = true;

        Destroy(this.gameObject);
    }

    public float GetHeight()
    {
        return GetComponent<Renderer>().bounds.size.y;
    }

    public void Bluff(Bluff bluff)
    {
        switch (bluff)
        {
            case global::Bluff.ATTACK:
                attackSpawner.startAttack();
                break;
            case global::Bluff.SHIELD:
                isShieldActive = true;
                shield.enabled = true;
                break;
            default:
                break;
        }
    }

    public void Nerf(Bluff bluff)
    {
        switch (bluff)
        {
            case global::Bluff.ATTACK:
                attackSpawner.isAttacking = false;
                break;
            case global::Bluff.SHIELD:
                isShieldActive = false;
                shield.enabled = false;
                myStats.ShieldsDestroyed += 1;
                break;
            default:
                break;
        }
    }
}
