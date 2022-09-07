using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// HP�̊Ǘ�/Slider�̕\��/HP�ɉ�����mesh�ύX
/// </summary>
public class PlayerHPScript : MonoBehaviour
{
    /// <summary>�̗͒l</summary>
    [Tooltip("�̗͒l"),SerializeField] private float _hitPoint;
    /// <summary>Mesh</summary>
    [Tooltip("Mesh"), SerializeField] private Mesh[] meshes;

    MeshFilter _mesh;

    // Start is called before the first frame update
    void Start()
    {
         _mesh = gameObject.transform.GetChild(0).gameObject.GetComponent<MeshFilter>();
        _mesh.mesh = meshes[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
