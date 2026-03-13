using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    public int minActiveZombies = 15;
    public float spawnRadius = 20f;

    int activeZombies=0;

    void Start()
    {
        for(int i = 0; i < minActiveZombies; i++)
            SpawnZombie();
    }

    void Update()
    {
        if(activeZombies < minActiveZombies)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            0,
            Random.Range(-spawnRadius, spawnRadius)
        );

        GameObject zombie = Instantiate(zombiePrefab, randomPos, Quaternion.identity);

        zombie.GetComponent<ZombieHit>().spawner = this;

        activeZombies++;
    }

    public void ZombieKilled()
    {
        activeZombies--;
    }
}