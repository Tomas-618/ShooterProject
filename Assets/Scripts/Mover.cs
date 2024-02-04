using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;

    [SerializeField] private Transform[] _arrivePoints;

    private Transform _transform;
    private int _currentArrivePointIndex;

    private void Reset() =>
        _speed = 0;

    private void Awake() =>
        _transform = transform;

    private void Update() =>
        Move();

    private void Move()
    {
        Transform currentArrivePoint = _arrivePoints[_currentArrivePointIndex];

        _transform.position = Vector3.MoveTowards(_transform.position, currentArrivePoint.position, _speed * Time.deltaTime);

        if (_transform.position == currentArrivePoint.position)
            ChangeArrivePoint();
    }

    private Vector3 ChangeArrivePoint()
    {
        _currentArrivePointIndex++;

        if (_currentArrivePointIndex == _arrivePoints.Length)
            _currentArrivePointIndex = 0;

        Vector3 arrivePointPosition = _arrivePoints[_currentArrivePointIndex].position;

        LookAtArrivePoint(arrivePointPosition);

        return arrivePointPosition;
    }

    private void LookAtArrivePoint(in Vector3 arrivePointPosition) =>
        _transform.LookAt(arrivePointPosition);
}
