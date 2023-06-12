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
        if (true) //����Ʈ ��������
        {
            StartCoroutine("SpawnEnemy");
        }
    }
    void Update()
    {
        if (enemies.Count <= 0)
        {
            //����Ʈ �Ϸ�
        }
    }
    private IEnumerator SpawnEnemy()
    {
        GameObject gameObject = enemyObject;
        // spawnCount ��ŭ ���� ����
        for (int i = 0; i < enemyCount; i++)
        {
            // �� ����
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
        // �� ����
        GameObject instance = Instantiate(gameObject, spawnPoint.position, spawnPoint.rotation);
        Debug.Log(spawnPoint.position, instance);
        // ������ ���� ����Ʈ�� �߰�
        enemies.Add(instance);
        // ����� ���� ����Ʈ���� ����
        if(instance.active == false)  enemies.Remove(instance);
    }
}
