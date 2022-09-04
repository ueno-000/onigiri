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
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // カメラのローカル座標系を基準に dir を変換する
        _dir = Camera.main.transform.TransformDirection(_dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        _dir.y = 0;
        // キャラクターを「現在の（XZ 平面上の）進行方向」に向ける
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }

        if (isGround == true)//着地しているとき
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGroundをfalseにする
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
        // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }

}
