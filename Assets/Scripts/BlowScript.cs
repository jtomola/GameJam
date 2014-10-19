using UnityEngine;
using System.Collections;

public class BlowScript : MonoBehaviour {
    public float maxForce;
    public int playerNumber;
    private string inputString;
    private bool isFiring;
    public float delay = 0.0f;
    public float drainSpeed = 1.0f;
    public float refillSpeed = 1.0f;
    private float maxMeter = 100.0f;
    public float currMeter = 100.0f;
    private bool isRegen = false;
    private SpriteRenderer sprite;
    

    void OnTriggerStay2D(Collider2D collider)
    {
        //Debug.Log("On Trigger Stay");
        GameObject obj = collider.gameObject;

        if (obj.CompareTag("SoulTag") == true && this.isFiring)
        {
            Vector2 diffPos = obj.transform.position - this.transform.position;
            diffPos.Normalize();
            Vector2 force = diffPos * this.maxForce;
            obj.rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }

    /*
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
    */

	// Use this for initialization
	void Start () {
        switch (playerNumber)
        {
            case 1:
                inputString = "Fire1";
                break;
            case 2:
                inputString = "Fire2";
                break;
            case 3:
                inputString = "Fire3";
                break;
            case 4:
                inputString = "Fire4";
                break;
            default:
                inputString = "Fire1";
                break;
        }
        this.isFiring = false;
        this.isRegen = true;
        this.currMeter = this.maxMeter;

        this.sprite = this.GetComponentInChildren<SpriteRenderer>();
        this.sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}

    private void StartRegen()
    {
        this.currMeter = 1.0f * this.maxMeter;
        this.isRegen = true;
    }
	
	// Update is called once per frame
	void Update () {
        float strength = Input.GetAxis(inputString);
        if (Mathf.Abs(strength) > 0.1f && this.isRegen)
        {
            this.isFiring = true;
            this.currMeter -= this.drainSpeed * Time.deltaTime;
            if (this.currMeter < 0.0f)
            {
                this.isFiring = false;
                this.isRegen = false;
                Invoke("StartRegen", this.delay);
            }
            else
            {
                this.sprite.enabled = true;
            }
        }
        else
        {
            this.sprite.enabled = false;
            this.isFiring = false;
            if (this.isRegen)
            {
                this.currMeter += this.drainSpeed * Time.deltaTime;
                if (this.currMeter > this.maxMeter)
                    this.currMeter = this.maxMeter;
            }
        }
	}
}
