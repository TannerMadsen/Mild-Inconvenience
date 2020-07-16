using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
public bool Automatic;
    public float FireRate;
    private float FireCurrent;
    public float Damage;
    public bool CanFire;
    public ParticleSystem MuzzleFlash;
    public float CooldownTime;
    private float CooldownActual;
    public bool CoolingDown;
    public float ReloadTime;
    private float ReloadActual;
    public float MaxRange;
    public Camera fpsCam;
    public LayerMask Targetmask;
    public GameObject impactEffect;
    public float impactForce;
    public AudioSource shootSound;
    public Animator rotamina;
    // Start is called before the first frame update
    void Start()
    {
        FireCurrent = FireRate;
        CooldownActual = 0;
        ReloadActual = ReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Automatic){
            if(Input.GetButton("Fire1")){
                if(!CoolingDown){
                    if(CanFire){
                        Fire();
                        FireCurrent = 0;
                        CanFire = false;
                    }
                    CooldownActual += Time.deltaTime;
                }
            }
        }else{
            if(Input.GetButtonDown("Fire1")){
                Fire();
                FireCurrent = 0;
                CanFire = false;
            }
        }
        if(!CoolingDown){
            if(CooldownActual > CooldownTime){
                CooldownActual = 0;
                CoolingDown = true;
            }
        }else{
            rotamina.SetBool("Reloading", true);
            ReloadActual -= Time.deltaTime;
            if(ReloadActual < 0){
                ReloadActual = ReloadTime;
                rotamina.SetBool("Reloading", false);
                CoolingDown = false;
            }
        }
        
        if(FireCurrent < FireRate){
            FireCurrent += Time.deltaTime;
        }else{
            FireCurrent = FireRate;
            CanFire = true;

        }
    }
    public void Fire(){
        MuzzleFlash.Play();
        shootSound.Play();
        //Debug.Log("BANG!");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, MaxRange, Targetmask)){
            //Debug.Log(hit.transform.name);
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if(target != null){
                target.TakeDamage(Damage);
            }
            if(hit.rigidbody != null){
                hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        
    }
}
