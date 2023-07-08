using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    void Start() {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update() {

    }
}
