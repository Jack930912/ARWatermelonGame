using UnityEngine;

public class WatermelonBehavior : MonoBehaviour
{
    public AudioClip eatSound;              // 吃的音效（從 Inspector 拖進來）
    private AudioSource audioSource;        // 負責播放音效的 AudioSource
    private bool eaten = false;

    void Start()
    {
        // 從角色（Tag 為 Player）抓出 AudioSource
        audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!eaten && other.CompareTag("Player"))
        {
            eaten = true;

            // 播放吃的音效（瞬間）
            if (eatSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(eatSound);
            }

            // 消除西瓜（或播放特效）
            Destroy(gameObject);
        }
    }
}
