using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject humanPrefab;
    private float humanSpawnInterval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemies(humanSpawnInterval, humanPrefab));
    }

    private IEnumerator spawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(this.transform.position.x,this.transform.position.y, 0), Quaternion.identity);
        StartCoroutine(spawnEnemies(interval, enemy));
    }
}
