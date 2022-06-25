using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAndPortalSpawner : MonoBehaviour
{

    public float maxTime = 20;
    private float time = 0.1f;
    public GameObject[] selectorArr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > maxTime) {
            int numObjects = selectorArr.Length;
            int selectedFeature = Random.Range(0, numObjects );
            GameObject feature = Instantiate(selectorArr[selectedFeature]);
            feature.transform.position = transform.position + new Vector3(0, 0, -1);
            Destroy(feature, 15);
            time = 0;

        }
         time += Time.deltaTime;
    }
}
