using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private int _currentPoint;
    public bool onBoard = false;

    private void FixedUpdate()
    {
        if (onBoard)
            MoveTrain();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    public void MoveTrain()
    {
        if (_currentPoint >= _points.Length)
            return;

        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)  //raggiungo il punto ed imposto il prossimo
        {
            _currentPoint++;
        }
    }

    public void StartTrain()
    {
        onBoard = true;
    }
    public void StopTrain()
    {
        onBoard = false;
    }
}
