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

        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        var movement = new Vector3(dx, 0, dz);
        _rb.AddForce(movement * _movePower);
        

        if (isGround == true)//���n���Ă���Ƃ�
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGround��false�ɂ���
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
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


    //void FixedUpdate()
    //{
    //    // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs������
    //    _rb.AddForce(_dir.normalized * _movePower, ForceMode.Acceleration);
    //}

}
