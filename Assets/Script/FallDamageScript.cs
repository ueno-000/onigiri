using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����_���[�W�̔���
/// </summary>
public class FallDamageScript : MonoBehaviour
{
    /// <summary>�����_���[�W</summary>
    [SerializeField] private float _damage = 5;

    /// <summary>��������Ώۂ�transform</summary>
    [SerializeField] private Transform _target;

    /// <summary>�����ʒu�̂���</summary>
    [SerializeField] private float _fallPosition;

    /// <summary>�_���[�W��^�����̗�������</summary>
    [SerializeField] private float _fallDamageDistance;

    /// <summary>��������</summary>
    [SerializeField] private float _fallDistance;

    /// <summary>��������</summary>
    [SerializeField] private bool isFall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
