using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public int maxHealth = 10;
    public int currentHealth;
    public bool running = true;
    public HealthBarController healthBar;
    public GameObject bulletPrefab;
    private GameObject bullet;
    private Animator anim;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Enemy approaches when they see the player
        if(distance <= lookRadius)
        {
            running = true;
            agent.SetDestination(target.position);

            //Enemy shoots when the player is in range
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
                running = false;
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if(Physics.SphereCast(ray, 0.1f, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerController>())
                    {
                        if(bullet == null)
                        {
                            bullet = Instantiate(bulletPrefab) as GameObject;
                            bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            bullet.transform.rotation = transform.rotation;
                        }
                    }
                }
            }
        }
        else
        {
            running = false;
        }

        animate(running);

        //Debug inflict damage
        if (Input.GetKeyDown("l"))
        {
            TakeDamage(1);
        }
    }

    //Face the player target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Inflict damage to enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        //Destroy enemy with 0 health
        if(currentHealth == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Displays look radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //animates the enemy
    void animate(bool running)
    {
        if(running)
        {
            anim.CrossFade("CurrentlyRunning", .3f);
            anim.SetBool("isRunning", true);
            anim.SetBool("isStanding", false);
        }
        else
        {
            anim.CrossFade("Jump", .3f);
            anim.SetBool("isRunning", false);
         anim.SetBool("isStanding", true);
        }
    }
}
