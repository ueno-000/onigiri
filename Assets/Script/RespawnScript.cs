using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    [SerializeField] private Transform _startPos;

    [SerializeField] private Transform[] _pos;

    private int _spawnCount;

    [SerializeField] private Transform _player;
    // Start is called before the first frame update

    void Start()
    {
        _startPos.position = _player.position;
        //_player.transform.position = _startPos.position;

        //var point = GameObject.FindGameObjectsWithTag("Point");

        //for(int i = 0;i < point.Length;i++)
        //{
        //    _pos[i] = point[i].transform;
        //}

        //_startPos = _pos[0];

    }

    public void Respawn()
    {
        _player.position = _startPos.position;
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Point")
    //    {
    //        _spawnCount++;
    //    }
    //}
}
