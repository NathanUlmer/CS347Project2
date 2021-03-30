using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineController : MonoBehaviour
{

    public string sceneEnd = "End Scene";

    // Update is called once per frame
    void Update()
    {
        
    }

    //Touching Finish Line
    void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            TimeController.instance.EndTime();
            SceneManager.LoadSceneAsync(sceneEnd);
        }
    }
}
