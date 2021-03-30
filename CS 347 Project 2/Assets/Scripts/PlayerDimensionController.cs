using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dimensions))]
public class PlayerDimensionController : MonoBehaviour
{

    public LayerMask PlayerLayerMask;
    public float hitDistance = 30f;
    private GameObject thingLookingAt;
    private GameObject lastLookedAt;
    public Camera camera;
    public string LengthAbility;
    public string GrabAbility;
    public string TimeAbility;
    public string TempAbility;
    public string ChargeAbility;
    public string MassAbility;
    public KeyCode SwitchAbilityDir;
    public enum Abilities
    {
        None,
        Mass,
        Length,
        Time,
        Temp,
        Charge
        
    };
    public float MassTransferAmount = 0.2f;
    public float LengthTransferAmount = 0.1f;
    public float TimeTransferAmount = 0.1f;
    public float ChargeTransferAmount = 0.1f;
    public float TempTransferAmount = 0.1f;
    public float scrollTick = 0.1f;
    public Abilities selectedAbility;
    private int abilityDir;
    public Material OriginalMaterial;
    public Material hitMaterial;
    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.Find("Main Camera");

        LengthAbility = "q";
        GrabAbility = "p";
        TimeAbility = "t";
        TempAbility = "g";
        ChargeAbility = "r";
        MassAbility = "f";
        SwitchAbilityDir = KeyCode.LeftShift;
        abilityDir = 1;
        selectedAbility = Abilities.None;
    }

    // Update is called once per frame
    void Update()
    {
        // Check input to update spell queue

        if(Input.GetKey(LengthAbility))
        {
            this.selectedAbility = Abilities.Length;
        }else if(Input.GetKey(TimeAbility))
        {
            this.selectedAbility = Abilities.Time;
        }else if(Input.GetKey(TempAbility))
        {
            this.selectedAbility = Abilities.Temp;
        }else if(Input.GetKey(ChargeAbility))
        {
            this.selectedAbility = Abilities.Charge;
        }else if(Input.GetKey(MassAbility))
        {
            this.selectedAbility = Abilities.Mass;
        } else
        {
            this.selectedAbility = Abilities.None;
        }
        /*
        var scrollDelta = Input.mouseScrollDelta.y;
        if(Mathf.Abs(scrollDelta) >= scrollTick)
        {
            if(Mathf.Sign(scrollDelta)>0)
            {
                if(this.selectedAbility == Abilities.Charge){
                    this.selectedAbility = Abilities.None;
                } else this.selectedAbility ++;
            } else 
            {
                if(this.selectedAbility == Abilities.None){
                    this.selectedAbility = Abilities.Charge;
                } else this.selectedAbility --;
            }
            


        }*/


        if(Input.GetKey(SwitchAbilityDir))
        {
            //Debug.Log("Selected: Transfer to player");
            abilityDir = -1;      
        }
        else
        {
            //Debug.Log("Selected: Transfer from Player");
            abilityDir = 1;
        }


        // Get object player is looking at
        RaycastHit hit;
        Vector3 fwd = camera.transform.TransformDirection(Vector3.forward);
        var ray = Physics.Raycast(camera.transform.position,camera.transform.forward*hitDistance,out hit,10,PlayerLayerMask);
        Debug.Log(ray);
        Debug.DrawRay(camera.transform.position,camera.transform.forward*hitDistance,Color.yellow);
        // Record distance to object
       // Debug.Log("TEST1");
        if(hit.collider!=null){
            Debug.Log(hit.collider.gameObject.GetComponent<DimensionsExt>());
        }

        if(hit.collider!=null &&hit.collider.gameObject.GetComponent<DimensionsExt>())
        {
            this.thingLookingAt = hit.collider.gameObject;
            this.lastLookedAt = this.thingLookingAt;
            Debug.Log(hit.collider.gameObject);
            if(OriginalMaterial == null) {
                //Debug.Log("SET MATERIAL");
                OriginalMaterial = this.thingLookingAt.GetComponent<Renderer>().material;
                this.thingLookingAt.GetComponent<Renderer>().material = hitMaterial;
            }

            var dim = hit.collider.gameObject.GetComponent<DimensionsExt>();
            var mdim = this.GetComponent<Dimensions>();

            if(Input.GetKeyDown(GrabAbility) || Input.GetButtonDown("Fire1"))
            {
                var trans = hit.collider.gameObject.GetComponent<Transform>();
                var mtrans = this.GetComponent<Transform>();
                trans.SetParent(mtrans);
                trans.localPosition =  new Vector3(1,1,1);
                trans.localEulerAngles = Vector3.zero;
                Rigidbody llRb =  hit.collider.gameObject.GetComponent<Rigidbody>();
                llRb.constraints = RigidbodyConstraints.FreezePosition;
                llRb.isKinematic = true;
                llRb.useGravity = false;
                llRb.velocity = Vector3.zero;
                //llRb.angularVelocity = Vector3.zero;
                llRb.ResetInertiaTensor();
                hit.collider.gameObject.layer = 2;

            }
            switch(selectedAbility)
            {
                case Abilities.Mass:
                    //Debug.Log("USE MASS");
                    if(dim.Mass > MassTransferAmount && mdim.Mass > MassTransferAmount){  
                    dim.Mass = MassTransferAmount*abilityDir;
                    mdim.Mass = MassTransferAmount*abilityDir*-1;
                    }
                    break;
                case Abilities.Length:
                    //Debug.Log("USE LENGTH");   
                    
                    dim.Length = LengthTransferAmount*abilityDir;
                    mdim.Length = LengthTransferAmount*abilityDir*-1;
                    break;

                case Abilities.Time:
                    //Debug.Log("USE TIME");  
                    
                    dim.time = TimeTransferAmount*abilityDir;
                    mdim.time = TimeTransferAmount*abilityDir*-1;
                    break;

                case Abilities.Temp:
                    //Debug.Log("USE TEMP");  
                    dim.Temp = TempTransferAmount*abilityDir;
                    mdim.Temp = TempTransferAmount*abilityDir*-1;
                    break;

                case Abilities.Charge:
                    //Debug.Log("USE Charge");  
                    dim.Charge = ChargeTransferAmount*abilityDir;
                    mdim.Charge = ChargeTransferAmount*abilityDir*-1;
                    break;
                case Abilities.None:
                    break;
            }
        } else{
            this.thingLookingAt = null;

        }


        if((Input.GetKeyUp(GrabAbility) || Input.GetButtonUp("Fire1")) && this.lastLookedAt !=null)
        {
            var trans = this.lastLookedAt.GetComponent<Transform>();
            var mtrans = this.GetComponent<Transform>();
            trans.SetParent(null);
            trans.position =  trans.position + new Vector3(0,0,0);
            //this.lastLookedAt.GetComponent<Rigidbody>().
            //trans.localPosition = Vector3.zero;
            Rigidbody llRb = this.lastLookedAt.GetComponent<Rigidbody>();
            llRb.constraints = RigidbodyConstraints.None;
            llRb.isKinematic = false;
            llRb.velocity = transform.forward * 10;
            llRb.velocity += transform.up * 5;
            
            
            llRb.angularVelocity = Vector3.zero;
            llRb.ResetInertiaTensor();
            llRb.useGravity = true;
            this.lastLookedAt.layer = 0;
            this.lastLookedAt = null;


        }

        if(this.lastLookedAt !=null && this.thingLookingAt == null && OriginalMaterial != null)
        {
            //Debug.Log("TRYING TO CHANGE MAT");
            this.lastLookedAt.GetComponent<Renderer>().material = OriginalMaterial;
            OriginalMaterial = null;
        }







        


        
        // KEYS
        // 

        // If player looking at dimsenionable object

            // Highlight object

            // Perform exchange using exponential falloff

        
    }
}
