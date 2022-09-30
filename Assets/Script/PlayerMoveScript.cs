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


    [Header("�A�^�b�`�������")]
    /// <summary>�A�j���[�V�����R���|�[�l���g</summary>
    [SerializeField] private Animation _anim;
    private Rigidbody _rb = default;

    private Vector3 dir;

    /// <summary>�ڒn����</summary>
    [SerializeField]
    private bool _isGrounded;

    /// <summary>�u���[�L�̎g�p����</summary>
    [HideInInspector]public bool isBrake = false;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = _anim.gameObject.GetComponent<Animation>();
    }


    void Update()
    {

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

        var horizontalRoration = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);


        dir = horizontalRoration * new Vector3(dx, 0, dz)/*.normalized*/;

     //  dir = Camera.main.transform.TransformDirection(dir);


        //��ɖ��C�͂O
        _rb.drag = 1;
        //�u���[�L�͒ʏ�false
        isBrake = false;

        if (_isGrounded == true)//���n���Ă���Ƃ�
        {
            // ���������̑��x���v�Z����
            float y = _rb.velocity.y;

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                y = _jumpPower;
                _rb.velocity = Vector3.up * y;
            }
        }

        //�E�N���b�N�Ńu���[�L
        if (Input.GetButton("Fire1"))
        {
            isBrake = true;
            _rb.drag += _brakePower;
        }
    }

    //�ڒn����
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Move") 
        {
            _isGrounded = true; 
        }

        if (col.gameObject.tag == "Move")
        {
            transform.SetParent(col.transform);
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Move")
        {
            _isGrounded = false;
        }

        if (col.gameObject.tag == "Move")
        {
            transform.SetParent(null);
        }
    }


    void FixedUpdate()
    {
        // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs��
        _rb.AddForce(dir * _movePower);

        
    }

}
