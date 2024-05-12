using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hoverDistance, hoverSpeed, force;
	float timer, y;

	Rigidbody2D rb;
	Quaternion downRotation, upRotation;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		downRotation = Quaternion.Euler(0f, 0f, -90f);
		upRotation = Quaternion.Euler(0f, 0f, 45f);
	}

	private void Update()
	{
        if (!GameManager.Instance.isStart && !GameManager.Instance.isEnd) // Nếu game chưa bắt đầu thì thay đổi vị trí cũng như animation
        {
			timer += Time.deltaTime;
			y = hoverDistance * Mathf.Sin(timer * hoverSpeed);
			transform.localPosition = new Vector3(transform.position.x, y, transform.position.z);
		}
		else
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, 1f * Time.deltaTime);
		}

		// Quy định rotation giời hạn cho bird
		transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 
			Mathf.Clamp(transform.rotation.z, downRotation.z, upRotation.z), transform.rotation.w);

		if (GameManager.Instance.isEnd)
		{
			GetComponent<PlayerController>().enabled = false;
		}
	}

	private void LateUpdate()
	{
		if (GameManager.Instance.isStart && !GameManager.Instance.isEnd)
		{
			if (Input.GetMouseButtonDown(0))
			{
				rb.AddForce(Vector2.up * force);
				transform.rotation = upRotation;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == Constants.GROUND_TAG)
		{
			rb.simulated = false; // Bỏ mô phỏng về vật lý;
			transform.rotation = downRotation;
			GetComponent<Animator>().enabled = false;
			GameManager.Instance.EndGame();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == Constants.POINT_TAG)
		{
			GameManager.Instance.UpdateScore();
		}
		else if (collision.gameObject.tag == Constants.OBSTACLE_TAG)
		{
			collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			GameManager.Instance.EndGame();
		}
	}
}
