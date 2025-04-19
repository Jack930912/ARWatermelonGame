using UnityEngine;

public class WatermelonBehavior : MonoBehaviour
{
    public AudioClip eatSound;              // �Y�����ġ]�q Inspector ��i�ӡ^
    private AudioSource audioSource;        // �t�d���񭵮Ī� AudioSource
    private bool eaten = false;

    void Start()
    {
        // �q����]Tag �� Player�^��X AudioSource
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eaten && other.CompareTag("Player"))
        {
            eaten = true;

            // ����Y�����ġ]�����^
            if (eatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // ������ʡ]�μ���S�ġ^
            Destroy(gameObject);
        }
    }
}
