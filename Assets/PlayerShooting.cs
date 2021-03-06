﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Complete
{
    public class PlayerShooting : MonoBehaviour
    {

        public int m_PlayerNumber = 1;              // Used to identify the different players.
        public int damagePerShot = 20;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets = 0.15f;        // The time between each shot.
        public float range = 100f;                      // The distance the gun can fire.
        public bool canShoot;

        float timer;                                    // A timer to determine when to fire.
        Ray shootRay = new Ray();                       // A ray from the gun end forwards.
        RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
        int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
        public ParticleSystem gunParticles;                    // Reference to the particle system.
        public LineRenderer gunLine;                           // Reference to the line renderer.
        public AudioSource gunAudio;                           // Reference to the audio source.
        public Light gunLight;                                 // Reference to the light component.
        public Light faceLight;								// Duh
        float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.


        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable");

            // Set up the references.
            // gunParticles = GetComponent<ParticleSystem>();

            //faceLight = GetComponentInChildren<Light> ();
        }


        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;


            // If the Fire1 button is being press and it's time to fire...
            if ((canShoot) && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                Shoot();
                canShoot = false;

            }

            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }
        }


        public void DisableEffects()
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
            faceLight.enabled = false;
            gunLight.enabled = false;
        }
        IEnumerator waitFrame(Animator animator, Raggdoll ragdoll,CapsuleCollider capsulCollider)
        {
            yield return new WaitForSeconds(1f);
            print("wait 1 sec !");
            capsulCollider.enabled = false;
            animator.enabled = false;

            //ragdoll.pelvis.GetComponent<Rigidbody>().AddForce(transform.forward * 5);
            yield return null;
        }

        public void Shoot()
        {
            // Reset the timer.
            timer = 0f;

            // Play the gun shot audioclip.
            gunAudio.Play();

            // Enable the lights.
            gunLight.enabled = true;
            faceLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop();
            gunParticles.Play();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);

            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if (Physics.SphereCast(shootRay, 1f, out shootHit, range, shootableMask)){
                AIHealth enemyHealth = shootHit.collider.GetComponent<AIHealth>();
                if (enemyHealth != null) {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                  //  shootHit.rigidbody.constraints &= RigidbodyConstraints.FreezeAll;

                    if (shootHit.rigidbody != null)
                    {
                        
                    }

                    if (enemyHealth.currentHealth <= 0)
                    {
                        shootHit.rigidbody.isKinematic = true;
                        Animator animator = shootHit.transform.gameObject.GetComponent<Animator>();
                        CapsuleCollider capsulCollider = shootHit.transform.gameObject.GetComponent<CapsuleCollider>();
                        Raggdoll ragdoll = shootHit.transform.gameObject.GetComponent<Raggdoll>();

                        if (animator != null && capsulCollider != null && capsulCollider.enabled == true )
                        {
                            ragdoll.enabledParts();
                           // capsulCollider.enabled = false;
                            StartCoroutine(waitFrame(animator, ragdoll, capsulCollider));

                        }
                    }
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition(1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }

        }


     

    }
}

