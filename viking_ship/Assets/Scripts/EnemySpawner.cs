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
        if (true) //����Ʈ ��������
        {
            SpawnEnemy();

            if (enemies.Count <= 0)
            {
                //����Ʈ �Ϸ�
            }
        }
        
    }
    private void SpawnEnemy()
    {

        int spawnCount = enemyCount;
        GameObject gameObject = enemyObject;
        // spawnCount ��ŭ ���� ����
        for (int i = 0; i < spawnCount; i++)
        {
            // �� ����
            CreateEnemy(gameObject);
        }
    }
    private void CreateEnemy(GameObject gameObject)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        // �� ����
        gameObject = Instantiate(enemyObject, spawnPoint.position, spawnPoint.rotation);
        // ������ ���� ����Ʈ�� �߰�
        enemies.Add(gameObject);

    }
}
