using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Rozmiar obszaru spawnu")]
    public Vector3 spawnerSize = new Vector3(1, 1, 1);

    [Header("Częstotliwość spawnu (s)")]
    public float spawnRate = 1f;

    [Header("Prefab asteroidy")]
    [SerializeField] private GameObject asteroidPrefab;

    private float spawnTimer;

    /* Ramka spawnera */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);  
        Gizmos.DrawWireCube(transform.position, spawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            Debug.Log("Spawning asteroid");
            SpawnAsteroid();
            spawnTimer = 0f;
        }
    }

    /* Losowe położenie wewnątrz prostopadłościanu o wymiarach spawnerSize */
    private void SpawnAsteroid()
    {
        if (asteroidPrefab == null) return;

        Vector3 spawnPoint = new Vector3(
            UnityEngine.Random.Range(-spawnerSize.x * 0.5f, spawnerSize.x * 0.5f),
            UnityEngine.Random.Range(-spawnerSize.y * 0.5f, spawnerSize.y * 0.5f),
            UnityEngine.Random.Range(-spawnerSize.z * 0.5f, spawnerSize.z * 0.5f)
        );

        Vector3 spawnPos = transform.position + spawnPoint;
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity, transform);

        asteroid.transform.SetParent(this.transform);
    }
}
