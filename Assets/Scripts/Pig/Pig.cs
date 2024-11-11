using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pig : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        //Перенести столкновение в птиц
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.relativeVelocity);
        if (collision.relativeVelocity.magnitude > 3f)
        {
            Destroy(gameObject);
        }
    }
}
// private void OnCollisionEnter2D(Collision2D other)
// {
//     if (other.gameObject.TryGetComponent<Pig>(out var pig))
//     {
//         OnBirdCollision?.Invoke(pig, other.relativeVelocity.magnitude);
//     }
// }