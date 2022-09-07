using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// HPの管理/Sliderの表示/HPに応じたmesh変更
/// </summary>
public class PlayerHPScript : MonoBehaviour
{
    /// <summary>体力値</summary>
    [Tooltip("体力値"),SerializeField] private float _hitPoint;

    [SerializeField] private Mesh[] meshes;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
