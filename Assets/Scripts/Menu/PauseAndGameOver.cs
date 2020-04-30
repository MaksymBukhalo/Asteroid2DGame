using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndGameOver : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu;
	[SerializeField] private GameObject _gameOverMenu;
	[SerializeField] private TextInformation _life;

	private bool _isPause = false;
	private KeyCode _pauseButton = KeyCode.Escape;


	private void Update()
	{
		if (Input.GetKeyDown(_pauseButton))
		{
			StartAndEndPause();
		}

		if (_life.LifeShip == 0)
		{
			GameOver();
		}
	}

	private void StartAndEndPause()
	{
		if (!_isPause)
		{
			Time.timeScale = 0;
			_isPause = true;
			_pauseMenu.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			_isPause = false;
			_pauseMenu.SetActive(false);
		}
	}

	private void GameOver()
	{
		_gameOverMenu.SetActive(true);
		Time.timeScale = 0;
	}
}
