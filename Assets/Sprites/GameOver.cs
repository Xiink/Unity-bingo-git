using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;

    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
