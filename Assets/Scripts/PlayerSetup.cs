using UnityEngine;
using System.Collections;

public class PlayerSetup : MonoBehaviour {

    public int player = 1;

    void Awake()
    {
        PlayerMovement movement = this.GetComponent<PlayerMovement>();
        movement.playerNumber = this.player;

        BlowScript blow = this.GetComponentInChildren<BlowScript>();
        blow.playerNumber = this.player;
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
