using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the "Drink" animation
            anim.SetTrigger("Drink");
        }
    }
}