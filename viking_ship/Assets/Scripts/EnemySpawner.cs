using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject KingObject;

    public Transform[] spawnPoints;

    public int attackPower = 2;
    public int HP = 50;
    public int enemyCount = 10;

    private List<GameObject> enemies = new List<GameObject>();
    EnemyAI enemyAI;

    // Update is called once per frame
    void Update()
    {
        if (true) //퀘스트 시작조건
        {
            SpawnEnemy();

            if (enemies.Count <= 0)
            {
                //퀘스트 완료
            }
        }
        
    }
    private void SpawnEnemy()
    {

        int spawnCount = enemyCount;
        GameObject gameObject = enemyObject;
        // spawnCount 만큼 적을 생성
        for (int i = 0; i < spawnCount; i++)
        {
            // 적 생성
            CreateEnemy(gameObject);
        }
    }
    private void CreateEnemy(GameObject gameObject)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // 적 생성
        gameObject = Instantiate(enemyObject, spawnPoint.position, spawnPoint.rotation);
        // 생성된 적을 리스트에 추가
        enemies.Add(gameObject);

    }
}
