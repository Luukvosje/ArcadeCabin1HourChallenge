using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject shootPoint;

    public GameObject player2;
    public GameObject bullet;

    public float HP;

    public float moveSpeed;
    public float maxVelocity;
    public float turnSpeed = 5;

    public GameObject currentGun;
    public float gunDamage;
    public float bulletSpeed;
    public float fireSpeed;

    public bool canShoot;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        gunDamage = currentGun.GetComponent<Gun>().gunDamage;
        fireSpeed = currentGun.GetComponent<Gun>().fireSpeed;
        bulletSpeed = currentGun.GetComponent<Gun>().bulletSpeed;

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
          
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 270), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), turnSpeed * Time.deltaTime);
        }

        if (currentGun.name == "Sniper")
        {
            RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, shootPoint.transform.right);
            Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.right * 200, Color.red);
            if (hit.collider != null)
            {
                if (Input.GetKeyDown(KeyCode.R) && hit.collider.CompareTag("Player2"))
                {
                    player2.GetComponent<Player2>().HP -= gunDamage;
                }
            }
        }
        else if (Input.GetKey(KeyCode.R))
            {
             
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    canShoot = true;
                }
                if (canShoot)
                {
                    GameObject instantiated = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
                    instantiated.gameObject.transform.eulerAngles = new Vector3(0, 0, gameObject.transform.eulerAngles.z - 90);
                    instantiated.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
                timer = fireSpeed;
                    canShoot = false;
                }
     
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit");
        }
    }
 
}
