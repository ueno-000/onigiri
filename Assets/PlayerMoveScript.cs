using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    
    [SerializeField] float _movePower = 3;
    [SerializeField] float _jumpPower = 3;

    Rigidbody _rb = default;


    /// <summary>入力された方向の XZ 平面でのベクトル</summary>
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
        

        if (isGround == true)//着地しているとき
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGroundをfalseにする
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
    //    // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
    //    _rb.AddForce(_dir.normalized * _movePower, ForceMode.Acceleration);
    //}

}
