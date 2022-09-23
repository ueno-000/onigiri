using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Editor;

public class goalUI : MonoBehaviour
{
    private Transform _player;
    private void Start()
    {
        _player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        transform.LookAt(_player);

    }
}
