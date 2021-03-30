using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour
{

    public float MassDamagePercentage;
    public float VelocityDamagePercentage;
    public float impactFlatDamage;
    public float chargeThreshold;
    public float tempThreshold;
    public float chargeTickDamage;
    public float burnTickDamage;

    private bool isElectrocuted;
    private bool isIgnited;
    private float chargeTickLength;
    private float burnTickLength;
    public EnemyController selfEnemy;
    private CapsuleCollider ccollider;
    public LayerMask mask;
    //private CapsuleCast ccast;
    // Start is called before the first frame update
    void Start()
    {
        MassDamagePercentage = 0.1f;
        VelocityDamagePercentage = 0.1f;
        impactFlatDamage = 5f;
        chargeThreshold = 5f;
        tempThreshold = 5f;
        chargeTickDamage = 0.1f;
        burnTickDamage = 0.1f;

        isElectrocuted = false;
        isIgnited = false;
        selfEnemy = this.GetComponent<EnemyController>();
        ccollider = this.GetComponent<CapsuleCollider>();
        //selfEnemy.TakeDamage(1);
    }





    // Update is called once per frame
    void Update()
    {   
        RaycastHit hit;
        var ray = Physics.CapsuleCast(ccollider.transform.position-Vector3.up*ccollider.height, ccollider.transform.position+Vector3.up*ccollider.height,ccollider.radius,transform.forward,out hit,1.0f,mask);
        if(hit.collider!= null)
        {
            
            
            Debug.Log(hit.collider.name);
            Debug.DrawRay(ccollider.transform.position,ccollider.transform.forward*1f,Color.green);
            if(hit.collider.gameObject.GetComponent<DimensionsExt>())
            {
                Debug.Log(hit.collider.name);
                
                Debug.Log((int)(impactFlatDamage*(1+MassDamagePercentage)*(1+VelocityDamagePercentage)));
                selfEnemy.TakeDamage((int)(impactFlatDamage*(1+MassDamagePercentage)*(1+VelocityDamagePercentage)));
                var dim = hit.collider.gameObject.GetComponent<DimensionsExt>();
                if(dim.Temp > tempThreshold){
                    isIgnited = true;
                    burnTickLength = 10*(dim.Temp-tempThreshold+1);
                    dim.Temp -= tempThreshold;
                }
                if(dim.Charge > chargeThreshold){
                    isIgnited = true;
                    chargeTickLength = 10*(dim.Charge-chargeThreshold+1);
                    dim.Charge = 0;
                }
            }
        }

    }

    void FixedUpdate()
    {
        //Debug.Log("WHY WONT YOU TAKE DAMAGE");
        //selfEnemy.TakeDamage(1);
        if(isElectrocuted)
        {
            selfEnemy.TakeDamage((int)chargeTickDamage);
            chargeTickLength -=1;
            if(chargeTickLength <= 0) isElectrocuted = false;
        }

        if(isIgnited)
        {
            selfEnemy.currentHealth -= (int)burnTickDamage;
            burnTickLength -=1;
            if(burnTickLength <=0) isIgnited = false;
        }


    }
}
