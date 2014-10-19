using UnityEngine;
using System.Collections;

public class SoulGenerator : MonoBehaviour
{

    public GameObject Soul_Prefab;
    public int numSouls;
    public float xLimit;
    public float yLimit;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < numSouls; i++)
        {
            Vector3 vect = new Vector3(Random.Range(-xLimit, xLimit), Random.Range(-yLimit, yLimit), 0.0f);
            Quaternion q = new Quaternion();

            Instantiate(Soul_Prefab, vect, q);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
