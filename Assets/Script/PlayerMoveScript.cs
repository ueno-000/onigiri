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


    [Header("アタッチするもの")]
    /// <summary>アニメーションコンポーネント</summary>
    [SerializeField] private Animation _anim;
    private Rigidbody _rb = default;

    private Vector3 dir;

    /// <summary>接地判定</summary>
    [SerializeField]
    private bool _isGrounded;

    /// <summary>ブレーキの使用判定</summary>
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
        //移動制御
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");

        var horizontalRoration = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);


        dir = horizontalRoration * new Vector3(dx, 0, dz)/*.normalized*/;

     //  dir = Camera.main.transform.TransformDirection(dir);


        //常に摩擦は０
        _rb.drag = 1;
        //ブレーキは通常false
        isBrake = false;

        if (_isGrounded == true)//着地しているとき
        {
            // 垂直方向の速度を計算する
            float y = _rb.velocity.y;

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                y = _jumpPower;
                _rb.velocity = Vector3.up * y;
            }
        }

        //右クリックでブレーキ
        if (Input.GetButton("Fire1"))
        {
            isBrake = true;
            _rb.drag += _brakePower;
        }
    }

    //接地判定
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
        // 「力を加える」処理は力学的処理なので FixedUpdate で行う
        _rb.AddForce(dir * _movePower);

        
    }

}
