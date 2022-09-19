using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// グラップリングアクション
/// </summary>
public class GrapplingScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _target;
    private Rigidbody _rb;
    private SpringJoint _sj;
    private LineRenderer _lineRenderer;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _sj = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        _sj.connectedBody = _target;

        if (_target != null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                _target = null;
            }
        }
    }
}
