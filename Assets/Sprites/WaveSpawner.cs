using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {
    public Transform BallPrefab;
    public Transform spawnPoint;
    TextMesh Ballnum;
    SpriteRenderer Ballcolor;

    private float coutdown = 2f;
    public int ballNumber = 1;
    public float timeBetween = 5f;
    public Text timer;
    Game game;

    private void Awake() {
        game = GetComponent<Game>();
    }
    private void FixedUpdate() {
        int num = game.getBallnum();
        if (num < 75) {
            if (coutdown <= 0) {
                coutdown = timeBetween;
                Spawn();
                if (ballNumber == 0)
                    return;
                Ballnum = FindObjectOfType<Ball>().GetComponentInChildren<TextMesh>();
                Ballcolor = FindObjectOfType<Ball>().GetComponent<SpriteRenderer>();
                float r = UnityEngine.Random.Range(0f, 1f);
                float g = UnityEngine.Random.Range(0f, 1f);
                float b = UnityEngine.Random.Range(0f, 1f);
                Color color = new Color(r, g, b);
                Ballcolor.material.color = color;
                Ballnum.text = game.getBalltext();
                return;
            }
            coutdown -= Time.deltaTime;

            coutdown = Mathf.Clamp(coutdown, 0f, Mathf.Infinity);

            timer.text = string.Format("{0:00.00}", coutdown);
        }
    }

    private void Spawn() {
        game.SetGridColor();
        for (int i = 0; i < ballNumber; i++)
            SpawnBall();
        game.Checkwin();
    }

    private void SpawnBall() {
        Instantiate(BallPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
