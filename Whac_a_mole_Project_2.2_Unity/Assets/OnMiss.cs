using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMiss : MonoBehaviour
{
    private Animator anim;
    private GameObject scoreSound;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - 1);
       
    }

}
