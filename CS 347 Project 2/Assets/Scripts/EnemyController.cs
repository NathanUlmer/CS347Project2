using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;

    public GameObject bulletPrefab;
    private GameObject bullet;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Enemy approaches when they see the player
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            //Enemy shoots when the player is in range
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
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
    }

    //Face the player target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //Displays look radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
