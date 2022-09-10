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

    private Vector3 dir;

    /// <summary>接地判定</summary>
    private bool _isGrounded;

    /// <summary>ブレーキの使用判定</summary>
/*    [HideInInspector] */public bool isBrake = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //常に摩擦は０
        _rb.drag = 0;
        //ブレーキは通常false
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
        //移動制御
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        dir = new Vector3(dx, 0, dz);

        dir = Camera.main.transform.TransformDirection(dir);

        //常に摩擦は０
        _rb.drag = 0;
        //ブレーキは通常false
        isBrake = false;

        if (_isGrounded == true)//着地しているとき
        {
            if (Input.GetButtonDown("Jump"))
            {
                _isGrounded = false;//  isGroundをfalseにする
                _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            }
        }

        //右クリックでブレーキ
        if (Input.GetButton("Fire1"))
        {
            isBrake = true;
            _rb.drag = _brakePower;
        }
    }

    //接地判定
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") 
        {
            _isGrounded = true; 
        }
    }


    void FixedUpdate()
    {
        // 「力を加える」処理は力学的処理なので FixedUpdate で行う
        _rb.AddForce(dir * _movePower);
    }

}
