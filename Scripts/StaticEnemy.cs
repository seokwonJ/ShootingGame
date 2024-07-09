using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public float currTime = 0f;
    public float creatTime = 3f;
    // �ӷ�
    public float enemySpeed = 1;
    public GameObject Ebullet;
    // �̵� ����
    Vector3 dir;

    // �÷��̾�
    GameObject player;


    // public Transform trModel;

    void Start()
    {
        enemySpeed = Random.Range(3f, 5f);

        player = GameObject.Find("Player");

        // ���࿡ player �� �� ã�Ҵٸ�
        if (player != null)
        {

            dir = player.transform.position - transform.position;

            dir.Normalize();

            // ����� �������� dir�� ����
            // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
            //Destroy(gameObject, 10);
        }
    }

    void Update()
    {
        player = GameObject.Find("Player");

        // ���࿡ player �� �� ã�Ҵٸ�
        if (player != null)
        {

            dir = player.transform.position - transform.position;

            dir.Normalize();

            // ����� �������� dir�� ����
            // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
            //Destroy(gameObject, 10);
        }
        // 2. �� �������� �����̰� �ʹ�.

        currTime += Time.deltaTime;
        transform.position += dir * enemySpeed * Time.deltaTime;
        if (currTime > creatTime)
        {
            currTime = 0;
            GameObject eb = Instantiate(Ebullet);
            eb.transform.position = transform.position;
            eb.transform.forward = dir;
        }
        //�Ʒ��� ��� �����̰� �ʹ�. 
        // P = P0 + vt(v �Ʒ�)
        //transform.position += Vector3.down * enemySpeed * Time.deltaTime;

    }
}
