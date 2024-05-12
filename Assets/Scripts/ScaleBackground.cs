using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Camera camera;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		camera = Camera.main;

		// Lấy kích thước của camera
		float cameraHeight = 2f * camera.orthographicSize;
		float cameraWidth = cameraHeight * camera.aspect;

		// Lấy kích thước của BG hiện tại
		float bgHeight = spriteRenderer.sprite.bounds.size.y;
		float bgWidth = spriteRenderer.sprite.bounds.size.x;

		//Tỉ lệ Scale;
		float scaleX = cameraWidth / bgWidth;
		float scaleY = cameraHeight / bgHeight;

		transform.localScale = new Vector3(scaleX, scaleY, 1f);
	}
}
