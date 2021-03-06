﻿using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

    public GameObject Soul_Prefab;
    public Transform Barrel;
    public float fireRateOffset = 0.0f;
    public float fireRate = 1.0f;
    float timer;
    public float ejectionForce;

	// Use this for initialization
	void Start () {

        timer = Time.time + fireRate + fireRateOffset;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
            Vector2 dirVector = collider.transform.position - this.transform.position;
            dirVector.Normalize();
            Vector2 force = dirVector * ejectionForce;
            collider.rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }

    }
	// Update is called once per frame
	void Update () {

        if (Time.time > timer)
        {
//            Debug.Log("In loop");
            Vector3 vect = new Vector3(Barrel.position.x, Barrel.position.y, 0.0f);
            Quaternion q = new Quaternion();

            GameObject soul = (GameObject)Instantiate(Soul_Prefab, vect, q);



            Vector2 barrelPos = new Vector2(Barrel.position.x, Barrel.position.y);
            Vector2 cannonPos = new Vector2(this.transform.position.x, this.transform.position.y);

            //Debug.Log("BarrelPos = " + barrelPos.ToString());
            //Debug.Log("CannonPos = " + cannonPos.ToString());

            Vector2 trajectory = cannonPos - barrelPos;

            soul.rigidbody2D.AddForce(trajectory, ForceMode2D.Impulse);

            timer += fireRate;
        }
	
	}
}
