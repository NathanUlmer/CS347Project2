using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 0.5f;
    public int damage = 1;

    //Bullet movement
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //Bullet Collision
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}
