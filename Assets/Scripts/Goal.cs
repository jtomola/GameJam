using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject TopClamp;
    public GameObject BotClamp;
    public bool Active;
    public float Speed;
    public int direction;
    
   // void OnTriggerStay2D(Collider2D collision)
   // {
   //     GameObject obj = collision.gameObject;
   //     
   //     if (obj.CompareTag("SoulTag"))
   //     {
   //         Debug.Log("Destroying");
   //         Object.Destroy(obj, 0.0f);
   //     }
   //     else if (obj.CompareTag("Wall"))
   //     {
   //         Debug.Log("Wall collide");
   //         direction = -direction;
   //     }
   // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        Debug.Log("OnCollision Called");
        if (obj.CompareTag("SoulTag"))
        {
            Debug.Log("Destroying");
            Object.Destroy(obj, 0.0f);
            return;
        }
        
    }
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void Update()
    {

        if (Active)
        {
            if ((transform.position.y + transform.localScale.y * .5f) >= TopClamp.transform.position.y)
            {
                Debug.Log("First If Blocked: ");
                Debug.Log("My Y = " + transform.position.y);
                Debug.Log("TopClamp y is: " + (transform.position.y - 5));
                direction = -direction;
            }
            if ((transform.position.y - transform.localScale.y * .5f) <= BotClamp.transform.position.y)
            {
                Debug.Log("Second If Blocked");
                direction = -direction;
            }
            
            //Debug.Log("Old position = " + transform.position);
            Vector2 moveVect = new Vector2(transform.position.x, transform.position.y + direction * Speed * Time.deltaTime);
            this.transform.position = moveVect;
           // Debug.Log("New Position = " + transform.position);
        }
        
	}
}
