using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject TopClamp;
    public GameObject BotClamp;
    public GameObject Score;
    private GUIScore guiScore;
    public bool Active;
    public float Speed;
    public float direction;
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("SoulTag"))
        {
            Object.Destroy(obj, 0.0f);
            guiScore.score += 10;
            return;
        }
        
    }
    
	// Use this for initialization
	void Start () {
        this.guiScore = Score.GetComponent<GUIScore>();

	}
	
	// Update is called once per frame
    void Update()
    {

        if (Active)
        {
            if ((transform.position.y + transform.localScale.y * .5f) >= TopClamp.transform.position.y)
            {
                direction = -1.0f * Mathf.Abs(direction);
            }
            if ((transform.position.y - transform.localScale.y * .5f) <= BotClamp.transform.position.y)
            {
                direction = Mathf.Abs(direction);
            }
            
            //Debug.Log("Old position = " + transform.position);
            Vector2 moveVect = new Vector2(transform.position.x, transform.position.y + direction * Speed * Time.deltaTime);
            this.transform.position = moveVect;
           // Debug.Log("New Position = " + transform.position);
        }
        
	}
}
