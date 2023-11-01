using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject shootPoint;

    public GameObject player1;

    public float HP;

    public float moveSpeed;
    public float maxVelocity;
    public float turnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 270), turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), turnSpeed * Time.deltaTime);
        }

        RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, shootPoint.transform.right);
        Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.right * 200, Color.red);
        if (hit.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.Alpha7) && hit.collider.CompareTag("Player1"))
            {
                player1.GetComponent<Player1>().HP -= 10;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP -= player1.GetComponent<Player1>().gunDamage;
            Destroy(collision.gameObject);
            Debug.Log("hit");
        }
    }

}
