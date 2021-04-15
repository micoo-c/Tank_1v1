using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour {

    public float firerate = 3.0f;
    float lastshot = 0.0f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    public AudioSource fire;

    // Update is called once per frame
    void Update()
    {
        CharacterController2 charac = GetComponent<CharacterController2>();
        if ((Input.GetButtonDown("Fire2")) && (charac.alive == true))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if (Time.time > firerate + lastshot)
        {
            fire.Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject flashClone = Instantiate(muzzleFlash, firePoint.position, firePoint.rotation);
            Destroy(flashClone, 0.5f);
            lastshot = Time.time;
        }
    }
}
