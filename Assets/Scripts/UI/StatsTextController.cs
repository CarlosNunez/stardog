using UnityEngine;
using UnityEngine.UI;

public class StatsTextController : MonoBehaviour
{
    private Text statsText;

    // Use this for initialization
    void Start()
    {
        statsText = GetComponent<Text>();
        UpdateText();
    }

    private void UpdateText()
    {
        Stats myStats = GameSingleObject.LoadData();
        statsText.text = "\n" +
            "Global Score: " + myStats.GlobalScore + "\n" +
            "You Best Run: " + myStats.BestScore + "\n" +
            "Meteors Killed: " + myStats.MeteorsKilled + "\n" +
            "Ships Destroyed: " + myStats.Deaths + "\n" +
            "Shields Used: " + myStats.ShieldsDestroyed + "\n" +
            "PowerUps Taken: " + myStats.PowerUpsTaken + "\n" +
             "\n";
    }
}
