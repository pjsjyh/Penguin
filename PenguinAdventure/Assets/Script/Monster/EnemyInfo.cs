using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

    public float Damage = 10f;
    public float Blood = 50f;
    public float ExperienceCapacity = 10;

    public GameObject experienceObj;
    public float DamageGet()
    {
        return Damage;
    }
    public void DamageSet(float dam)
    {
        Blood = Blood - dam;
        if (Blood < 0)
        {
            Instantiate(experienceObj, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("cndehf!!!TTT" + other.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

    // 일반 충돌 감지 (Trigger가 아닐 때)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("cndehf!!!CCCCC" + collision.gameObject.name);

        // 충돌한 오브젝트가 "sun" 태그를 가지고 있는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerBlood>().getDamage(Damage);

        }
    }

}
