using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject KingObject;

    public Transform[] spawnPoints;
    public int enemyCount = 10;
    public float delayTime = 5.0f;

    private List<GameObject> enemies = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
        if (true) //퀘스트 시작조건
        {
            StartCoroutine("SpawnEnemy");
        }
    }
    void Update()
    {
        if (enemies.Count <= 0)
        {
            //퀘스트 완료
        }
    }
    private IEnumerator SpawnEnemy()
    {
        GameObject gameObject = enemyObject;
        // spawnCount 만큼 적을 생성
        for (int i = 0; i < enemyCount; i++)
        {
            // 적 생성
            if (i == enemyCount -1 ) { 
                gameObject = KingObject;
            }
            CreateEnemy(gameObject);
            
        }
        yield return new WaitForSeconds(delayTime);
    }
    
    private void CreateEnemy(GameObject gameObject)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // 적 생성
        GameObject instance = Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
        Debug.Log(spawnPoint.position, instance);
        // 생성된 적을 리스트에 추가
        enemies.Add(instance);
        // 사망한 적을 리스트에서 제거
        if(instance.active == false)  enemies.Remove(instance);
    }
}
