using UnityEngine;
using PlayerInfoManager;
using UnityEngine.UI;
using System;
using TMPro;

public class playerBlood : MonoBehaviour
{
    float HPvalue = 100;
    public GameObject gameoverView;
    public Slider bloodSlider;
    // Start is called before the first frame update
    void Start()
    {
        HPvalue = Math.Max(100, PlayerManager.Instance.myPlayer._hp);
        bloodSlider.maxValue = HPvalue;
        bloodSlider.value = HPvalue;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getDamage(float damage)
    {
        HPvalue -= damage;
        bloodSlider.value = HPvalue;

        if (HPvalue <= 0)
        {
            gameoverView.SetActive(true);
            GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>().text = GameObject.Find("GameManage").GetComponent<timerManager>().sumExp.ToString();

        }
        Debug.Log("callDamage");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT22");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log("cndehf!!!TTTEnemy22");
            if (other.GetComponent<EnemyInfo>())
                getDamage(other.GetComponent<EnemyInfo>().Damage);
            if (other.GetComponent<enemyBossSkill>())
                getDamage(other.GetComponent<enemyBossSkill>().Damage);


        }
    }

    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC22");

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("cndehf!!!CCCCCEnemy22");
            if (collision.gameObject.GetComponent<EnemyInfo>())
                getDamage(collision.gameObject.GetComponent<EnemyInfo>().Damage);
            if (collision.gameObject.GetComponent<enemyBossSkill>())
                getDamage(collision.gameObject.GetComponent<enemyBossSkill>().Damage);

        }
    }
}
