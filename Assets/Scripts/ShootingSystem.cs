using System.Collections;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField, Min(0)] private float _bulletSpeed;
    [SerializeField, Min(0)] private float _shootingDelay;

    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bullet;

    private Transform _transform;

    private void Awake() =>
        _transform = transform;

    private void Start() =>
        StartCoroutine(Shoot(_shootingDelay));

    private IEnumerator Shoot(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Vector3 direction = (_target.position - _transform.position).normalized;

            Bullet bullet = Instantiate(_bullet, _transform.position + direction, Quaternion.identity);

            if (bullet.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.velocity = direction * _bulletSpeed;

            yield return wait;
        }
    }
}
