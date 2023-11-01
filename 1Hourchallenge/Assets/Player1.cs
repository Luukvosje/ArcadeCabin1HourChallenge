using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject shootPoint;

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

        RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, transform.right);
        Debug.DrawRay(shootPoint.transform.position, transform.right * 200,Color.red);
        if (hit.collider != null)
        {
            Debug.DrawRay(shootPoint.transform.position, hit.point, Color.yellow);
        }
    }
}
