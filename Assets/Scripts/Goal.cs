﻿using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    //public GameObject Score;
    //private GUIScore guiScore;
    public bool Active;

    // Movement
    public GameObject TopClamp;
    public GameObject BotClamp;
    public float Speed;
    public float direction;

    // Collision
    public GameObject explosion;


    // Score
    public string TeamName;
    private int Score = 0;
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("SoulTag"))
        {
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
            Object.Destroy(obj, 0.0f);
            Instantiate(explosion, obj.transform.position, new Quaternion());
            //guiScore.score += 10;
            Score += 10;
            return;
        }
        
    }
    
	// Use this for initialization
	void Start () {

        Score = 0;

	}
	
	// Update is called once per frame
    void Update()
    {

        if (Active)
        {
            BoxCollider2D bCollider = GetComponent<BoxCollider2D>();
            if ((bCollider.bounds.max.y) >= TopClamp.transform.position.y)
            {
                direction = -1.0f * Mathf.Abs(direction);
            }
            if ((bCollider.bounds.min.y) <= BotClamp.transform.position.y)
            {
                direction = Mathf.Abs(direction);
            }
            
            //Debug.Log("Old position = " + transform.position);
            Vector2 moveVect = new Vector2(transform.position.x, transform.position.y + direction * Speed * Time.deltaTime);
            this.transform.position = moveVect;
           // Debug.Log("New Position = " + transform.position);
        }
        
	}

    public int GetScore()
    {
        return this.Score;
    }

    public string GetTeam()
    {
        return this.TeamName;
    }
}
