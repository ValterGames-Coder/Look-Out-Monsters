using System.Collections;
using UnityEngine;

public class SlizenController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;

    private bool isGround;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatisGround;

    Vector2 EnemyPos;
    public float speed;
    GameObject player;

    public int health;

    public GameObject[] money;
    private int random;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    public void Damage(int d)
    {
        health -= d;

        if (health <= 0)
        {
            random = Random.Range(0, money.Length);
            Instantiate(money[random], gameObject.transform.position, Quaternion.identity);
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
    public void Jump()
    {
        if (isGround == true)
            if(Vector2.Distance(transform.position, player.transform.position) > 2)
                rb.velocity = Vector2.up * jumpForce;
    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRad, whatisGround);
        EnemyPos = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = new Vector2(EnemyPos.x, transform.position.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
            Jump();
        }
        if (collision.CompareTag("Platform"))
        {
            isGround = true;
            Jump();
        }
    }
}
