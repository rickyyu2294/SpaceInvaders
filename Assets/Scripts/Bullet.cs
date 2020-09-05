using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 60;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" || collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
