using UnityEngine;
using System.Collections;

public class CenterBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        this.rigidbody2D.AddTorque(0.02f);
    }
}
