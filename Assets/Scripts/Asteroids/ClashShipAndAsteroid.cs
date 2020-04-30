using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClashShipAndAsteroid : MonoBehaviour
{
	public GameObject asteroid;

	[SerializeField] private ListAsteroid _asteroids;
	[SerializeField] private AudioClip _asteroidDestroy;
	[SerializeField] private AudioClip _shipDestroy;

	private AudioSource _audioAsteroids;
	private Collider _ship;
	private Transform _space;
	private RectTransform _asteroidSize;
	private int _amoutAsteroids;
	private TextInformation _asteroidScoreAndLife;
	private bool _instatiateShip;

	private void Start()
	{
		_space = GameObject.Find("Panel").GetComponent<Transform>();
		_audioAsteroids = GameObject.Find("Panel").GetComponent<AudioSource>();
		_asteroidScoreAndLife = GameObject.Find("TextResult").GetComponent<TextInformation>();
		_amoutAsteroids = Random.Range(2, 4);
		_asteroidSize = transform.GetComponent<RectTransform>();
		InstantiateShip();
	}

	private void OnTriggerEnter(Collider other)
	{
		InstantiateShip();
		if (_instatiateShip)
		{

			if (other == _ship && GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().ShieldAsteroidsOff)
			{
				_audioAsteroids.clip = _shipDestroy;
				_audioAsteroids.Play();
				Destroy(GameObject.Find("Ship(Clone)"));
				_asteroidScoreAndLife.LifeShip -= 1;
			}
		}
		if (other.name == "Shell(Clone)")
		{
			_audioAsteroids.clip = _asteroidDestroy;
			_audioAsteroids.Play();
			Destroy(other.gameObject);
			CreateAsteroidsAfterDestroy();
			Destroy(gameObject);
		}

	}

	private void InstantiateShip()
	{
		if (!GameObject.Find("Ship(Clone)"))
		{
			_instatiateShip = false;
		}
		else
		{
			_instatiateShip = true;
			_ship = GameObject.Find("Ship(Clone)").GetComponent<Collider>();
		}
	}

	private void CreateAsteroidsAfterDestroy()
	{
		if (_asteroidSize.sizeDelta.x == 75f)
		{
			NewSizeAsterods(50f);
			CreateNewAsteroidsAfterDestroy();
			_asteroidScoreAndLife.NumScore += 400;
		}

		else if (_asteroidSize.sizeDelta.x == 50f)
		{
			NewSizeAsterods(35f);
			CreateNewAsteroidsAfterDestroy();
			_asteroidScoreAndLife.NumScore += 200;
		}

		else if (_asteroidSize.sizeDelta.x == 35f)
		{
			NewSizeAsterods(15f);
			CreateNewAsteroidsAfterDestroy();
			_asteroidScoreAndLife.NumScore += 100;
		}
		else
		{
			_asteroidScoreAndLife.NumScore += 50;
		}

	}

	private void NewSizeAsterods(float newSize)
	{
		for (int i = 0; i < 6; i++)
		{
			_asteroids.AsteroidList[i].GetComponent<RectTransform>().sizeDelta = new Vector3(newSize, newSize);
			_asteroids.AsteroidList[i].GetComponent<BoxCollider>().size = new Vector3(newSize, newSize);
		}
	}

	private void CreateNewAsteroidsAfterDestroy()
	{
		for (int i = 0; i < _amoutAsteroids; i++)
		{
			GameObject newAsteroid = _asteroids.AsteroidList[i];
			newAsteroid.name = "Asteroid";
			newAsteroid = Instantiate(newAsteroid, _space);
			newAsteroid.transform.position = transform.position;
		}
	}

}
