using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]
	public float currentSpeed;

	[Header("Unity Stuff")]
	public Image healthBar;
	
	public float startHealth = 100;

	public int worth = 50;

	public GameObject deathEffect;

	private float currentHealth;
	private bool isDead = false;
	
	void Start ()
	{
		currentSpeed = startSpeed;
		currentHealth = startHealth;
	}

	public void TakeDamage (float amount)
	{
		currentHealth -= amount;

		healthBar.fillAmount = currentHealth / startHealth;

		if (!isDead && currentHealth <= 0)
		{
			DestroyEnemy();
		}
	}

	public void Slow (float pct)
	{
		currentSpeed = startSpeed * (1f - pct);
	}

	void DestroyEnemy ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAliveCount--;

		Destroy(gameObject);
	}

}
