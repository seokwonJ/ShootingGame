using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBoss : MonoBehaviour
{
    public float currTime = 0f;
    public float currTime1 = 0f;
    public float currTime2 = 0f;
    public float currentTime2 = 0f;
    public float creatTime = 30f;
    public float skilltiming = 0;
    GameObject player;
    public GameObject Ebullet;
    public GameObject roc;
    public float enemySpeed = 1f;
    Vector3 dir;
    public GameObject firePos;
    public GameObject fis;
    public GameObject Enemy;
    public bool isFire = false;
    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        // 만약에 player 를 잘 찾았다면
        if (player != null)
        { 
            dir = player.transform.position - transform.position;

            dir.Normalize();
        }

        currTime += Time.deltaTime;
        currTime1 += Time.deltaTime;
        currTime2 += Time.deltaTime;
        if (currTime > creatTime)
        {

            skilltiming += 1;
            currTime = 0;
            GameObject edd = Instantiate(Enemy);
            edd.transform.position = transform.position;
            edd.transform.forward = dir.normalized;
        }
        transform.position += dir * enemySpeed * Time.deltaTime;

        if (currTime1>5)
        {
            currTime1 = 0;
            isFire = true;
        }
        if (currTime2 > 7)
        {
            currTime2 = 0;
            Fire3602();
        }


        Fire360();
    }

    void Fire360()
    {
        if (isFire == true)
        {

            // 0.5초 마다 한번식 총알을 발사 (회전 총알)
            currentTime2 += Time.deltaTime;
            if (currentTime2 > 0.1f)
            {
                GameObject bullet = Instantiate(fis);

                // 총알을 1개 만들자
                //GameObject b = Instantiate(bulletFactory);
                // firePos를 z축으로 45도 회전시키자
                firePos.transform.Rotate(0, 23, 0);
                // 불렛이 바라보는 방향으로 가고 싶다.
                bullet.transform.forward = firePos.transform.forward;
                // firePos의 up 방향으로 1.5만큼 떨어진 위치를 계산하자
                bullet.transform.position = transform.position + firePos.transform.up * 1.5f;

                currentTime2 = 0;
                cnt++;
                if (cnt > 15)
                {
                    isFire = false;
                    cnt = 0;
                }

            }
        }
    }

    void Fire3602()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject bullet = Instantiate(fis);

            // 총알을 1개 만들자
            //GameObject b = Instantiate(bulletFactory);
            // firePos를 z축으로 45도 회전시키자
            firePos.transform.Rotate(0, 39, 0);
            // 불렛이 바라보는 방향으로 가고 싶다.
            bullet.transform.forward = firePos.transform.forward;
            // firePos의 up 방향으로 1.5만큼 떨어진 위치를 계산하자
            bullet.transform.position = transform.position + firePos.transform.up * 1.5f;
        }
    }
}
