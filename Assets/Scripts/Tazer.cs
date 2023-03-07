using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazer : MonoBehaviour
{
    public float damage = 10f;
    public float firerate = 15f;
    public float range = 100f;
    public float impactForce = 30f;

    public int ammo = 1;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;
	
	// Update is called once per frame
	void Update ()
    {
		
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 3f / firerate;
            Shoot();
        }
	}

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           Guard guard = hit.transform.GetComponent<Guard>();
           if(guard != null && ammo == 1)
           {
                guard.TakeDamage();
                ammo--;
           }
           else if(guard != null && ammo == 0)
           {
                guard.slowDamage();
           }

           if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
