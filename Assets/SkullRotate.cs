using UnityEngine;
using System.Collections;

public class SkullRotate : MonoBehaviour {
    public float rotate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(new Vector3(0, 0, 1), -rotate * Time.deltaTime);

        if (Input.GetButtonDown("Start"))
        {
            Application.LoadLevel("MainScene");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
