using UnityEngine;

public class AttackController : Timer
{
    [SerializeField]
    private GameObject fire = null;

    private GameController gameController;

    private float attackDuration = 3f;

    private float attackTimeLeft;

    public bool isAttacking { get; set; }

    // Use this for initialization
    public virtual void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        timeOut = 0.4f;
        timeLeft = timeOut;
        isAttacking = false;
    }

    public override void Update()
    {
        base.Update();

        attackTimeLeft -= Time.deltaTime;

        if (attackTimeLeft < 0)
        {
            isAttacking = false;
        }
    }

    public override void Callback()
    {
        GameObject newFire = (GameObject)Instantiate(fire);
        newFire.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public override bool DoCycle()
    {
        return gameController.hasGameStarted && isAttacking;
    }

    public void startAttack()
    {
        attackTimeLeft = attackDuration;
        isAttacking = true;
    }
}
