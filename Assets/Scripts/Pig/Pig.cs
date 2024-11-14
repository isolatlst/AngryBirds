using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pig : MonoBehaviour
{
    [Header("Debug")] [SerializeField] private bool _isUndying;
    [SerializeField] private ParticleSystem _explosionTemplate;

    
    private IEnumerator Dead()
    {
        var explosion = Instantiate(_explosionTemplate, transform);
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
        Destroy(explosion);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 3f && !_isUndying)
        {
            StartCoroutine(Dead());
        }
    }
}