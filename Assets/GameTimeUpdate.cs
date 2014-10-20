using UnityEngine;
using System.Collections;

public class GameTimeUpdate : MonoBehaviour {

    public TimerScript levelTimer;

    private float time;

    public GUIText rightTimerText;
    public GUIText leftTimerText;

    public GUIText winMessage;
    public ScoreKeeper scoreKeeper;

    public AudioSource turqWin;
    public AudioSource purpWin;
    public AudioSource tie;
    bool soundPlayed;
	// Use this for initialization
	void Start () {
        soundPlayed = false;

        winMessage.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

        time = levelTimer.GetTime();

        rightTimerText.text = "Time: " + time.ToString() + "s";
        leftTimerText.text = "Time: " + time.ToString() + "s";

        AudioSource source = purpWin;

        if (time <= 0)
        {
            // Win Message
            if (scoreKeeper.purpleGoal.GetScore() > scoreKeeper.turqouiseGoal.GetScore())
            {
                winMessage.text = "Purple Team Wins!!";
                source = purpWin;

            }
            else if (scoreKeeper.purpleGoal.GetScore() < scoreKeeper.turqouiseGoal.GetScore())
            {
                winMessage.text = "Turquoise Team Wins!!";
                source = turqWin;
            }
            else
            {
                winMessage.text = "Tie Game!!";
                source = tie;
            }

            if (soundPlayed == false)
            {
                soundPlayed = true;
                source.Play();
            }

            winMessage.enabled = true;

            scoreKeeper.purpleGoal.gameObject.SetActive(false);
            scoreKeeper.turqouiseGoal.gameObject.SetActive(false);

            Invoke("EndGame", 8.0f);
        }
	
	}

    void EndGame()
    {
        Application.LoadLevel("StartScene");
    }
}