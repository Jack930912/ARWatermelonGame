using UnityEngine;
using UnityEngine.UI;  // 如果你是使用 Text（不是 TMP），用這個
using TMPro;           // 如果你用 TextMeshPro（推薦），用這個

public class WatermelonManager : MonoBehaviour
{
    public GameObject watermelonPrefab;
    public Transform[] spawnPoints;
    public Animator characterAnimator;
    public AudioSource audioSource;
    public AudioClip eatSound;

    public TMP_Text watermelonCounterText;   // 把 TextMeshPro UI 元件拖進來

    private int currentCount = 0;
    public int maxCount = 5;

    void Start()
    {
        UpdateUI(); // 初始化
        SpawnNext();
    }

    public void SpawnNext()
    {
        if (currentCount >= maxCount)
        {
            characterAnimator.SetTrigger("Burp");
            watermelonCounterText.text = "🍉 Good job！";
            return;
        }

        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(watermelonPrefab, spawnPoints[index].position, Quaternion.identity);
    }

    public void OnEaten()
    {
        characterAnimator.SetTrigger("Eat");
        audioSource.PlayOneShot(eatSound);
        currentCount++;
        UpdateUI();
        Invoke(nameof(SpawnNext), 0.5f);
    }

    void UpdateUI()
    {
        watermelonCounterText.text = "🍉score：" + currentCount;
    }
}
