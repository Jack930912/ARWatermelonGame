
using UnityEngine;

public class WatermelonManager : MonoBehaviour {
    public GameObject watermelonPrefab;
    public Transform[] spawnPoints;
    public Animator characterAnimator;
    public AudioSource audioSource;
    public AudioClip eatSound;
    public int maxCount = 5;
    int count = 0;

    void Start() {
        SpawnNext();
    }

    public void SpawnNext() {
        if (count >= maxCount) {
            characterAnimator.SetTrigger("Burp");
            return;
        }
        count++;
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(watermelonPrefab, spawnPoints[index].position, Quaternion.identity);
    }

    public void OnEaten() {
        characterAnimator.SetTrigger("Eat");
        audioSource.PlayOneShot(eatSound);
        Invoke(nameof(SpawnNext), 0.5f);
    }
}
