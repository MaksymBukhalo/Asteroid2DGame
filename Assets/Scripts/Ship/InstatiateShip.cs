using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateShip : MonoBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private Transform _space;

    private TextInformation _life;

    private void Start()
    {
        _life = GameObject.Find("TextResult").GetComponent<TextInformation>();
    }

    private void Update()
    {
        InstantiateShip();
    }

    private void InstantiateShip()
    {
        if (_life.LifeShip > 0 && GameObject.Find("Ship(Clone)") == false && GameObject.Find("ZoneStart").GetComponent<TriggerZoneStart>().ZoneStart)
        {
            Instantiate(_ship, _space);
        }
    }


}
