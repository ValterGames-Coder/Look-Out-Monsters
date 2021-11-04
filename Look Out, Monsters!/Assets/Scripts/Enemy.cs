using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("GameObjects")] GameObject player;
    public GameObject HealthBar;
    public GameObject uron;
    public GameObject spawnhilka;
    public GameObject[] money;

    Vector2 EnemyPos;
    public float jumpForse;
    public bool PlayerDis;

    public int damage;
    public int health = 5;
    private int random;

    private bool isGround;
    bool isPlatform;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatisGround;

    int EnemyObject, PlatformObject;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        EnemyObject = LayerMask.NameToLayer("Enemy");
        PlatformObject = LayerMask.NameToLayer("Platform");
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


    IEnumerator Red()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

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

    void Die(){
        Destroy(gameObject);
    }

    public void Jump()
    {
        if (isGround == true)
            rb.velocity = Vector2.up * jumpForse;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            Jump();
        if (collision.CompareTag("Batut"))
        {
            rb.velocity = Vector2.up * 20;
        }        if (collision.CompareTag("Batut"))
        {
            rb.velocity = Vector2.up * 20;
        }
        if (collision.CompareTag("Platform"))
            isPlatform = true;
        if (collision.gameObject.tag == "Player")
            PlayerDis = true;
        if(collision.CompareTag("Bullet"))
        {
            StartCoroutine("Red");
            Instantiate(uron, gameObject.transform.position, Quaternion.identity);
        }
        if (collision.CompareTag("Platform"))
            isPlatform = true;
        if (collision.gameObject.tag == "Player")
            PlayerDis = true;
        if(collision.CompareTag("Bullet"))
        {
            StartCoroutine("Red");
            Instantiate(uron, gameObject.transform.position, Quaternion.identity);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            Jump();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
            isPlatform = false;
    }

}
