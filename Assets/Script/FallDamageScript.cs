using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����_���[�W�̔���
/// </summary>
public class FallDamageScript : MonoBehaviour
{
    //�@���C���΂��ꏊ
    [SerializeField]
    private Transform _target;
    //�@���C���΂�����
    [SerializeField]
    private float rayRange = 0.85f;

    /// <summary>�����_���[�W</summary>
    [SerializeField] private float _damage = 5;

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
        _fallDamageDistance = 0f;
        _fallPosition = transform.position.y;
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(_target.position, _target.position + Vector3.down * rayRange, Color.blue);


        //�@�����Ă�����
        if (isFall)
        {

            //�@�����n�_�ƌ��ݒn�̋������v�Z�i�W�����v���ŏ�ɔ��ŗ��������ꍇ���l������ׂ̏����j
            _fallPosition = Mathf.Max(_fallPosition, transform.position.y);
            //Debug.Log(_fallPosition);

            //�@�n�ʂɃ��C���͂��Ă�����
            if (Physics.Linecast(_target.position, _target.position + Vector3.down * rayRange, LayerMask.GetMask("Field", "Player")))
            {
                //�@�����������v�Z
                _fallDistance = _fallPosition - transform.position.y;
                //�@�����ɂ��_���[�W���������鋗���𒴂���ꍇ�_���[�W��^����
                if (_fallDistance >= _fallDamageDistance)
                {
                    //myHp.TakeDamage((int)(fallenDistance - _fallDamageDistance));
                    Debug.Log("aaa");
                }
                isFall = false;
            }
        }
        else
        {
            //�@�n�ʂɃ��C���͂��Ă��Ȃ���Η����n�_��ݒ�
            if (!Physics.Linecast(_target.position, _target.position + Vector3.down * rayRange, LayerMask.GetMask("Field", "Player")))
            {
                //�@�ŏ��̗����n�_��ݒ�
                _fallPosition = transform.position.y;
                _fallDistance = 0;
                isFall = true;
            }
        }

    }
}
