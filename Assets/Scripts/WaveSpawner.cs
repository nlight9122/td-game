using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAliveCount = 0;

	public EnemiesWave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public Text waveCountdownText;

	public GameStateManager gameStateManager;

	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAliveCount > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameStateManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		EnemiesWave enemiesWave = waves[waveIndex];

		EnemiesAliveCount = enemiesWave.enemiesCount;

		for (int i = 0; i < enemiesWave.enemiesCount; i++)
		{
			SpawnEnemy(enemiesWave.enemy);
			yield return new WaitForSeconds(1f / enemiesWave.spawnRate);
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
