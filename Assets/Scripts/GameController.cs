using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
