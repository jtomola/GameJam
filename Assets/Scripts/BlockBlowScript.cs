using UnityEngine;
using System.Collections;

public class BlockBlowScript : MonoBehaviour {

    public GameObject blowerTop;
    public GameObject blowerBot;
    public GameObject blowerRight;
    public GameObject blowerLeft;
    public float shootDelay;
    public float shutdownDelay;
    private int count;
	// Use this for initialization
	void Start () {
        Invoke("ShootShit", shootDelay);
        ShutDownShit();
        count = Random.Range(0, 10);
	}

    private void ShutDownShit()
    {
        blowerTop.SetActive(false);
        blowerBot.SetActive(false);
        blowerRight.SetActive(false);
        blowerLeft.SetActive(false);
    }
    private void ShootShit()
    {
        int randomSide = count % 2;
        if (randomSide == 0)
        {
            blowerTop.SetActive(true);
            blowerBot.SetActive(true);
            Invoke("ShutDownShit", shutdownDelay);
        }
        else
        {
            blowerRight.SetActive(true);
            blowerLeft.SetActive(true);
            Invoke("ShutDownShit", shutdownDelay);
        }
        count++;
        Invoke("ShootShit", shootDelay);
    }
    // Update is called once per frame
	void Update () {
        // no this wont work
        
	}
}
