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

    private Vector3 dir;

    /// <summary>�ڒn����</summary>
    private bool _isGrounded;

    /// <summary>�u���[�L�̎g�p����</summary>
/*    [HideInInspector] */public bool isBrake = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //��ɖ��C�͂O
        _rb.drag = 0;
        //�u���[�L�͒ʏ�false
        isBrake = false;

        if (Input.GetButton("Fire1"))
        {
            _rb.drag = _brakePower;
            isBrake = true;
        }

        MoveControll();
   
    }

    private void MoveControll()
    {
        //�ړ�����
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        dir = new Vector3(dx, 0, dz);

        dir = Camera.main.transform.TransformDirection(dir);

        //��ɖ��C�͂O
        _rb.drag = 0;
        //�u���[�L�͒ʏ�false
        isBrake = false;

        if (_isGrounded == true)//���n���Ă���Ƃ�
        {
            if (Input.GetButtonDown("Jump"))
            {
                _isGrounded = false;//  isGround��false�ɂ���
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }

        //�E�N���b�N�Ńu���[�L
        if (Input.GetButton("Fire1"))
        {
            isBrake = true;
            _rb.drag = _brakePower;
        }
    }

    //�ڒn����
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") 
        {
            _isGrounded = true; 
        }
    }


    void FixedUpdate()
    {
        // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs��
        _rb.AddForce(dir * _movePower);
    }

}
