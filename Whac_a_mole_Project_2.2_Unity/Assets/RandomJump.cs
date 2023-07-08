using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {

    private BoxCollider parentBoxCollider;
    private Animator anim;
    public float interval = 0.01f;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        parentBoxCollider = transform.parent.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < interval && !jumping) {
            jumping = true;
            GetComponent<AudioSource>().Play();
            parentBoxCollider.enabled = true;
            randomNumber = Random.Range(0, 3);
            if (randomNumber == 0) {
                anim.Play("Jump_01");
            } else if (randomNumber == 1) {
                anim.Play("Jump_04");
            } else {
                anim.Play("Jump_06");
            }
        } else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_Mole") && jumping) {
            jumping = false;
            parentBoxCollider.enabled = false;
        }
    }
}