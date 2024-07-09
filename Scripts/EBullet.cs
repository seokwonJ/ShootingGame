using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    GameObject player;
    public int Speed;
    private Vector3 dir;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        pos = player.transform.position;

        dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dir.Normalize();
        transform.position += dir * Speed * Time.deltaTime;
        if (Vector3.Distance(pos,transform.position) < 2)
        {
            Destroy(gameObject);
        }
    }
}
