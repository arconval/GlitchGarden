using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float damage = 100f;

    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, 10));
    }

    private void OnTriggerEnter2D (Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attaker>();

        if (health&&attacker)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
