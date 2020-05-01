using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAsteroid : MonoBehaviour
{
	[SerializeField] private ListAsteroid _asteroids;
	
	private Transform _parent;
	private RectTransform _planeSize;
	private int _amoutAsteroids;

	private void Start()
	{
		_amoutAsteroids = Random.Range(5, 10);
	}

	private void Update()
	{
		if (!GameObject.Find("Asteroid(Clone)"))
		{
			_parent = GameObject.Find("Game").GetComponent<Transform>();
			NewSizeAsterods(75f);
			InstantiateAsteroids();
		}
	}

	private void InstantiateAsteroids()
	{
		for (int i = 0; i < _amoutAsteroids; i++)
		{
			if (i < _amoutAsteroids / 2)
			{
				_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
				float positionYAsteroid = Random.Range(-(_planeSize.sizeDelta.y / 2), _planeSize.sizeDelta.y / 2);
				GameObject asteroid = _asteroids.AsteroidList[Random.Range(0, 5)];
				asteroid.transform.position = new Vector3(_planeSize.sizeDelta.x / 2, positionYAsteroid);
				asteroid.name = "Asteroid";
				Instantiate(asteroid, _parent);
			}

			if (i > _amoutAsteroids / 2)
			{
				_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
				float positionXAsteroid = Random.Range(-(_planeSize.sizeDelta.x / 2), _planeSize.sizeDelta.x / 2);
				GameObject asteroid = _asteroids.AsteroidList[Random.Range(0, 5)];
				asteroid.transform.position = new Vector3(positionXAsteroid, _planeSize.sizeDelta.y / 2);
				asteroid.name = "Asteroid";
				Instantiate(asteroid, _parent);
			}
		}
	}

	public void NewSizeAsterods(float newSize)
	{
		for (int i = 0; i < 6; i++)
		{
			_asteroids.AsteroidList[i].GetComponent<RectTransform>().sizeDelta = new Vector3(newSize, newSize);
			_asteroids.AsteroidList[i].GetComponent<BoxCollider>().size = new Vector3(newSize, newSize);
		}
	}

}
