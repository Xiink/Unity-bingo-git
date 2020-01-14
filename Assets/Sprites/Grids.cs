using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour
{
    Game game;
    private void Start() {
        game = FindObjectOfType<Game>();
    }
    public void OnMouseDown() {
        if (game.getBalltext().Equals(gameObject.transform.GetChild(0).GetComponent<TextMesh>().text)) {
            gameObject.transform.GetComponent<Renderer>().material.color = Color.yellow;
            gameObject.transform.GetComponent<Animator>().SetBool("chose", true);
        }
    }
}
