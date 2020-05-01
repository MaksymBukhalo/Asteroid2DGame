using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
	[SerializeField] private GameObject _game;
	[SerializeField] private GameObject _mainMenu;
	[SerializeField] private GameObject _nowMenu;

	private Transform _space;

	private void Start()
	{
		_space = GameObject.Find("Space").GetComponent<Transform>();
	}

	public void LoadGame()
	{
		Time.timeScale = 1;
		Destroy(_nowMenu);
		Instantiate(_game, _space);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void PlayAgainGame()
	{
		Time.timeScale = 1;
		Destroy(_nowMenu);
		Instantiate(_game, _space);
	}

	public void ReternMainMenu()
	{
		Time.timeScale = 1;
		Destroy(_nowMenu);
		Instantiate(_mainMenu, _space);
	}
}
