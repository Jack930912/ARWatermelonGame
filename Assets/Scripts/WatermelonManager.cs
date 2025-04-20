
using UnityEngine;
using TMPro;
using System.Collections;

public class WatermelonManager : MonoBehaviour
{
    public GameObject watermelonPrefab;
    public Transform[] spawnPoints;
    public TMP_Text watermelonCounterText;

    private int totalEaten = 0;
    private GameObject[] spawnedWatermelons;

    void Start()
    {
        spawnedWatermelons = new GameObject[spawnPoints.Length];
        SpawnAll();
        UpdateUI();
    }

    void SpawnAll()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnWatermelonAt(i);
        }
    }

    void SpawnWatermelonAt(int index)
    {
        if (spawnedWatermelons[index] == null)
        {
            Vector3 spawnPosition = spawnPoints[index].position;
            spawnPosition.y = -2f; // 固定在 Y = -2
            GameObject melon = Instantiate(watermelonPrefab, spawnPosition, Quaternion.identity);
            melon.tag = "watermelon";

            WatermelonBehavior behavior = melon.GetComponent<WatermelonBehavior>();
            behavior.spawnIndex = index;
            behavior.manager = this;

            spawnedWatermelons[index] = melon;
        }
    }

    public void OnEaten(int index)
    {
        totalEaten++;
        UpdateUI();
        spawnedWatermelons[index] = null;
        StartCoroutine(RespawnWatermelon(index, Random.Range(10f, 15f)));
    }

    IEnumerator RespawnWatermelon(int index, float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnWatermelonAt(index);
    }

    void UpdateUI()
    {
        if (watermelonCounterText != null)
        {
            watermelonCounterText.text = "Watermelons eaten: " + totalEaten;
        }
    }
}
