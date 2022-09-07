using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    [Header("各種移動パラメーター")]
    /// <summary>移動時のパワー</summary>
    [Tooltip("移動時のパワー"),SerializeField] private  float _movePower = 3;
    /// <summary>ジャンプパワー</summary>
    [Tooltip("ジャンプパワー"),SerializeField] private float _jumpPower = 3;
    /// <summary>ブレーキパワー</summary>
    [Tooltip("ブレーキパワー"),SerializeField] private float _brakePower = 3;


   private Rigidbody _rb = default;



   [SerializeField]private bool isGround;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //移動制御
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        var movement = new Vector3(dx, 0, dz);
        _rb.AddForce(movement * _movePower);

        //常に摩擦は０
        _rb.drag = 0;

        if (isGround == true)//着地しているとき
        {
            if (Input.GetButtonDown("Jump"))
            {
                isGround = false;//  isGroundをfalseにする
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }

        //右クリックでブレーキ
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
    //    // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
    //    _rb.AddForce(_dir.normalized * _movePower, ForceMode.Acceleration);
    //}

}
