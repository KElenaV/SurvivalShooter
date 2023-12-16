using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private EnemyCollision[] _enemyCollision;
    [SerializeField] private TMP_Text _scoreDisplay;

    private int _score = 0;

    private void OnEnable()
    {
        ShowScore();

        foreach (var collision in _enemyCollision)
        {
            collision.EnemyKilled += OnEnemyKilled;
        }
    }

    private void OnDisable()
    {
        foreach (var collision in _enemyCollision)
        {
            collision.EnemyKilled -= OnEnemyKilled;
        }
    }

    private void OnEnemyKilled()
    {
        _score++;
        ShowScore();
    }

    private void ShowScore()
    {
        _scoreDisplay.text = $"Score: {_score}";
    }
}
