using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	// Quan ly nhan vat
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform playerPosition;
	GameObject flappyBird;

	// UI
	[SerializeField] private GameObject getReadyPanel;
	[SerializeField] private TMP_Text scoreText;
	[SerializeField] private GameObject endGamePanel;
	[SerializeField] private GameObject mainGamePanel;
	[SerializeField] private TMP_Text bestScoreText;
	[SerializeField] private TMP_Text scoreEndText;

	//Quan ly game
	public bool isStart;
	public bool isEnd;
	public int score;
	int highScore;

	private void Awake()
	{
		if(Instance == null)
			Instance = this;
	}

	private void Start()
	{
		flappyBird = Instantiate(playerPrefabs[Random.Range(0, playerPrefabs.Length - 1)], playerPosition.position, Quaternion.identity);

		highScore = PlayerPrefs.GetInt("HighScore");
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && isEnd == false) // Click vào màn hình để chơi game thì ẩn panel, bắt đầu game
		{
			getReadyPanel.SetActive(false);
			isStart = true;
			// Nếu nhân vật rơi nhanh quá thì cho velocity về bằng 0
			flappyBird.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Cho vận tốc về bằng 0 để nhân vật rơi chậm lại
			flappyBird.GetComponent<Rigidbody2D>().gravityScale = 1;
		}

		bestScoreText.text = highScore.ToString();
		if (isEnd == true)
		{
			highScore = PlayerPrefs.GetInt("HighScore");
			SaveHighScore();
		}
	}

	public void UpdateScore()
	{
		score++;
		scoreText.text = score.ToString();
	}

	public void EndGame()
	{
		isStart = false;
		isEnd = true;
		endGamePanel.SetActive(true);
		mainGamePanel.SetActive(false);
		scoreEndText.text = score.ToString();
	}

	private void SaveHighScore()
	{
		if (score > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
}
