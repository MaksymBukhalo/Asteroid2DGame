using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellConrollMove : MonoBehaviour
{
	[SerializeField] private GameObject _shell;
	private RectTransform _planeSize;
	private float _timeLifeShell = 2f;
	private float _startLife;


	void Start()
	{
		_planeSize = GameObject.Find("Game(Clone)").GetComponent<RectTransform>();
		_startLife = Time.time;
	}

	private void Update()
	{
		TeleportsAsteroidOnLimit();
		DestroyShell();
	}

	private void TeleportsAsteroidOnLimit()
	{
		if (_shell.transform.position.x > _planeSize.transform.position.x * 2)
		{
			_shell.transform.position = new Vector3(0f, _shell.transform.position.y);
		}

		if (_shell.transform.position.x < 0)
		{
			_shell.transform.position = new Vector3(_planeSize.transform.position.x * 2, _shell.transform.position.y);
		}

		if (_shell.transform.position.y > _planeSize.transform.position.y * 2)
		{
			_shell.transform.position = new Vector3(_shell.transform.position.x, 0f);
		}

		if (_shell.transform.position.y < 0)
		{
			_shell.transform.position = new Vector3(_shell.transform.position.x, _planeSize.transform.position.y * 2);
		}

	}

	private void DestroyShell()
	{
		if (Time.time - _startLife > _timeLifeShell)
		{
			Destroy(_shell);
		}
	}
}
