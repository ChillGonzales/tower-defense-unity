using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    public Transform SpawnPoint;
    public Text waveCountDownText;
    public static List<GameObject> Enemies;

    public float timeBetweenWaves = 5f;

    private float countDown = 2f;
    private int waveIndex = 0;

    private void Start()
    {
        Enemies = new List<GameObject>();
    }

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    private IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        Enemies.Add(enemy);
        enemy.GetComponent<Enemy>().DeathNotification = () => { Enemies.Remove(enemy); };
    }
}
