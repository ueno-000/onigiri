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
        _sj.spring = 0;
        _sj.autoConfigureConnectedAnchor = true;
        _rb.mass = 10;

        _lineRenderer.SetPosition(0, this.gameObject.transform.position);
        _lineRenderer.SetPosition(1,this.gameObject.transform.position);

        if (_target == null)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20.0f))
                {
                    
                    _target = hit.collider.gameObject.GetComponent<Rigidbody>();
                }
            }
        }
        else 
        {
            _sj.autoConfigureConnectedAnchor = false;
            _sj.spring = 5;
            _sj.connectedAnchor = new Vector3(0, 1, 0);
            _rb.mass = 1;
            _lineRenderer.SetPosition(0, this.gameObject.transform.position);
            _lineRenderer.SetPosition(1, _target.gameObject.transform.position);

            if (Input.GetButtonDown("Fire2"))
            {
                _target = null;
                
            }
        }
    }
}
