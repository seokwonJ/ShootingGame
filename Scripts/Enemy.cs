using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currTime = 0f;
    public float creatTime = 3f;
    // 속력
    public float enemySpeed = 4;
    public GameObject Ebullet;
    // 이동 방향
    Vector3 dir;

    // 플레이어
    GameObject player;


    // public Transform trModel;

    void Start()
    {

        // 랜덤한 값을 뽑자 (0 ~ 9)
        int rand = Random.Range(0, 10);

        // 만약에 랜덤한 값이 4 보다 작으면 (40% 확률)
        if (rand < 4)
        {
            // 방향을 아래로 하자.
            dir = Vector3.back;
        }
        // 그렇지 않으면 (나머지 60% 확률)
        else
        {
            // 플레이어를 찾자
            player = GameObject.Find("Player");

            // 만약에 player 를 잘 찾았다면
            if (player != null)
            {
                
                dir = player.transform.position - transform.position;

                dir.Normalize();
            }
            else
            {
               dir = Vector3.back;
            }
        }

        // 모양의 윗방향을 dir로 세팅
        // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
        //Destroy(gameObject, 10);
    }

    void Update()
    {
        // 2. 그 방향으로 움직이고 싶다.
        transform.position += dir * enemySpeed * Time.deltaTime;
        currTime += Time.deltaTime;
        if (currTime > creatTime)
        {
            currTime = 0;
            GameObject eb = Instantiate(Ebullet);
            eb.transform.position = transform.position;
        }
        //아래로 계속 움직이고 싶다. 
        // P = P0 + vt(v 아래)
        //transform.position += Vector3.down * enemySpeed * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
