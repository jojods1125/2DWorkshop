using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public Rigidbody player;
    public Rigidbody self;
    public float maxDetectDistance = 10;
    public float speed = 3;

    private void Awake() 
    {
        //player = GameObject.Find("Zalde").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 playerLoc = player.position - gameObject.transform.position;
            playerLoc.y = 0;

            if (playerLoc.magnitude <= maxDetectDistance)
            {
                Quaternion direction;
                direction = Quaternion.LookRotation(playerLoc);
                gameObject.transform.rotation = direction;

                Vector3 vel = gameObject.transform.forward * speed;
                vel.y = self.velocity.y;
                self.velocity = vel;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("PlayerSword"))
        {
            Destroy(gameObject);
        }

    }
}
