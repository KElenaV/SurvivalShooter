using UnityEngine;
using UnityEngine.Events;

public class EnemyCollision : MonoBehaviour
{
    public event UnityAction EnemyKilled;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Projectile projectile))
        {
            projectile.Destroy();
            EnemyKilled?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
