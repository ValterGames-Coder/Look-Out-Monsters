using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    public int damage;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(damage);
            Destroy(gameObject);
        }

        SlizenController slizen = collision.GetComponent<SlizenController>();
        if (slizen != null)
        {
            slizen.Damage(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
