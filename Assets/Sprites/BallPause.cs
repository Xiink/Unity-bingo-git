using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPause : MonoBehaviour {
    Ball ball;
    Game game;

    private void Awake() {
        game = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter(Collider other) {
        ball =  other.GetComponent<Ball>();
        ball.GetComponent<Animator>().SetBool("move",true);
        ball.BallPause(0);
    }

    public void Ballcon() {
        if (ball != null) {
            ball.BallPause(5);
        }

    }
}
