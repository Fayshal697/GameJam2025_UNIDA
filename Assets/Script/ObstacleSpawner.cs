using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;
    public float spawnOffsetX = 15f;

    [Header("Spawn Points")]
    public Transform bottomLane;
    public Transform topLane;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);

        // Pilih lane random
        Transform lane = Random.value > 0.5f ? bottomLane : topLane;

        Vector3 spawnPos = new Vector3(
            lane.position.x + spawnOffsetX,
            lane.position.y
        );

        Instantiate(obstaclePrefabs[index], spawnPos, Quaternion.identity);
    }
}
