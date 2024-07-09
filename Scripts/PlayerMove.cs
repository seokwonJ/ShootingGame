using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public GameObject body;
    public int hh = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dirH = Vector3.left * h;
        Vector3 dirV = Vector3.back * v;
        Vector3 dir = dirH + dirV;

        // dir �� ũ�⸦ 1�� ������.
        dir.Normalize();

        //Vector3 viewPortPoint = Camera.main.WorldToViewportPoint(transform.position);


        // ���࿡ viewportPoint.x �� ���� 0���� ������ -- ����
        //if (viewPortPoint.x < 0 || viewPortPoint.x > 1 || viewPortPoint.y < 0 || viewPortPoint.y > 1)
        //{
            // �̵��� ��ŭ �ǵ�����.
            transform.position -= dir * moveSpeed * Time.deltaTime;
        //}
        if (Input.GetKeyDown(KeyCode.H))
        {
            body.SetActive(true);
            hh = 0;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            hh = 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyB" && hh == 1)
        {
            body.SetActive(false);
        }
    }
}
