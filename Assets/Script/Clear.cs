using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] GameObject a;
    [SerializeField] GameObject b;
    [SerializeField] GameObject c;

    [SerializeField] GameObject d;
    void Start()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            a.SetActive(false);
            b.SetActive(false);
            c.SetActive(false);

            d.SetActive(true);
        }
    }

    public void ReTry()
    {
        SceneManager.LoadScene("KitchinScene");
    }
}
