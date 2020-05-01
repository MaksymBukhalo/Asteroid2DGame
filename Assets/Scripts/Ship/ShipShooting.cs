using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
	[SerializeField] private GameObject _shell;
	[SerializeField] private GameObject _startShell;
	[SerializeField] private GameObject _shellVector;
	[SerializeField] private AudioClip _clipShoot;
	[SerializeField] private AudioSource _audioShoot;

	private float _startSpeed = 150f;
	private Transform _plane;
	private float _pauseBetweenShoots = 0.1f;
	private float _shootTime;

	private void Start()
	{
		_audioShoot.clip = _clipShoot;
		_plane = GameObject.Find("GamePanel(Clone)").GetComponent<Transform>();
		_shootTime = Time.time;
	}

	private void Update()
	{
		ShotRocets();
	}

	private void ShotRocets()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			if (Time.time - _shootTime > _pauseBetweenShoots)
			{
				_audioShoot.Play();
				Vector3 _vectorMove = _shellVector.transform.position - _startShell.transform.position;
				GameObject shellClone = Instantiate(_shell, transform.position, transform.rotation, _plane);
				shellClone.GetComponent<Rigidbody>().AddForce(_vectorMove * _startSpeed);
				_shootTime = Time.time;
			}
		}
	}

}
