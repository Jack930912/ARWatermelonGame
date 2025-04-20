
using UnityEngine;

public class WatermelonBehavior : MonoBehaviour
{
    public AudioClip eatSound;
    public int spawnIndex;
    public WatermelonManager manager;

    private bool eaten = false;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        audioSource = player.GetComponent<AudioSource>();
        animator = player.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eaten && other.CompareTag("player"))
        {
            eaten = true;

            // Align Y
            Vector3 pos = other.transform.position;
            pos.y = transform.position.y;
            other.transform.position = pos;

            // Animation
            if (animator != null)
            {
                animator.SetTrigger("Eat");
            }

            // Sound
            if (eatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // Inform manager
            if (manager != null)
            {
                manager.OnEaten(spawnIndex);
            }

            Destroy(gameObject);
        }
    }
}
