using UnityEngine;
using System.Collections;

public class BlockBlowScript : MonoBehaviour {

    public GameObject blowerTop;
    public GameObject blowerBot;
    public GameObject blowerRight;
    public GameObject blowerLeft;
    private float shootDelay;
    private float shutdownDelay;
    private int count;
	// Use this for initialization
	void Start () {

        shootDelay = Random.Range(5.0f, 12.0f);
        Invoke("ShootShit", shootDelay);
        shutdownDelay = 0.5f;
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
        shootDelay = Random.Range(5.0f, 12.0f);
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
