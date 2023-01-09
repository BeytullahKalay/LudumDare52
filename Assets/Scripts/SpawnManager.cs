using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();

    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

    [SerializeField] private float spawnTime = 6f;

    [SerializeField] private float decreaseSpeed = 1;

    private float _lastSpawnTime = float.MinValue;


    private void Update()
    {
        if (Time.time > _lastSpawnTime + spawnTime)
        {
            var enemyToSpawn = GetRandomSpawnEnemy();
            var spawnPosition = GetRandomSpawnPositionTransform();
            Instantiate(enemyToSpawn, spawnPosition.position, enemyToSpawn.transform.rotation);

            _lastSpawnTime = Time.time;
            spawnTime -= decreaseSpeed;
            spawnTime = Mathf.Clamp(spawnTime, .75f, Mathf.Infinity);
        }
    }

    private GameObject GetRandomSpawnEnemy()
    {
        return spawnObjects[Random.Range(0, spawnObjects.Count)];
    }

    private Transform GetRandomSpawnPositionTransform()
    {
        return spawnPositions[Random.Range(0, spawnPositions.Count)];
    }
}