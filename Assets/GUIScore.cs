using UnityEngine;
using System.Collections;

public class GUIScore : MonoBehaviour {
    public Vector2 pos;
    public float width;
    public float height;
    public int fontSize;
    public int score;
    private bool disabled;
    private GUIStyle style;

	// Use this for initialization
	void Start () {
        style = new GUIStyle();
        style.fontSize = fontSize;
        this.disabled = false;
	}

    void Disable()
    {
        this.disabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        	
	}
    void OnGUI()
    {
        float xPos = Screen.width * pos.x;
        float yPos = Screen.height * pos.y;
        if (!disabled)
            GUI.Box(new Rect(xPos, yPos, width, height), "Score: " + this.score, style);
            //GUI.Box(new Rect(pos.x, pos.y, width, height), "Score: " + this.score, style);

        
    }
}
