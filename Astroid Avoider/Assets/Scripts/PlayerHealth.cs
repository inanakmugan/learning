using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameOverHandler gameOverHandler;

    public void Crash()
    {
        gameOverHandler.Endgame();
        gameObject.SetActive(false);
    }
}
