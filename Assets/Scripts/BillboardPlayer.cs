using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardPlayer : MonoBehaviour
{
    public GameObject parent;
    public Sprite normalSprite;
    public Sprite poweredSprite;

    void Update()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(position, Vector3.up);

        if (parent.transform.rotation.eulerAngles.y < 180)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = false;


        if (parent.GetComponent<Player2D>().health > 1)
            gameObject.GetComponent<SpriteRenderer>().sprite = poweredSprite;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }
}
