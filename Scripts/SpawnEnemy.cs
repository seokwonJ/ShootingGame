using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    float currTime = 0;
    float createTime = 0;
    public GameObject enemy;
    void Start()
    {
        createTime = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > createTime)
        {
            createTime = Random.Range(5f, 10f);
            GameObject En = Instantiate(enemy);
            En.transform.position = transform.position;
            currTime = 0;
        }
        
    }
}
