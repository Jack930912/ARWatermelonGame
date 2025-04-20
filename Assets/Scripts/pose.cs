using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayPoseAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("DoPose");
        }
    }
}
