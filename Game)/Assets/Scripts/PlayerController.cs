using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class PlayerController : MonoBehaviour
{

    [Header("Бусты")]
    public GameObject Ammo;
    public GameObject MiniHilka;
    public GameObject Hilka;
    public GameObject ButtleSpeed;
    [Header("Звуки")]
    public GameObject uron;
    [Header("Панель")]
    public GameObject panel;
    public GameObject ClosePanel;
    bool apanel = false;
    [Header("Магазин")]
    public GameObject ShopButton;
    public GameObject shop;
    [Header("Канваз Буст")]
    public GameObject Speed;
    public GameObject JumpButtel;
    public GameObject ButtelJumpObject;

    [Header("Кровь")]
    public GameObject HP3;

    public Image SpeedBar;
    public Image JumpBar;

    [Header("Управление")]
    public float speed;
    public float jumpForse;
    private float moveInput;
    public int health = 10;
    [Header("Время")]
    public float timer;
    public float timerS;
    public float timerJ;
    public float timerSJ;
    [Header("Компоненты")]
    public Joystick joystick;
    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;

    [Header("Земля")]
    private bool isGround;
    public Transform feetPos;
    public float checkRad;
    public LayerMask whatisGround;
    public static bool diedbool = false;

    public Text MoneyText;
    public Text MoneyShopText;
    public Text HealthText;
    public int money;
    public int shopmoney;

    [Header("FireGun")]
    public GameObject Pistol;
    public GameObject AK;
    public GameObject UZI;

    [Header("Эффект")]
    public GameObject Attakk, SpeedBust, JumpBust;

    public bool SpeedButtel = false;
    public bool Jumpbuttel = false;

    public Gradient gradient;

    int PlayerObject, PlatformObject;
    bool JumpOffPlatform = false;

    private bool _isVibration = true;
    private RewardedAd rewarded;
    private const string rewardedUtils = "ca-app-pub-4721480223801357/6355503010";

    private int whathealth = 0;

    public Button secondhealtbutton;

    private void OnEnable()
    {
        rewarded = new RewardedAd(rewardedUtils);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewarded.LoadAd(adRequest);

        rewarded.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void OnDisable()
    {
        rewarded.OnUserEarnedReward -= HandleUserEarnedReward;
    }

    public void HandleUserEarnedReward(object sender, Reward agrs){
        if(whathealth == 0){
            StartCoroutine(SecondHealth());
            whathealth = 1;
        }
    }
    public void ShowAd(){
        if(rewarded.IsLoaded()) rewarded.Show();
    }

    IEnumerator SecondHealth(){
        gameObject.tag = "Untagged";
        panel.SetActive(false);
        apanel = false;
        health = 10;
        yield return new WaitForSeconds(3f);
        gameObject.tag = "Player";
    }
    void Start()
    {
        if(PlayerPrefs.GetInt("Vibrate") == 0) _isVibration = false;
        else if(PlayerPrefs.GetInt("Vibrate") == 1) _isVibration = true;
        Pistol.SetActive(true);
        AK.SetActive(false);
        UZI.SetActive(false);
        timer = timerS;
        timerJ = timerSJ;
        money = 0;
        GameObject.Find("Health").GetComponent<Image>().color = gradient.Evaluate(1f);
        StartCoroutine("Animation");
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        PlayerObject = LayerMask.NameToLayer("Player");
        PlatformObject = LayerMask.NameToLayer("Platform");
    }

    void FixedUpdate()
    {
        MoneyText.text = money.ToString();
        HealthText.text = "HP: " + health;
        MoneyShopText.text = money.ToString();
        GameObject.Find("Health").GetComponent<Image>().color = gradient.Evaluate(GameObject.Find("Health").GetComponent<Image>().fillAmount);
        if (GameObject.Find("Health").GetComponent<Image>().fillAmount <= 0.3f)
        {
            HP3.SetActive(true);
        }
        else
        {
            HP3.SetActive(false);
        }
        moveInput = joystick.Horizontal * speed;
        rb.velocity = new Vector2(moveInput, rb.velocity.y);
        if (moveInput != 0)
            anim.SetBool("Walk", true);
        else if (moveInput == 0)
            anim.SetBool("Walk", false);
        if (moveInput > 0)
            transform.localRotation = Quaternion.Euler(0f, 0f, 0);
        if ( moveInput < 0)
            transform.localRotation = Quaternion.Euler(0f, 180f, 0);
        if (apanel == true)
        {
            Time.timeScale = 0;
        }
    }

    //покупки
    public void BuyHilka(int price)
    {
        if (money >= price)
        {
            Instantiate(Hilka, new Vector2(shop.transform.position.x, shop.transform.position.y), Quaternion.identity);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyAK(int price)
    {
        if (money >= price)
        {
            Pistol.SetActive(false);
            UZI.SetActive(false);
            AK.SetActive(true);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyUZI(int price)
    {
        if (money >= price)
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            UZI.SetActive(true);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyMiniHilka(int price)
    {
        if (money >= price)
        {
            Instantiate(MiniHilka, new Vector2(shop.transform.position.x, shop.transform.position.y), Quaternion.identity);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyButtelSpeed(int price)
    {
        if (money >= price)
        {
            Instantiate(ButtleSpeed, new Vector2(shop.transform.position.x, shop.transform.position.y), Quaternion.identity);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyButtelJump(int price)
    {
        if (money >= price)
        {
            Instantiate(JumpButtel, new Vector2(shop.transform.position.x, shop.transform.position.y), Quaternion.identity);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }

    public void BuyAmmo(int price)
    {

        if (money >= price)
        {
            Instantiate(Ammo, new Vector2(shop.transform.position.x, shop.transform.position.y), Quaternion.identity);
            money -= price;
            MoneyShopText.text = money.ToString();
            MoneyText.text = money.ToString();
        }
    }
    //конец покупок

    void Timer()
    {
        speed = 10;
        Speed.SetActive(true); // это объект, который держит эту картинку

        if (timer <= 0)
        {
            Instantiate(SpeedBust, transform.position, Quaternion.identity);
            speed = 5;
            timer = timerS;
            SpeedButtel = false;
            Speed.SetActive(false);
            SpeedBar.fillAmount = 1; // когда скорость закончилась, полоска становится полной
        }
        else
        {
            SpeedBar.fillAmount = timer / timerS; // то самое уменьшение
            timer -= Time.deltaTime;
        }
    }

    void TimerJump()
    {
        jumpForse = 20;
        ButtelJumpObject.SetActive(true); // это объект, который держит эту картинку
        if (timerJ <= 0)
        {
            Instantiate(JumpBust, transform.position, Quaternion.identity);
            jumpForse = 15;
            timerJ = timerSJ;
            Jumpbuttel = false;
            ButtelJumpObject.SetActive(false);
            JumpBar.fillAmount = 1; // когда скорость закончилась, полоска становится полной
        }
        else
        {
            JumpBar.fillAmount = timerJ / timerSJ; // то самое уменьшение
            timerJ -= Time.deltaTime;
        }
    }
    void Update()
    {
        if(SpeedButtel == true)
        {
            Timer();
        }
        if (Jumpbuttel == true)
        {
            TimerJump();
        }
        if (Jumpbuttel == true && SpeedButtel == true)
        {
            ButtelJumpObject.GetComponent<Animator>().SetBool("2", true);
        }
        else if(Jumpbuttel == true && SpeedButtel == false)
        {
            ButtelJumpObject.GetComponent<Animator>().SetBool("2", false);
        }
        if (health > 10)
            health = 10;


        if (health <= 0)
        {
            Deid();
            health = 0;
        }
        float verticalMove = joystick.Vertical;
        isGround = Physics2D.OverlapCircle(feetPos.position, checkRad, whatisGround);
        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(PlayerObject, PlatformObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(PlayerObject, PlatformObject, false);
        }
        if(verticalMove < -0.5f)
        {
            StartCoroutine("JumpOff");
        }
    }
    IEnumerator Animation()
    {
        GameObject.Find("One1").GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        GameObject.Find("two2").GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        GameObject.Find("three3").GetComponent<Animation>().Play();
        yield return new WaitForSeconds(1f);
        GameObject.Find("FIGHT!").GetComponent<Animation>().Play();
        ClosePanel.SetActive(false);
    }

    public void PlatformJump()
    {
        StartCoroutine("JumpOff");
    }
    public IEnumerator JumpOff()
    {
        JumpOffPlatform = true;
        Physics2D.IgnoreLayerCollision(PlayerObject, PlatformObject, true);
        yield return new WaitForSeconds(2f);
        Physics2D.IgnoreLayerCollision(PlayerObject, PlatformObject, false);
        JumpOffPlatform = false;
    }

    public void Jump()
    {
        if (isGround == true)
            rb.velocity = Vector2.up * jumpForse;
    }

    public void Deid()
    {
        if(whathealth == 1) secondhealtbutton.GetComponent<Button>().interactable = false;
        panel.SetActive(true);
        apanel = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shop"))
        {
            ShopButton.SetActive(false);
        }

        if (collision.CompareTag("Ladder"))
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            Deid();
        }

        if (collision.CompareTag("Shop"))
        {
            ShopButton.SetActive(true);
        }

        if (collision.CompareTag("Batut"))
        {
            rb.velocity = Vector2.up * 20;
        }

        if (collision.tag == "Ladder")
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * 5, ForceMode2D.Impulse);
        }

        if (collision.CompareTag("ButtelSpeed"))
        {
            SpeedButtel = true;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ButtelJump"))
        {
            Jumpbuttel = true;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Vrag"))
        {
            health--;
            Instantiate(Attakk, transform.position, Quaternion.identity);
            if(PlayerPrefs.GetInt("Vibrate") == 1) Handheld.Vibrate();
            rb.velocity = new Vector2(Random.Range(5, 7), Random.Range(5, 7));
            Instantiate(uron, gameObject.transform.position, Quaternion.identity);
        }
        GameObject.Find("Health").GetComponent<Image>().fillAmount = health / 10f;

        if (collision.CompareTag("Vrag2"))
        {
            health -= 2;
            Instantiate(Attakk, transform.position, Quaternion.identity);
            if(PlayerPrefs.GetInt("Vibrate") == 1) Handheld.Vibrate();
            Camera.main.GetComponent<Animator>().SetBool("Uron?", true);
            rb.velocity = new Vector2(Random.Range(5, 7), Random.Range(5, 7));
            Instantiate(uron, gameObject.transform.position, Quaternion.identity);
        }
        GameObject.Find("Health").GetComponent<Image>().fillAmount = health / 10f;

        if (collision.CompareTag("Hilka"))
        {
            if(health != 10)
            {
                health += 5;
                GameObject.Find("Health").GetComponent<Image>().fillAmount = health / 10f;
                Destroy(collision.gameObject);
            }

        }

        if (collision.CompareTag("Minihilka"))
        {
            if(health != 10)
            {
                health += 2;
                GameObject.Find("Health").GetComponent<Image>().fillAmount = health / 10f;
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("PlusBullet"))
        {
            if (GameObject.FindGameObjectWithTag("Oryz").GetComponent<FireShoop>().bullet != GameObject.FindGameObjectWithTag("Oryz").GetComponent<FireShoop>().shoot && GameObject.FindGameObjectWithTag("Oryz").GetComponent<FireShoop>().Shootihg == true)
            {
                GameObject.FindGameObjectWithTag("Oryz").GetComponent<FireShoop>().bullet += 5;
                Destroy(collision.gameObject);
            }
        }

        if (collision.CompareTag("Money"))
        {
            money++;
            Destroy(collision.gameObject);
        }
    }
}
