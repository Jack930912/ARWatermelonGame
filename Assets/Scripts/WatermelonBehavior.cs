using UnityEngine;

public class WatermelonBehavior : MonoBehaviour
{
    public AudioClip eatSound;
    private AudioSource audioSource;
    private bool eaten = false;

    void Start()
    {
        // 找角色身上的 AudioSource，記得角色要加 tag "Player"
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eaten && other.CompareTag("Player"))
        {
            eaten = true;

            // 撥放聲音
            if (eatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // 消除西瓜
            Destroy(gameObject);
        }
    }
}
