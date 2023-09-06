using UnityEngine;

public class AstreoidSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] astreoidPrefabs;
    [SerializeField] float secondsBetweenAstreoid = 1.5f;
    [SerializeField] Vector2 forceRange;

    float timer;
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            SpawnNewAstreoid();

            timer = timer + secondsBetweenAstreoid;
        }
    }

    private void SpawnNewAstreoid()
    {
        int side = UnityEngine.Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = UnityEngine.Random.value;
                direction = new Vector2(1f, UnityEngine.Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                spawnPoint.x = UnityEngine.Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject astreoidInstance = Instantiate(
            astreoidPrefabs[Random.Range(0, astreoidPrefabs.Length)],
             worldSpawnPoint,
             Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody rb = astreoidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);

    }
}
