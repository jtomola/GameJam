using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.SetResolution(1600, 900, true);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Escape"))
        {
            Application.Quit();
        }
	
	}
}
