using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject humanPrefab;
    private float humanSpawnInterval = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies(humanSpawnInterval, humanPrefab));
    }

    private IEnumerator SpawnEnemies(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(this.transform.position.x,this.transform.position.y, 0), Quaternion.identity);
        StartCoroutine(SpawnEnemies(interval, enemy));
    }
}
