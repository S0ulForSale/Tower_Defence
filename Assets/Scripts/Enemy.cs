using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Transform target;
    private int wavepointIndex = 0;

    public int value = 50;

    public float starthealth = 100;

    private float health;

    public Image Healthbar;

    private void Start()
    {
        target = WayPoints.points[0];
        health = starthealth;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        Healthbar.fillAmount = health/starthealth ;
        if (health <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += value;
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }
    void EndPath()
    {
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
