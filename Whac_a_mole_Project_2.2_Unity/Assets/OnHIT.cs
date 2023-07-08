using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            int randomNumber = Random.Range(0, 3);
            if (randomNumber == 0)
            {
                anim.Play("KO_04");
            }
            else if (randomNumber == 1)
            {
                anim.Play("KO_06");
            }
            else
            {
                anim.Play("KO_07");
            }
        }
    }
}