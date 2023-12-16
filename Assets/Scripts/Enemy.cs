using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    
    private Transform _target;

    private void Update()
    {
        MoveToTarget();
    }

    public void Init(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
