using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    
    [SerializeField] float _movePower = 3;
    [SerializeField] float _jumpPower = 3;

    Rigidbody _rb = default;


    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>
    Vector3 _dir;

    bool isGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // �J�����̃��[�J�����W�n����� dir ��ϊ�����
        _dir = Camera.main.transform.TransformDirection(_dir);
        // �J�����͎΂߉��Ɍ����Ă���̂ŁAY ���̒l�� 0 �ɂ��āuXZ ���ʏ�̃x�N�g���v�ɂ���
        _dir.y = 0;
        // �L�����N�^�[���u���݂́iXZ ���ʏ�́j�i�s�����v�Ɍ�����
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }

        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGround��false�ɂ���
                _rb.AddForce(transform.up * _jumpPower, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") 
        {
            isGround = true; 
        }
    }


    void FixedUpdate()
    {
        // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs������
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }

}
