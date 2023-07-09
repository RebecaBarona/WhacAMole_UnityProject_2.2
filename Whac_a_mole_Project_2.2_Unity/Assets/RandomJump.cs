using System;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {

    private BoxCollider parentBoxCollider;
    private Animator anim;
    // Probability between 0 and 1
    public float jumpProbability = 0.01f;
    // Interval between 0 and 1
    public float hitBoxInterval = 0.2f;
    private long jumpStartTimestamp;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        parentBoxCollider = transform.parent.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update() {
        float randomNumber = UnityEngine.Random.Range(0f, 1f);
        if (randomNumber < jumpProbability && !jumping) {
            jumping = true;
            jumpStartTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            GetComponent<AudioSource>().Play();
            randomNumber = UnityEngine.Random.Range(0, 3);
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

        if (jumping)
        {
            long now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            double animationLength = anim.GetCurrentAnimatorStateInfo(0).length / anim.GetCurrentAnimatorStateInfo(0).speedMultiplier * 1000f;
            double animationLengthHalf = animationLength / 2.0f;
            double interval = animationLengthHalf * hitBoxInterval;
            double animationTimeHalf = jumpStartTimestamp + animationLengthHalf;
            double upper = animationTimeHalf +  interval;
            double lower = animationTimeHalf - interval;
            if (now >= lower && now <= upper)
            {
                parentBoxCollider.enabled = true;

            } else if(parentBoxCollider.enabled)
            {
                parentBoxCollider.enabled = false;

            }
        }
    }
}