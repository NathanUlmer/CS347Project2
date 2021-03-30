using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public string sceneOver = "Game Over";

    public HealthBarController healthBar;

    // Start is called before the first frame update
    void Start()
    {
        TimeController.instance.BeginTime();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            TimeController.instance.EndTime();
            SceneManager.LoadSceneAsync(sceneOver);
        }
        //Debug inflict damage
        /*if (Input.GetKeyDown("e"))
        {
            TakeDamage(2);
        }*/
    }

    //Damage handler
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
