using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.GetComponent<Enemy2D>() != null)
        {
            Destroy(other);
            Destroy(gameObject);
        }
    }
}
