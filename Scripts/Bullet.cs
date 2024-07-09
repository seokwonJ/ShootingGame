using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Accessibility;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10f;
    Vector3 dir;
    private Vector3 attackDirection;
    Vector3 po;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

        //po = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hit, 100f))
        {
            // 공격 방향 설정
            attackDirection = (hit.point - transform.position).normalized;
            print(hit);
        }

    }
    // Update is called once per frame
    void Update()
    {
       
        transform.position += attackDirection * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(transform.position, hit.point)<2)
        {
            Destroy(gameObject);
        }
    }
}
