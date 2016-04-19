using UnityEngine;

public class SplashTextController : MonoBehaviour
{
    [SerializeField]
    private int textScale = 10;

    private GUIText splashText;

    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        splashText = GetComponent<GUIText>();
        splashText.fontSize = Mathf.Min(Screen.height, Screen.width) / textScale;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.hasGameStarted)
        {
            Destroy(this.gameObject);
        }
    }
}
