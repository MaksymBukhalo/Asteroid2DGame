using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControlMove : MonoBehaviour
{
	[SerializeField] private GameObject _asteroid;

	private float _asteroidForce = 70f;
	private RectTransform _planeSize;

	void Start()
	{
		_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
		AddForceAsteroid();
	}

	private void Update()
	{
		TeleportsAsteroidOnLimit();
	}

	private void AddForceAsteroid()
	{
		float asteroidForceX = Random.Range(-5f, 5f);
		float asteroidForsceY = Random.Range(-5f, 5f);
		Vector3 vectorForce = new Vector3(asteroidForceX, asteroidForsceY,0f);
		_asteroid.GetComponent<Rigidbody>().AddForce(vectorForce * _asteroidForce);
	}

	private void TeleportsAsteroidOnLimit()
	{
		float sizeScaleX = _planeSize.sizeDelta.x / 2;
		float sizeScaleY = _planeSize.sizeDelta.y / 2;
		if (_asteroid.transform.position.x > sizeScaleX)
		{
			_asteroid.transform.position = new Vector3(-sizeScaleX, _asteroid.transform.position.y);
		}

		if (_asteroid.transform.position.x < -sizeScaleX)
		{
			_asteroid.transform.position = new Vector3(sizeScaleX, _asteroid.transform.position.y);
		}

		if (_asteroid.transform.position.y > sizeScaleY)
		{
			_asteroid.transform.position = new Vector3(_asteroid.transform.position.x, -sizeScaleY);
		}

		if (_asteroid.transform.position.y < -sizeScaleY)
		{
			_asteroid.transform.position = new Vector3(_asteroid.transform.position.x, sizeScaleY);
		}
	}
}
