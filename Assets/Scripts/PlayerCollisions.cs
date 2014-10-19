using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public int Health;
    public TextMesh textMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.GetComponent<TextMesh>().text = "Health: " + Health.ToString();
        
	}

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SoulTag")
        {
            Health--;
        }
    }
}
