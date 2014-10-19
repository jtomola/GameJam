using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public float lifespan;
    public float maxScale;
    private float speed;

	// Use this for initialization
	void Start () {
        speed = (maxScale - this.transform.localScale.x) / lifespan;
        Invoke("Destroy", lifespan);
	}
	
	// Update is called once per frame
	void Update () {
        float increase = speed * Time.deltaTime;
        Vector3 increaseVect = new Vector3(increase, increase, 0.0f);
        this.transform.localScale += increaseVect; 
	}

    void Destroy()
    {
//        Debug.Log("In Destroy");
        GameObject.Destroy(this.gameObject);
    }
}
