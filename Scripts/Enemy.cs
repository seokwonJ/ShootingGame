using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currTime = 0f;
    public float creatTime = 3f;
    // �ӷ�
    public float enemySpeed = 4;
    public GameObject Ebullet;
    // �̵� ����
    Vector3 dir;

    // �÷��̾�
    GameObject player;


    // public Transform trModel;

    void Start()
    {

        // ������ ���� ���� (0 ~ 9)
        int rand = Random.Range(0, 10);

        // ���࿡ ������ ���� 4 ���� ������ (40% Ȯ��)
        if (rand < 4)
        {
            // ������ �Ʒ��� ����.
            dir = Vector3.back;
        }
        // �׷��� ������ (������ 60% Ȯ��)
        else
        {
            // �÷��̾ ã��
            player = GameObject.Find("Player");

            // ���࿡ player �� �� ã�Ҵٸ�
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

        // ����� �������� dir�� ����
        // trModel.rotation = Quaternion.LookRotation(Vector3.down, dir);
        //Destroy(gameObject, 10);
    }

    void Update()
    {
        // 2. �� �������� �����̰� �ʹ�.
        transform.position += dir * enemySpeed * Time.deltaTime;
        currTime += Time.deltaTime;
        if (currTime > creatTime)
        {
            currTime = 0;
            GameObject eb = Instantiate(Ebullet);
            eb.transform.position = transform.position;
        }
        //�Ʒ��� ��� �����̰� �ʹ�. 
        // P = P0 + vt(v �Ʒ�)
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
