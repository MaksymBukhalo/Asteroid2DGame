using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBonus : MonoBehaviour
{

	public ParticleSystem EffectsParticale;

	[SerializeField] private AudioClip _addBonus;
	[SerializeField] private AudioSource _efectsMusicPlay;
	[SerializeField] private AudioClip _shipDestroy;

	private Collider _ship;
	private TextInformation _bonusScoreAndLife;
	private float _bonusExperetionTime = 30f;
	private bool _timer = false;

	private void Start()
	{
		_efectsMusicPlay.clip = _addBonus;
		_ship = GameObject.Find("Ship(Clone)").GetComponent<Collider>();
		_bonusScoreAndLife = GameObject.Find("TextResult").GetComponent<TextInformation>();
	}

	private void Update()
	{
		StartTimer();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Shell(Clone)")
		{
			Destroy(other.gameObject);
		}
		if (other.name == "ShieldBonus(Clone)")
		{
			EffectsParticale.Play();
			_efectsMusicPlay.Play();
			Destroy(other.gameObject);
			BonusShield();
		}
		if (other.name == "KillBonus(Clone)" && GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().ShieldAsteroidsOff)
		{
			EffectsParticale.Play();
			GameObject.Find("Panel").GetComponent<AudioSource>().clip = _shipDestroy;
			GameObject.Find("Panel").GetComponent<AudioSource>().Play();
			Destroy(other.gameObject);
			BonusKill();
		}
		if (other.name == "SpeedBonus(Clone)")
		{
			EffectsParticale.Play();
			_efectsMusicPlay.Play();
			Destroy(other.gameObject);
			BonusSpeed();
		}
	}

	private void BonusShield()
	{
		_bonusScoreAndLife.NumScore += 1000;
		GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().ShieldAsteroidsOff = false;
		_timer = true;
	}

	private void BonusSpeed()
	{
		_bonusScoreAndLife.NumScore += 1000;
		GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().SpeedMove = 400f;
		_timer = true;
	}

	private void BonusKill()
	{
		Destroy(GameObject.Find("Ship(Clone)"));
		_bonusScoreAndLife.LifeShip -= 1;
		_bonusScoreAndLife.NumScore += 10000;
	}

	private void StartTimer()
	{
		if (_timer && _bonusExperetionTime > 0)
		{
			_bonusExperetionTime -= Time.deltaTime;
		}
		else if (_timer)
		{
			GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().ShieldAsteroidsOff = true;
			GameObject.Find("Ship(Clone)").GetComponent<ShipConrolMove>().SpeedMove = 200f;
			_timer = false;
		}
	}
}
