using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{

    public float speed = 50;
    public Sprite deadAlien;
    public GameObject bullet;
    public float minFireWaitTime = 2.0F;
    public float maxFireWaitTime = 6.0F;
    public float baseFireWaitTime = 1.0F;
    

    private Rigidbody2D rigidBody;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(1, 0) * speed;

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireWaitTime, maxFireWaitTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        else if (collision.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }
        else if (collision.gameObject.name == "BottomWall" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (!isDead)
            {
                //SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
                GetComponent<SpriteRenderer>().sprite = deadAlien;
                GameManager.Instance.EnemyKilled();
                isDead = true;

                Destroy(gameObject, 1.5F);
            }
        }


    }

    void Turn (int direction)
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            var rb = enemy.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(speed * direction, 0);
        }

        
    }

    void MoveDown()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            enemy.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y - 2.5F);

        }
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > baseFireWaitTime && !isDead)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireWaitTime, maxFireWaitTime);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
