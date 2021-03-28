using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dimensions))]
public class PlayerDimensionController : MonoBehaviour
{

    public float hitDistance = 30f;
    private GameObject thingLookingAt;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // Check input to update spell queue


        // Get object player is looking at
        RaycastHit hit;
        Vector3 fwd = camera.transform.TransformDirection(Vector3.forward);
        var ray = Physics.Raycast(camera.transform.position,camera.transform.forward*hitDistance,out hit,10);
        Debug.Log(ray);
        Debug.DrawRay(camera.transform.position,camera.transform.forward*hitDistance,Color.yellow);
        // Record distance to object
        

         if (Input.GetKeyDown("r") && hit.collider != null && hit.collider.gameObject.GetComponent<Dimensions2>())
        {
            
            var dim = hit.collider.gameObject.GetComponent<Dimensions2>();
            dim.Mass = .2f;
            var mdim = this.GetComponent<Dimensions>();
            mdim.Mass = -.2f;
        }
        
        if (Input.GetKeyDown("q") && hit.collider != null && hit.collider.gameObject.GetComponent<Dimensions2>())
        {
            
            var dim = hit.collider.gameObject.GetComponent<Dimensions2>();
            dim.Mass = -.2f;
            var mdim = this.GetComponent<Dimensions>();
            mdim.Mass = .2f;
        }
        

        // If player looking at dimsenionable object

            // Highlight object

            // Perform exchange using exponential falloff

        
    }
}
