using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AstreoidSpawner astreoidSpawner;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] ScoreSystem scoreSystem;

    public void Endgame()
    {
        astreoidSpawner.enabled = false;
        gameOverText.text = "Your Score: " + scoreSystem.EndTimer().ToString();
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
