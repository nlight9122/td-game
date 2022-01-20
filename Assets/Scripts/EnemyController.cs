using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class EnemyController : MonoBehaviour {
	private Enemy enemy;

	private int pathPointIndex = 0;
	private Transform target;
	
	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = AIPath.pathPoints[0];
	}

	void Update()
	{
		Vector3 dir = (target.position - transform.position).normalized;
		transform.Translate(dir * enemy.currentSpeed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.currentSpeed = enemy.startSpeed;
	}

	void GetNextWaypoint()
	{
		if (pathPointIndex >= AIPath.pathPoints.Length - 1)
		{
			EndPath();
			return;
		}

		pathPointIndex++;
		target = AIPath.pathPoints[pathPointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAliveCount--;
		Destroy(gameObject);
	}

}
