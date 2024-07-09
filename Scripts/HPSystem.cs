using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HPSystem : MonoBehaviour
{

    // 최대 HP
    public float maxHP = 500;
    // 현재 HP
    public float currHP = 0;
    // HP bar UI
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        // 현재 HP를 최대 HP로 하자.
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // HP bar를 갱신하자.
        // 0 ~ 1
        //hpBar.fillAmount = currHP / maxHP;
        //hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currHP / maxHP, 10 * Time.deltaTime);
        hpBar.fillAmount = currHP / maxHP;
        if (currHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // 현재 HP를 증감하는 함수
    public void UpdateHP(float value)
    {
        // 현재 HP value 더하자.
        currHP += value;
        // 현재 HP가 0이면 
        if (currHP <= 0)
        {
            // 파괴하자.
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            currHP -= 10;
        }
    }
    private void OnDestroy()
    {
        // 게임오버 화면으로 전환
        SceneManager.LoadScene("next");
    }
}
