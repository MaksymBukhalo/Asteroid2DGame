using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBonus : MonoBehaviour
{
	[SerializeField] private GameObject _bonus;

	private RectTransform _planeSize;

	void Start()
	{
		_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
	}

	private void Update()
	{
		TeleportsBonusOnLimit();
	}

	private void TeleportsBonusOnLimit()
	{
		float sizeScaleX = _planeSize.sizeDelta.x / 2 * _planeSize.transform.localScale.x;
		float sizeScaleY = _planeSize.sizeDelta.y / 2 * _planeSize.transform.localScale.y;
		if (_bonus.transform.position.x > sizeScaleX)
		{
			_bonus.transform.position = new Vector3(-sizeScaleX, _bonus.transform.position.y);
		}

		if (_bonus.transform.position.x < -sizeScaleX)
		{
			_bonus.transform.position = new Vector3(sizeScaleX, _bonus.transform.position.y);
		}

		if (_bonus.transform.position.y > sizeScaleY)
		{
			_bonus.transform.position = new Vector3(_bonus.transform.position.x, -sizeScaleY);
		}

		if (_bonus.transform.position.y < -sizeScaleY)
		{
			_bonus.transform.position = new Vector3(_bonus.transform.position.x, sizeScaleY);
		}
	}
}
