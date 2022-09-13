using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Editor;

public class CameraScript : MonoBehaviour
{
    Cinemachine.CinemachineFreeLook _cinemachineFreeLook; 

    // Start is called before the first frame update
    void Start()
    {
        _cinemachineFreeLook = gameObject.GetComponent<Cinemachine.CinemachineFreeLook>();

      
        
    }

}
