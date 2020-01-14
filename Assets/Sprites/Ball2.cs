using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour {
    public float speed = 5f;
    private Transform target;
    private int waveindexpoint = 0;
    Game game;
    int x = 0, y = 0;
    bool b = false;
    bool change = false;


    private void Start() {
        target = CubesPoints.X_points[0];
        game = FindObjectOfType<Game>();
        gameObject.transform.eulerAngles = new Vector3(
        gameObject.transform.eulerAngles.x + 90,
        gameObject.transform.eulerAngles.y,
        gameObject.transform.eulerAngles.z
        );
    }

    private void Update() {
        //先移動x    
        if (!change) {
            target = CubesPoints.X_points[x];
            if (Vector3.Distance(transform.position, target.position) > 0.2f) {
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }
            else {
                change = true;
                GetNextpointY();
            }
        }
        else {
            if (Vector3.Distance(transform.position, target.position) > 0.2f) {
                Vector3 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
                GetNextpointY();
            }
        }
    }

    void GetNextpointY() {
        if (b) {
            return;
        }
        switch (x) {
            case 0:
            target = CubesPoints.Y0_points[y];
            break;
            case 1:
            target = CubesPoints.Y1_points[y];
            break;
            case 2:
            target = CubesPoints.Y2_points[y];
            break;
            case 3:
            target = CubesPoints.Y3_points[y];
            break;
            case 4:
            target = CubesPoints.Y4_points[y];
            break;
        }
        b = true;
    }

    public void Where(int x, int y) {
        //接收球要去哪個位置
        this.x = x;
        this.y = y;
        if (y == 14)
            b = true;
        target = CubesPoints.X_points[x];
    }
}
