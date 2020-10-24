using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{

    public float speed = 5;

    public Rigidbody player;

    public float jumpHeight = 5;

    public int health = 1;

    public float invincibleTime = 5;

    public GameObject projectile;

    public float rateOfFire = 1;

    private float lastFireTime;

    private float lastHitTime;


    private void Start()
    {
        lastHitTime = -invincibleTime;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        player.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, player.velocity.y, player.velocity.z);


        if (player.velocity.x > 0)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        if (player.velocity.x < 0)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(-Vector3.right);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (GroundCheck())
            { 
                player.velocity = new Vector3(player.velocity.x, jumpHeight, player.velocity.z);
            }

        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > lastFireTime + rateOfFire)
            {
                GameObject ball = Instantiate(projectile);
                ball.transform.position = gameObject.transform.position + (gameObject.transform.forward * 1.1f);
                ball.GetComponent<Rigidbody>().AddForce((gameObject.transform.forward * 2 - gameObject.transform.up) * 300);
                lastFireTime = Time.time;
                Destroy(ball, 1.5f);
            }
        }
    }

    public void PlayerHit()
    {
        if (Time.time > lastHitTime + invincibleTime)
        {
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
            lastHitTime = Time.time;
        }
    }


    private bool GroundCheck()
    {
        float distance = 1.01f;

        Vector3 dir = new Vector3(0, -1, 0);

        return Physics.Raycast(player.position, dir, distance);

    }


    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.GetComponent<Enemy2D>() != null)
        {
            Debug.Log(other.name + " " + (player.position - other.transform.position).y);

            if ((player.position - other.transform.position).y > 1)
            {
                Destroy(other);
            }
            else
            {
                PlayerHit();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            health++;
            Destroy(other.gameObject);
        }
    }
}
