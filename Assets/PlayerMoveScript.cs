using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [Header("�e��ړ��p�����[�^�[")]
    /// <summary>�ړ����̃p���[</summary>
    [Tooltip("�ړ����̃p���["),SerializeField] private  float _movePower = 3;
    /// <summary>�W�����v�p���[</summary>
    [Tooltip("�W�����v�p���["),SerializeField] private float _jumpPower = 3;
    /// <summary>�u���[�L�p���[</summary>
    [Tooltip("�u���[�L�p���["),SerializeField] private float _brakePower = 3;


   private Rigidbody _rb = default;



   [SerializeField]private bool isGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //�ړ�����
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        var movement = new Vector3(dx, 0, dz);
        _rb.AddForce(movement * _movePower);

        //��ɖ��C�͂O
        _rb.drag = 0;

        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGround��false�ɂ���
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }

        //�E�N���b�N�Ńu���[�L
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("a");
            _rb.drag = _brakePower;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("b");
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") 
        {
            isGround = true; 
        }
    }


    //void FixedUpdate()
    //{
    //    // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs������
    //    _rb.AddForce(_dir.normalized * _movePower, ForceMode.Acceleration);
    //}

}
