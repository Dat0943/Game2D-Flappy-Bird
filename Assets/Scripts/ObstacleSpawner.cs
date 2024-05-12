using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

	[SerializeField] private float waitTime;
	float timer;

	private void Start()
	{
		Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
	}

	private void Update()
	{
		if (GameManager.Instance.isStart)
		{
			timer += Time.deltaTime;

			while(timer > waitTime)
			{
				GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
				obstacle.transform.position += Vector3.up * Random.Range(-2f, 1f);
				timer = 0;
			}
		}
	}
}
