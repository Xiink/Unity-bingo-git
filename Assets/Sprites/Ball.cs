using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Transform target;
    private int waveindexpoint = 0;
    Game game;

    private void Start() {
        target = WavePoints.points[0];
        game = FindObjectOfType<Game>();
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x+90,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z
        );

    }

    private void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.2f) {
            GetNextpoint();
        }
    }

    void GetNextpoint() {
        if (waveindexpoint >= WavePoints.points.Length - 1) {
            Destroy(gameObject);
            return;
        }
        waveindexpoint++;
        target = WavePoints.points[waveindexpoint];
    }

    public void BallPause(int i) {
        speed = i;
    }

}
