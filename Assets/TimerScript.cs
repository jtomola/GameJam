using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
    private int currSeconds;
    public int maxSeconds;
    public Vector2 pos;
    public float width, height;
    public int fontSize;
    private GUIStyle style;
    public GameObject winText;
    public float resetDelay;
    private bool displayed;

	// Use this for initialization
	void Start () {
        this.currSeconds = maxSeconds;
        Invoke("Decrement", 1);
        style = new GUIStyle();
        style.fontSize = fontSize;
        displayed = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!displayed)
            return;
        if (this.currSeconds <= 0)
        {
            GameObject leftScore = GameObject.FindGameObjectWithTag("LeftScore");
            GameObject rightScore = GameObject.FindGameObjectWithTag("RightScore");
            GUIScore leftScoreScript = leftScore.GetComponent<GUIScore>();
            GUIScore rightScoreScript = rightScore.GetComponent<GUIScore>();

            GameObject wintext2 = (GameObject)Instantiate(winText, Vector3.zero, Quaternion.identity);
            WinTextScript winScript = wintext2.GetComponent<WinTextScript>();
            if (leftScoreScript.score > rightScoreScript.score)
            {
                winScript.SetString("LEFT TEAM WINS!");
            }
            else if (leftScoreScript.score < rightScoreScript.score)
            {
                winScript.SetString("RIGHT TEAM WINS!");
            }
            else
            {
                winScript.SetString("TIE!!!");
            }

            GameObject.Destroy(leftScore);
            GameObject.Destroy(rightScore);

            Invoke("ResetScene", resetDelay);

            displayed = false;
        }
	}

    void ResetScene()
    {
        Debug.Log("Resetting scene");
        Application.LoadLevel("MainScene");
    }

    void OnGUI()
    {
        float xPos = Screen.width * pos.x;
        float yPos = Screen.height * pos.y;
        if (currSeconds > 0)
            GUI.Box(new Rect(xPos, yPos, width, height), currSeconds.ToString(), style);
    }



    void Decrement()
    {
        this.currSeconds--;
        Invoke("Decrement", 1);
    }
}
