using UnityEngine;
using System.Collections;

public class BlowScript : MonoBehaviour {
    public float maxForce;

    /*
    void OnTriggerStay(Collider collider)
    {
        Debug.Log("On Trigger Stay");
        GameObject obj = collider.gameObject;

        if (obj.CompareTag("SoulTag") == true)
        {
            Vector2 force = maxForce * transform.forward;
            obj.rigidbody2D.AddForce(force, ForceMode2D.Force);
        }
    }
    */

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.CompareTag("SoulTag") == true)
        {
            Vector2 diffPos = obj.transform.position - this.transform.position;
            diffPos.Normalize();
            Vector2 force = diffPos * this.maxForce;
            obj.rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
