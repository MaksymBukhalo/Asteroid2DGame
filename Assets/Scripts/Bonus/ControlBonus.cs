using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBonus : MonoBehaviour
{
	[SerializeField] private GameObject _bonus;

	private RectTransform _planeSize;

	void Start()
	{
		_planeSize = GameObject.Find("Game(Clone)").GetComponent<RectTransform>();
	}

	private void Update()
	{
		TeleportsBonusOnLimit();
	}

	private void TeleportsBonusOnLimit()
	{
		if (_bonus.transform.position.x > _planeSize.transform.position.x * 2)
		{
			_bonus.transform.position = new Vector3(0f, _bonus.transform.position.y);
		}

		if (_bonus.transform.position.x < 0)
		{
			_bonus.transform.position = new Vector3(_planeSize.transform.position.x * 2, _bonus.transform.position.y);
		}

		if (_bonus.transform.position.y > _planeSize.transform.position.y * 2)
		{
			_bonus.transform.position = new Vector3(_bonus.transform.position.x, 0f);
		}

		if (_bonus.transform.position.y < 0)
		{
			_bonus.transform.position = new Vector3(_bonus.transform.position.x, _planeSize.transform.position.y * 2);
		}
	}
}
