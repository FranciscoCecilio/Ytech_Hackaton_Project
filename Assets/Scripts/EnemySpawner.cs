using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float maxTime = 5;
    public float changeTime = 10;
    private float spawnTimer = 0;
    private float changeSpeedTimer = 0;
    public float offsetSpeed = 0.5f;
    public GameObject[] selectorArr;
    public float enemyDifficulty = 1f; // represents the speed of enenimes
    public float height;
    float width = 5;
    // Start is called before the first frame update
    void Start()
    {
        int numObjects = selectorArr.Length;
        int selectedEnemy = Random.Range(0, numObjects);
        GameObject newEnemy = Instantiate(selectorArr[selectedEnemy]);
        newEnemy.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > maxTime) {
            SpawnEnemy();
            spawnTimer = 0;

        }
        Debug.Log(maxTime);
        
        if (changeSpeedTimer > changeTime ) {
            if(maxTime >= 1f) maxTime -= offsetSpeed;
            enemyDifficulty += 0.1f;
            changeSpeedTimer = 0;
        }

        spawnTimer += Time.deltaTime;
        changeSpeedTimer += Time.deltaTime;
    }

    void SpawnEnemy(){
        int numObjects = selectorArr.Length;
        int selectedEnemy = Random.Range(0, numObjects );
        GameObject newEnemy = Instantiate(selectorArr[selectedEnemy]);
        newEnemy.transform.position = transform.position + new Vector3(Random.Range(0, width), Random.Range(-height, height), -1);
        newEnemy.GetComponent<MoveEnemy>().IncreaseDifficulty(enemyDifficulty);
        Destroy(newEnemy, 15);
    }
}
