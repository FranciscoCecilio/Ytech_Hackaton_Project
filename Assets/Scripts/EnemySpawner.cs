using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float maxTime = 2;
    private float timer = 0;
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
        if (timer > maxTime) {
            int numObjects = selectorArr.Length;
            int selectedEnemy = Random.Range(0, numObjects );
            GameObject newEnemy = Instantiate(selectorArr[selectedEnemy]);
            newEnemy.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), -1);
            Destroy(newEnemy, 15);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
