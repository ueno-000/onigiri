using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 落下ダメージの判定
/// </summary>
public class FallDamageScript : MonoBehaviour
{
    /// <summary>落下ダメージ</summary>
    [SerializeField] private float _damage = 5;

    /// <summary>落下する対象のtransform</summary>
    [SerializeField] private Transform _target;

    /// <summary>落下位置のｙ軸</summary>
    [SerializeField] private float _fallPosition;

    /// <summary>ダメージを与える基準の落下距離</summary>
    [SerializeField] private float _fallDamageDistance;

    /// <summary>落下距離</summary>
    [SerializeField] private float _fallDistance;

    /// <summary>落下判定</summary>
    [SerializeField] private bool isFall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
