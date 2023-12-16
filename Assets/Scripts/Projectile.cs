using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private float _speed = 3f;

    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    private void Update()
    {
        MoveForward();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void MoveForward()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime, Space.World);
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return _waitForSeconds;
        Destroy();
    }
}
