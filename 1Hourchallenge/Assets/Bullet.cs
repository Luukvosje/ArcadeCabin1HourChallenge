using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public GameObject playerShot;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Walls"))
            Destroy(gameObject);
    }

}
