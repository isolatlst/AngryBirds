using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pig : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        Debug.Log(collision.relativeVelocity);
        if (collision.relativeVelocity.magnitude > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
