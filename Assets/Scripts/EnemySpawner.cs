using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform _target;

    private float _delay = 1f;
    private float _radius = 10.5f;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        InitEnemies();

        StartCoroutine(Spawn());
    }

    private void InitEnemies()
    {
        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
            enemy.Init(_target);
        }
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            var enemy = _enemies.FirstOrDefault(e => e.gameObject.activeSelf == false);
            if (enemy)
            {
                enemy.gameObject.SetActive(true);
                enemy.transform.position = SetEnemyPosition();
            }
            
            yield return _waitForSeconds;
        }
    }

    private Vector2 SetEnemyPosition()
    {
        float randomAngle = Random.Range(0f, 360f);

        float x = _radius * Mathf.Cos(Mathf.Deg2Rad * randomAngle);
        float y = _radius * Mathf.Sin(Mathf.Deg2Rad * randomAngle);

        return new Vector2(x, y);
    }
}
