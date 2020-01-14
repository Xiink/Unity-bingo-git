using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContinue : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        FindObjectOfType<BallPause>().Ballcon();
    }
}
