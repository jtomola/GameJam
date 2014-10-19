using UnityEngine;
using System.Collections;

public class WinTextScript : MonoBehaviour {
    public string str;
    private bool displayed;
    public float toggleTime;
    public Vector2 pos;
    public float width;
    public float height;
    private GUIStyle style;
    public int fontSize;
    private string locStr;

	// Use this for initialization
	void Start () {
        this.displayed = true;
        Invoke("Toggle", toggleTime);
        style = new GUIStyle();
        style.fontSize = fontSize;
	}

    public void SetString(string stringIn)
    {
        this.str = stringIn;
    }

    void Toggle()
    {
//        Debug.Log("Toggle");
        this.displayed = !this.displayed;
        Invoke("Toggle", toggleTime);
    }

    void OnGUI()
    {
        float xPos = Screen.width * pos.x;
        float yPos = Screen.height * pos.y;
        if (this.displayed)
            GUI.Label(new Rect(xPos, yPos, width, height), str, style);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
