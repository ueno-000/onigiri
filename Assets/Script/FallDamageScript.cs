using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 落下ダメージの判定
/// </summary>
public class FallDamageScript : MonoBehaviour
{
    //　レイを飛ばす場所(PLayer)
    private Transform _playerRayPos;

    //　レイを飛ばす距離
    [SerializeField]
    private float _rayRange = 0.85f;

    /// <summary>落下ダメージ</summary>
    [SerializeField] private float _damage = 5;

    /// <summary>落下位置のｙ軸</summary>
    [SerializeField] private float _fallPosition;

    /// <summary>ダメージを与える基準の落下距離</summary>
    [SerializeField] private float _fallDamageDistance;

    /// <summary>落下距離</summary>
    [SerializeField] private float _fallDistance;

    /// <summary>落下判定</summary>
    [SerializeField] private bool isFall;


    void Start()
    {
        _playerRayPos = this.gameObject.transform;
        _fallDamageDistance = 5f;
        _fallPosition = transform.position.y;
        isFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(_playerRayPos.position, _playerRayPos.position + Vector3.down * _rayRange, Color.blue);


        //　落ちている状態
        if (isFall)
        {

            //　落下地点と現在地の距離を計算（ジャンプ等で上に飛んで落下した場合を考慮する為の処理）
            _fallPosition = Mathf.Max(_fallPosition, transform.position.y);
            //Debug.Log(_fallPosition);

            //　地面にレイが届いていたら
            if (Physics.Linecast(_playerRayPos.position, _playerRayPos.position + Vector3.down * _rayRange, LayerMask.GetMask("Field", "Player")))
            {
                //　落下距離を計算
                _fallDistance = _fallPosition - transform.position.y;
                //　落下によるダメージが発生する距離を超える場合ダメージを与える
                if (_fallDistance >= _fallDamageDistance)
                {
                    //myHp.TakeDamage((int)(fallenDistance - _fallDamageDistance));
                    Debug.Log("aaa");
                     _playerRayPos.gameObject.GetComponent<IDamage>().Damage(_damage);


                }
                isFall = false;
            }
        }
        else
        {
            //　地面にレイが届いていなければ落下地点を設定
            if (!Physics.Linecast(_playerRayPos.position, _playerRayPos.position + Vector3.down * _rayRange, LayerMask.GetMask("Field", "Player")))
            {
                //　最初の落下地点を設定
                _fallPosition = transform.position.y;
                _fallDistance = 0;
                isFall = true;
            }
        }

    }
}
