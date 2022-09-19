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

    private Vector3 _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _sj = GetComponent<SpringJoint>();
        _lineRenderer = GetComponent<LineRenderer>();
        _player = this.gameObject.transform.position;
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

            _lineRenderer.SetPosition(0, _player);
            _lineRenderer.SetPosition(1, _target);
        }
    }
}
