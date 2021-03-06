﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConrolMove : MonoBehaviour
{

	public bool ShieldAsteroidsOff = true;
	public float SpeedMove = 200f;

	[SerializeField] private GameObject _ship;
	[SerializeField] private AudioSource _audioShip;
	[SerializeField] private AudioClip _moveShip;

	private Vector3 _moveVector;
	private float _z;
	private RectTransform _planeSize;
	private CharacterController _shipConroller;

	private void Start()
	{
		_audioShip.clip = _moveShip;
		_shipConroller = GetComponent<CharacterController>();
		_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
		_audioShip.Play();
	}

	private void Update()
	{
		ShipMove();
		ShipRotation();
		TeleportsShipOnLimit();
	}

	private void ShipMove()
	{
		_moveVector = Vector3.zero;
		_moveVector.x = Input.GetAxis("Horizontal") * SpeedMove;
		_moveVector.y = Input.GetAxis("Vertical") * SpeedMove;
		_shipConroller.Move(_moveVector * Time.deltaTime);
	}

	private void ShipRotation()
	{
		if (Input.GetKey(KeyCode.Q))
		{
			_audioShip.Play();
			_z += 1f * SpeedMove * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, _z);
		}
		if (Input.GetKey(KeyCode.E))
		{
			_audioShip.Play();
			_z -= 1f * SpeedMove * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, _z);
		}
	}

	private void TeleportsShipOnLimit()
	{
		float sizeScaleX = _planeSize.sizeDelta.x / 2 * _planeSize.transform.localScale.x;
		float sizeScaleY = _planeSize.sizeDelta.y / 2 * _planeSize.transform.localScale.y;
		if (_ship.transform.position.x > sizeScaleX)
		{
			_ship.transform.position = new Vector3(-sizeScaleX, _ship.transform.position.y);
		}

		if (_ship.transform.position.x < -sizeScaleX)
		{
			_ship.transform.position = new Vector3(sizeScaleX, _ship.transform.position.y);
		}

		if (_ship.transform.position.y > sizeScaleY)
		{
			_ship.transform.position = new Vector3(_ship.transform.position.x, -sizeScaleY);
		}

		if (_ship.transform.position.y < -sizeScaleY)
		{
			_ship.transform.position = new Vector3(_ship.transform.position.x, sizeScaleY);
		}
	}
}
