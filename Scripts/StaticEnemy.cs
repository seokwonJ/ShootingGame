using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public float currTime = 0f;
    public float creatTime = 3f;
    // 속력
    public float enemySpeed = 1;
    public GameObject Ebullet;
    // 이동 방향
    Vector3 dir;

    // 플레이어
    GameObject player;


    // public Transform trModel;

    void Start()
    {
        enemySpeed = Random.Range(3f, 5f);

        player = GameObject.Find("Player");

        // 만약에 player 를 잘 찾았다면
        if (player != null)
        {

            dir = player.transform.position - transform.position;

            dir.Normalize();

            // 모양의 윗방향을 dir로 세팅
            // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
            //Destroy(gameObject, 10);
        }
    }

    void Update()
    {
        player = GameObject.Find("Player");

        // 만약에 player 를 잘 찾았다면
        if (player != null)
        {

            dir = player.transform.position - transform.position;

            dir.Normalize();

            // 모양의 윗방향을 dir로 세팅
            // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
            //Destroy(gameObject, 10);
        }
        // 2. 그 방향으로 움직이고 싶다.

        currTime += Time.deltaTime;
        transform.position += dir * enemySpeed * Time.deltaTime;
        if (currTime > creatTime)
        {
            currTime = 0;
            GameObject eb = Instantiate(Ebullet);
            eb.transform.position = transform.position;
            eb.transform.forward = dir;
        }
        //아래로 계속 움직이고 싶다. 
        // P = P0 + vt(v 아래)
        //transform.position += Vector3.down * enemySpeed * Time.deltaTime;

    }
}
