using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Projectile[] _projectiles;
    [SerializeField] private Transform _shootPoint;

    private Camera _camera;

    public event UnityAction GameOver;

    private void Start()
    {
        _camera = Camera.main;

        foreach (var projectile in _projectiles)
        {
            projectile.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        RotateToMousePosition();

        if (Input.GetMouseButtonDown(0))
            TryShoot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
            GameOver?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void RotateToMousePosition()
    {
        Vector2 direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.up = direction;
    }

    private void TryShoot()
    {
        var projectile = _projectiles.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (projectile)
        {
            projectile.gameObject.SetActive(true);
            projectile.transform.SetPositionAndRotation(_shootPoint.position, _shootPoint.rotation);
        }
    }
}
