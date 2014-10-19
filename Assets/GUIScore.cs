using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
    public Vector2 pos;
    public float width;
    public float height;
    public int fontSize;
    public int score;
    private GUIStyle style;

	// Use this for initialization
	void Start () {
        style = new GUIStyle();
        style.fontSize = fontSize;
	}
	
	// Update is called once per frame
	void Update () {
        	
	}
    void OnGUI()
    {
        GUI.Box(new Rect(pos.x, pos.y, width, height), "Score: " + this.score, style);

        
    }
}
