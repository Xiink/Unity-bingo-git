using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingo : MonoBehaviour
{
    Game game;
    void Start() {
        game = FindObjectOfType<Game>();
    }

     public void bingo() {
        game.clickBingo();
    }
}
