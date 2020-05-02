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
		_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
		_startLife = Time.time;
	}

	private void Update()
	{
		TeleportsAsteroidOnLimit();
		DestroyShell();
	}

	private void TeleportsAsteroidOnLimit()
	{
		float sizeScaleX = _planeSize.sizeDelta.x / 2 * _planeSize.localScale.x;
		float sizeScaleY = _planeSize.sizeDelta.y / 2 * _planeSize.localScale.y;
		if (_shell.transform.position.x > sizeScaleX)
		{
			_shell.transform.position = new Vector3(-sizeScaleX, _shell.transform.position.y);
		}

		if (_shell.transform.position.x < -sizeScaleX)
		{
			_shell.transform.position = new Vector3(sizeScaleX, _shell.transform.position.y);
		}

		if (_shell.transform.position.y > sizeScaleY)
		{
			_shell.transform.position = new Vector3(_shell.transform.position.x, -sizeScaleY);
		}

		if (_shell.transform.position.y < -sizeScaleY)
		{
			_shell.transform.position = new Vector3(_shell.transform.position.x, sizeScaleY);
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
