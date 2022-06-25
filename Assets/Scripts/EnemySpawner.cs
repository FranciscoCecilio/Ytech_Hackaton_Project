using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float maxTime = 5;
    public float changeTime = 10;
    private float spawnTimer = 0;
    private float changeSpeedTimer = 0;
    private float offsetSpeed = 0.1f;
    public GameObject[] selectorArr;
    public float height;

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
            int numObjects = selectorArr.Length;
            int selectedEnemy = Random.Range(0, numObjects );
            GameObject newEnemy = Instantiate(selectorArr[selectedEnemy]);
            newEnemy.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), -1);
            Destroy(newEnemy, 15);
            spawnTimer = 0;

        }

         if (changeSpeedTimer > changeTime && maxTime >= 0.5) {
            maxTime -= offsetSpeed;
            changeSpeedTimer = 0;
         }

        spawnTimer += Time.deltaTime;
        changeSpeedTimer += Time.deltaTime;
    }
}
