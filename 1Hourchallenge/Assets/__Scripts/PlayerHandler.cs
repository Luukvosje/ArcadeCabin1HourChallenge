using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] private Player player;

    [Header("KeyBinds")]

    [SerializeField] private KeyCode MoveUp;
    [SerializeField] private KeyCode MoveLeft;
    [SerializeField] private KeyCode MoveDown;
    [SerializeField] private KeyCode MoveRight;
    [SerializeField] private KeyCode Shoot;

    [Header("Weapons")]

    private List<GameObject> shootpoints = new List<GameObject>();
    [SerializeField] private Gun currentGun;

    private float bulletSpeed;
    private float fireRate;
    private bool canShoot;
    private float shootTimer;
    private bool hittingWall;



    [Header("Sprites")]

    [SerializeField] private SpriteRenderer weaponHolder;
    [SerializeField] private SpriteRenderer helmetHolder;
    [SerializeField] private SpriteRenderer chestPlateHolder;

    [Header("Stats")]

    public float health;
    public float speed;
    private float maxHealth;

    [Range(0f, 10f)]
    [SerializeField] private float moveSpeed;


    [Header("UI")]
    public Image ammoImage;
    public Image healthImage;
    public TextMeshProUGUI livesText;



    private float maxVelocity = 5f;
    private float turnSpeed = 7f;
    private Rigidbody2D rb;

    //assigns the components
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTimer = fireRate;
    }

    private void Start()
    {
        //resets the UI at the start of the game.
        livesText.text = player._Lives + " ";
        health = maxHealth;
    }

    private void Update()
    {
        Movement();
        Shooting();
    }

    //Handles the movement
    #region Movement
    private void Movement()
    {
        Vector2 inputDirection = Vector2.zero;

        if (Input.GetKey(MoveUp))
        {
            inputDirection += Vector2.up;
        }
        if (Input.GetKey(MoveLeft))
        {
            inputDirection += Vector2.left;
        }
        if (Input.GetKey(MoveDown))
        {
            inputDirection += Vector2.down;
        }
        if (Input.GetKey(MoveRight))
        {
            inputDirection += Vector2.right;
        }

        if (inputDirection != Vector2.zero)
        {
            Move(inputDirection);
            Rotate(inputDirection);
        }
    }

    private void Move(Vector2 inputDirection)
    {
        Vector2 force = inputDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    private void Rotate(Vector2 inputDirection)
    {
        float targetAngle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
    }

    #endregion

    //Handles the shooting
    #region Shooting
    private void Shooting()
    {
        shootTimer -= Time.deltaTime;
        ammoImage.fillAmount = 1 - (shootTimer / fireRate);
        if (shootTimer < 0)
        {
            canShoot = true;
        }
        if (Input.GetKey(Shoot) && !hittingWall)
        {

            if (canShoot)
            {
                foreach (var shootpoint in shootpoints)
                {
                    shootTimer = fireRate;
                    GameObject bullet = Instantiate(GameManager.Instance.Bullet, shootpoint.transform.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().playerShot = this.gameObject;
                    bullet.GetComponent<Bullet>().damage = currentGun.gunDamage;
                    bullet.gameObject.transform.eulerAngles = new Vector3(0, 0, shootpoint.transform.eulerAngles.z - 90);
                    bullet.GetComponent<Rigidbody2D>().AddForce(shootpoint.transform.right * bulletSpeed, ForceMode2D.Impulse);

                    canShoot = false;
                }
            }
        }
        if (shootpoints.Count <= 0)
            Debug.Log("Add Shootpoints in the Gun ScriptableObject");
    }
    #endregion
    #region
    //Equiping armor and all the setttings before the game starts 
    public void EquipInGameArmor(Player player)
    {
        health = player._Health;
        maxHealth = player._Health;

        speed = player._Speed;
        moveSpeed = (speed / 100) * 5;

        weaponHolder.sprite = player.weapon.inGameSprite;
        helmetHolder.sprite = player.Helmet.inGameSprite;
        chestPlateHolder.sprite = player.ChestPlate.inGameSprite;

        currentGun = player.weapon;
        fireRate = currentGun.fireSpeed;
        bulletSpeed = currentGun.bulletSpeed;
        for (int i = 0; i < currentGun.shootPoints.Count; i++)
        {
            GameObject tmpShootPoint = Instantiate(GameManager.Instance.ShootPoint, transform.position, Quaternion.identity);
            tmpShootPoint.transform.parent = transform;
            tmpShootPoint.transform.localPosition = currentGun.shootPoints[i];
            tmpShootPoint.transform.localEulerAngles = new Vector3(0, 0, currentGun.shootPointAngle[i]);
            shootpoints.Add(tmpShootPoint);
        }
    }
    #endregion

    //Checkign if player is against wall to stop shootingg
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("HittingWall");
            hittingWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("LeavingWall");
            hittingWall = false;
        }
    }


    //Health Handling
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.GetComponent<Bullet>().playerShot != this.gameObject)
            {

                health -= collision.gameObject.GetComponent<Bullet>().damage;
                Destroy(collision.gameObject);

                GameObject tmpBlood = Instantiate(GameManager.Instance.BloodEffect, transform.position, Quaternion.identity);
                Destroy(tmpBlood, 3);

                healthImage.fillAmount = (health / maxHealth);

                if (health <= 0)
                {
                    player._Lives--;
                    livesText.text = player._Lives + " ";
                    health = maxHealth;
                    Debug.Log(health);
                    healthImage.fillAmount = 1;
                    if (player._Lives <= 0)
                    {
                        SceneManager.LoadScene(0);
                    }
                }
            }
        }
    }
}
