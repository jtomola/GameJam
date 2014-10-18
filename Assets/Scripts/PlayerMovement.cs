using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float xAxisLeft = Input.GetAxis("HorizontalLeft1");	
        float yAxisLeft = Input.GetAxis("VerticalLeft1");	
        //float xAxisLeft = Input.GetAxis("HorizontalRight1");	
        //float yAxisLeft = Input.GetAxis("VerticalRight1");	
        float xAxisRight = Input.GetAxis("HorizontalRight1");	
        float yAxisRight = Input.GetAxis("VerticalRight1");

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
