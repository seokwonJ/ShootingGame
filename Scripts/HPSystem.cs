using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HPSystem : MonoBehaviour
{

    // �ִ� HP
    public float maxHP = 500;
    // ���� HP
    public float currHP = 0;
    // HP bar UI
    public Image hpBar;

    // Start is called before the first frame update
    void Start()
    {
        // ���� HP�� �ִ� HP�� ����.
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        // HP bar�� ��������.
        // 0 ~ 1
        //hpBar.fillAmount = currHP / maxHP;
        //hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, currHP / maxHP, 10 * Time.deltaTime);
        hpBar.fillAmount = currHP / maxHP;
        if (currHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // ���� HP�� �����ϴ� �Լ�
    public void UpdateHP(float value)
    {
        // ���� HP value ������.
        currHP += value;
        // ���� HP�� 0�̸� 
        if (currHP <= 0)
        {
            // �ı�����.
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
        // ���ӿ��� ȭ������ ��ȯ
        SceneManager.LoadScene("next");
    }
}
