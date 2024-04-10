using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    // This method will be called by the animation event
    public void ResetTrigger()
    {
        // Get a reference to the Animator component attached to the same GameObject
        Animator animator = GetComponent<Animator>();

        // Reset the trigger named "TriggerAnimation"
        animator.ResetTrigger("TriggerAnimation");
    }
}