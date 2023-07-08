using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour {
    private Animator anim;
    private GameObject scoreSound;
    public bool dying = false;


    void Start() {
        anim = transform.GetChild(0).GetComponent<Animator>();
        scoreSound = GameObject.Find("ScoreSound");
    }

    // Update is called once per frame
    void Update() {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_Mole") && dying) {
            dying = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Interactable") && !dying) {
            dying = true;
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
            PlayerPrefs.Save();
            int randomNumber = Random.Range(0, 3);
            GetComponent<AudioSource>().Play();
            //Play Score Sound
            scoreSound.GetComponent<AudioSource>().Play();
            if (randomNumber == 0) {
                anim.Play("KO_04");
            } else if (randomNumber == 1) {
                anim.Play("KO_06");
            } else {
                anim.Play("KO_07");
            }
        }
    }
}