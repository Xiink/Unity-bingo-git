using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPoints : MonoBehaviour
{
    public static Transform[] X_points;
    public static Transform[] Y0_points;
    public static Transform[] Y1_points;
    public static Transform[] Y2_points;
    public static Transform[] Y3_points;
    public static Transform[] Y4_points;

    private void Awake() {
        X_points = new Transform[transform.GetChild(0).childCount];
        Y0_points = new Transform[transform.GetChild(1).childCount];
        Y1_points = new Transform[transform.GetChild(2).childCount];
        Y2_points = new Transform[transform.GetChild(3).childCount];
        Y3_points = new Transform[transform.GetChild(4).childCount];
        Y4_points = new Transform[transform.GetChild(5).childCount];

        for (int i = 0; i < X_points.Length; i++) {
            X_points[i] = transform.GetChild(0).GetChild(i);
        }

        for (int i = 0; i < Y0_points.Length; i++) {
            Y0_points[i] = transform.GetChild(1).GetChild(i);
            Y1_points[i] = transform.GetChild(2).GetChild(i);
            Y2_points[i] = transform.GetChild(3).GetChild(i);
            Y3_points[i] = transform.GetChild(4).GetChild(i);
            Y4_points[i] = transform.GetChild(5).GetChild(i);
        }
    }
}
