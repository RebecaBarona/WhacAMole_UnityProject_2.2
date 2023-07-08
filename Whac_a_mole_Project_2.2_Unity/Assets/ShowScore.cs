using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour {
    private TextMeshPro textMesh;

    void Start() {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Update() {
        textMesh.text = "Score: " + PlayerPrefs.GetInt("Score");
    }
}
