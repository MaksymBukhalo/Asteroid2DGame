using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBonus : MonoBehaviour
{

	public ParticleSystem EffectsParticale;

	[SerializeField] private AudioClip _addBonus;
	[SerializeField] private AudioSource _efectsMusicPlay;
	[SerializeField] private AudioClip _shipDestroy;

	private GameObject _ship;
	private TextInformation _bonusScoreAndLife;
	private float _bonusExperetionTime = 30f;
	private bool _timer = false;

	private void Start()
	{
		_efectsMusicPlay.clip = _addBonus;
		_bonusScoreAndLife = GameObject.Find("TextResult").GetComponent<TextInformation>();
	}

	private void Update()
	{
		StartTimer();
	}

	private void OnTriggerEnter(Collider other)
	{
		_ship = GameObject.Find("Ship(Clone)");
		if (other.name == "Shell(Clone)")
		{
			Destroy(other.gameObject);
		}

		if (other.name == "ShieldBonus(Clone)")
		{
			Destroy(other.gameObject);
			BonusShield();
		}

		if (other.name == "KillBonus(Clone)" && _ship.GetComponent<ShipConrolMove>().ShieldAsteroidsOff)
		{
			GameObject.Find("GamePanel(Clone)").GetComponent<AudioSource>().clip = _shipDestroy;
			GameObject.Find("GamePanel(Clone)").GetComponent<AudioSource>().Play();
			Destroy(other.gameObject);
			BonusKill();
		}

		if (other.name == "SpeedBonus(Clone)")
		{
			Destroy(other.gameObject);
			BonusSpeed();
		}
	}

	private void BonusShield()
	{
		EffectsParticale.startColor = Color.green;
		EffectsParticale.Play();
		_efectsMusicPlay.Play();
		_bonusScoreAndLife.NumScore += 1000;
		_ship.GetComponent<ShipConrolMove>().ShieldAsteroidsOff = false;
		_ship.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.5f);
		_timer = true;
	}

	private void BonusSpeed()
	{
		EffectsParticale.startColor = Color.yellow;
		EffectsParticale.Play();
		_efectsMusicPlay.Play();
		_bonusScoreAndLife.NumScore += 1000;
		_ship.GetComponent<ShipConrolMove>().SpeedMove = 400f;
		_timer = true;
	}

	private void BonusKill()
	{
		EffectsParticale.startColor = Color.red;
		EffectsParticale.Play();
		Destroy(_ship);
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
			_ship.GetComponent<ShipConrolMove>().ShieldAsteroidsOff = true;
			_ship.GetComponent<ShipConrolMove>().SpeedMove = 200f;
			_ship.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
			_timer = false;
		}
	}
}
