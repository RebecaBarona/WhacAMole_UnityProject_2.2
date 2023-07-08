using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public string animation1TriggerName;
    public string animation2TriggerName;

    private bool hasCollided;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider belongs to the object we want to interact with
        if (other.CompareTag("Interactable"))
        {
            // Check if collision has not already occurred
            if (!hasCollided)
            {
                hasCollided = true;

                // Determine which animation to trigger
                if (animation1TriggerName != null)
                {
                    animator.SetTrigger(animation1TriggerName);
                }
                else if (animation2TriggerName != null)
                {
                    animator.SetTrigger(animation2TriggerName);
                }
            }
        }
    }
}