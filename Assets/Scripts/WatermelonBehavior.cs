using UnityEngine;

public class WatermelonBehavior : MonoBehaviour
{
    public AudioClip eatSound;
    private AudioSource audioSource;
    private bool eaten = false;

    void Start()
    {
        // �䨤�⨭�W�� AudioSource�A�O�o����n�[ tag "Player"
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eaten && other.CompareTag("Player"))
        {
            eaten = true;

            // �����n��
            if (eatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // �������
            Destroy(gameObject);
        }
    }
}
