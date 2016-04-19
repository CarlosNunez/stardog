using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    void goToGame()
    {
        goTo("Game");
    }

    void goToStats()
    {
        goTo("Stats");
    }

    void goToMenu()
    {
        goTo("Menu");
    }

    private void goTo(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
