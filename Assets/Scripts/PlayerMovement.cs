using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10.0f;
    public int playerNumber = 1;

    private string xLeftString; 
    private string yLeftString; 
    private string xRightString; 
    private string yRightString;
    public bool disabled;
    public float delay;
        
        // Use this for initialization
	void Start () {
        switch (playerNumber)
        {
            case 1:
                xLeftString = "HorizontalLeft1";
                yLeftString = "VerticalLeft1";
                xRightString = "HorizontalRight1";
                yRightString = "VerticalRight1";

                break;
            case 2:
                xLeftString = "HorizontalLeft2";
                yLeftString = "VerticalLeft2";
                xRightString = "HorizontalRight2";
                yRightString = "VerticalRight2";

                break;
            case 3:
                xLeftString = "HorizontalLeft3";
                yLeftString = "VerticalLeft3";
                xRightString = "HorizontalRight3";
                yRightString = "VerticalRight3";

                break;
            case 4:
                xLeftString = "HorizontalLeft4";
                yLeftString = "VerticalLeft4";
                xRightString = "HorizontalRight4";
                yRightString = "VerticalRight4";

                break;
        }
        disabled = false;
	}

    void Activate()
    {
        this.disabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject obj = coll.collider.gameObject;

        if (obj.CompareTag("Cannon") || obj.CompareTag("AnchoredBlock"))
        {
            Debug.Log("Inside collider FOR PLAYER");
            this.disabled = true;
            BlowScript blow = this.GetComponentInChildren<BlowScript>();
            Invoke("Activate", delay);


            blow.delayActive = this.delay;
            blow.Disable();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (disabled)
            return;
        float xAxisLeft = Input.GetAxis(xLeftString);	
        float yAxisLeft = Input.GetAxis(yLeftString);	
        //float xAxisLeft = Input.GetAxis("HorizontalRight1");	
        //float yAxisLeft = Input.GetAxis("VerticalRight1");	
        float xAxisRight = Input.GetAxis(xRightString);	
        float yAxisRight = Input.GetAxis(yRightString);

        Vector2 moveVect = new Vector2(xAxisLeft * Time.deltaTime * speed, yAxisLeft * Time.deltaTime * speed);
        //this.transform.Translate(moveVect, null);

        this.rigidbody2D.AddForce(moveVect, ForceMode2D.Impulse);

        if (Mathf.Abs(xAxisRight) > 0.5f || Mathf.Abs(yAxisRight) > 0.5f)
            transform.eulerAngles = new Vector3(0, 0, -1.0f * Mathf.Atan2(yAxisRight, xAxisRight) * 180 / Mathf.PI - 90.0f);
        //this.transform.rotation = Quaternion.LookRotation(lookVect);

        //float angle = Mathf.Atan2(Mathf.Abs(yAxisRight), Mathf.Abs(xAxisRight)) * Mathf.Rad2Deg;
        /*
        if (xAxisRight > 0.0f && yAxisRight < 0.0f)
            angle += 270.0f;
        else if (xAxisRight < 0.0f && yAxisRight < 0.0f)
            angle += 180.0f;
        else if (xAxisRight < 0.0f && yAxisRight > 0.0f)
            angle += 90.0f;
        */

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

	}
}
