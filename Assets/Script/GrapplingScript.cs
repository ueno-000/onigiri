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
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _sj.connectedBody = _target;

        _lineRenderer.SetPosition(0, this.gameObject.transform.position);
        _lineRenderer.SetPosition(1,this.gameObject.transform.position);

        if (_target != null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                _target = null;
            }

            _lineRenderer.SetPosition(0, this.gameObject.transform.position);
            _lineRenderer.SetPosition(1, _target.gameObject.transform.position);
        }
    }
}
