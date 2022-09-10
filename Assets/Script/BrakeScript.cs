using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrakeScript : MonoBehaviour
{
    /// <summary>ブレーキ使用可能時間</summary>
    [SerializeField] private float _brakeTime = 5f;

    /// <summary>PlayerMoveScript</summary>
    [SerializeField] private PlayerMoveScript _moveScript;

    /// <summary>ブレーキの判定</summary>
    private bool isBrake = false;

    /// <summary>Time</summary>
    [SerializeField] private float _time;

    /// <summary>Text</summary>
    [SerializeField] private Text _brakeText;

    void Start()
    {
        _moveScript = _moveScript.gameObject.GetComponent<PlayerMoveScript>();
        _time = _brakeTime;
    }

    // Update is called once per frame
    void Update()
    {
        isBrake = _moveScript.isBrake;

        _time = Mathf.Clamp(_time,0,_brakeTime);

        if (isBrake)
        {
            _time -= Time.deltaTime;

            if (_time <=  0)
            {
                Debug.Log("PLAYER:DED");
            }
        }

        _brakeText.text = _time.ToString("f2");
    }
}
