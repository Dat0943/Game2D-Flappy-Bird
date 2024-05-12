using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingGround : MonoBehaviour
{
	Renderer groundRenderer;

	[SerializeField] private float ScrollSpeed;

	private void Awake()
	{
		groundRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		// Time.time: thời gian bắt đầu chơi game
		groundRenderer.material.mainTextureOffset = new Vector2(ScrollSpeed * Time.time, 0);
	}
}
