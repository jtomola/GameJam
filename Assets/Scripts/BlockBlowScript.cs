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
    public float ejectionForce;
	// Use this for initialization

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Block Collision Enter");
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Inside collider if");
            Vector2 dirVector = collider.transform.position - this.transform.position;
            dirVector.Normalize();
            Vector2 force = dirVector * ejectionForce;
            collider.rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }

    }

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
