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
		_planeSize = GameObject.Find("Game(Clone)").GetComponent<RectTransform>();
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
		Vector3 vectorForce = new Vector3(asteroidForceX, asteroidForsceY);
		_asteroid.GetComponent<Rigidbody>().AddForce(vectorForce * _asteroidForce);
	}

	private void TeleportsAsteroidOnLimit()
	{
		if (_asteroid.transform.position.x > _planeSize.transform.position.x * 2)
		{
			_asteroid.transform.position = new Vector3(0f, _asteroid.transform.position.y);
		}

		if (_asteroid.transform.position.x < 0)
		{
			_asteroid.transform.position = new Vector3(_planeSize.transform.position.x * 2, _asteroid.transform.position.y);
		}

		if (_asteroid.transform.position.y > _planeSize.transform.position.y * 2)
		{
			_asteroid.transform.position = new Vector3(_asteroid.transform.position.x, 0f);
		}

		if (_asteroid.transform.position.y < 0)
		{
			_asteroid.transform.position = new Vector3(_asteroid.transform.position.x, _planeSize.transform.position.y * 2);
		}
	}
}
