using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //속도

    public float health = 100; //몬스터 초기 체력

    public int worth = 50; //몬스터를 죽일 시 플레이어에게 주어질 돈

    public GameObject deathEffect;

    public void TakeDamage(float amount)
    {
        health -= amount; //amount 만큼 체력 감소

        if(health <= 0)
        {
            Die(); // 에너미 사망 메서드
        }
    }

    void Die()
    {
        PlayerStats.Money += worth; //플레이어에게 돈 지급

        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}