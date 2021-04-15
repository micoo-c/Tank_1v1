using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public int damage = 50;

	// Use this for initialization
	void Start () {
        rb.velocity = transform.up * speed;
	}
	
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        GameObject impactClone = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactClone,1);
        CharacterController charac = hitInfo.GetComponent<CharacterController>();
        CharacterController2 charac2 = hitInfo.GetComponent<CharacterController2>();
        if (charac != null) {
            charac.TakeDamage(damage);
        }
        if (charac2 != null)
        {
            charac2.TakeDamage(damage);
        }
    }
	
}
