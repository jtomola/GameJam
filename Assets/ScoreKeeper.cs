using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public Goal purpleGoal;
    public Goal turqouiseGoal;

    public GUIText purpleScoreText;
    public GUIText turqouiseScoreText;

    private int PurpleScore;
    private int TurqouiseScore;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        PurpleScore = purpleGoal.GetScore();
        TurqouiseScore = turqouiseGoal.GetScore();

        purpleScoreText.text = purpleGoal.GetTeam() + " Score: " + PurpleScore.ToString();
        turqouiseScoreText.text = turqouiseGoal.GetTeam() + " Score: " + TurqouiseScore.ToString();

	}
}
