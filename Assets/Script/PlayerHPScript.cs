using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// HP�̊Ǘ�/Slider�̕\��/HP�ɉ�����mesh�ύX
/// </summary>
public class PlayerHPScript : MonoBehaviour,IDamage
{
    /// <summary>�̗͒l</summary>
    [Tooltip("�̗͒l"),SerializeField] private float _hitPoint = 100;
    /// <summary>�ő�̗͒l</summary>
    [Tooltip("�ő�̗͒l"), SerializeField] private float _maxHitPoint;
    /// <summary>Mesh</summary>
    [Tooltip("Mesh"), SerializeField] private Mesh[] meshes;

    private MeshFilter _mesh;
    
    /// <summary>Slider</summary>
    [SerializeField] private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
         _mesh = gameObject.transform.GetChild(0).gameObject.GetComponent<MeshFilter>();
        _mesh.mesh = meshes[0];

        _slider = _slider.gameObject.GetComponent<Slider>();
        _slider.maxValue = _maxHitPoint;
    }

    // Update is called once per frame
    void Update()
    {
        MeshSetting();

        UpdateSlider();

        _hitPoint = Mathf.Clamp(_hitPoint, 0, _maxHitPoint);

        if (_hitPoint <= 0)
        {
            Debug.Log("PLAYER:DED");
        }
    }

    private void UpdateSlider()
    {
        _slider.value = _hitPoint;
    }

    /// <summary>
    /// HP�ɂ����Mesh��ς���
    /// </summary>
    private void MeshSetting()
    {
        if (_hitPoint >= _maxHitPoint / 2)//�̗͒l�������ȏ�
        {
            _mesh.mesh = meshes[0];
        }
       else if (_hitPoint <= _maxHitPoint / 2 && _hitPoint >= _maxHitPoint / 5)//�̗͒l�������ȉ��T���̂P�ȏ�
        {
            _mesh.mesh = meshes[1];
        }
        else if (_hitPoint <= _maxHitPoint / 5)//�̗͒l��5���̂P�ȉ�
        {
            _mesh.mesh = meshes[2];
        }
    }

    public void Damage(float value)
    { 
        _hitPoint -= value;
    }
}
