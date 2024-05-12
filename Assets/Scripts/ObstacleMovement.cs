using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed;

	private void Update()
	{
		if (GameManager.Instance.isStart)
		{
			if(GameManager.Instance.score < 10)
			{
				transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
			}
			else if(GameManager.Instance.score >= 10)
			{
				speed = 3;
				transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Constants.DEADZONE_TAG)
		{
			Destroy(gameObject);
		}
	}
}
