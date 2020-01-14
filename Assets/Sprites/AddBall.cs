using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class AddBall : MonoBehaviour {
    public Transform BallPrefab;
    public Transform spawnPoint;
    TextMesh Ballnum;
    SpriteRenderer Ballcolor;
    string number;
    Color color;
    int x = 4;
    int y = 0;

    private void OnTriggerEnter(Collider other) {
        number = other.GetComponentInChildren<TextMesh>().text;
        color = other.GetComponent<SpriteRenderer>().color;
        AddtoList();
    }

    public void AddtoList() {
        SpawnBall();
        Ballnum = FindObjectOfType<Ball2>().GetComponentInChildren<TextMesh>();
        Ballcolor = FindObjectOfType<Ball2>().GetComponent<SpriteRenderer>();
        FindObjectOfType<Ball2>().Where(x, y);
        if (y + 1 > 14) {
            x--;
            y = 0;
        }
        else {
            y++;
        }
        Ballnum.text = number;
        Ballcolor.material.color = color;
    }

    private void SpawnBall() {
        Instantiate(BallPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void SetBall(string num, Color c) {
        number = num;
        color = c;
    }
}
