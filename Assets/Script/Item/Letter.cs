using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Letter : MonoBehaviour
{
    public Image letter;
    private bool isletter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isletter = true;
            if (isletter = true && Input.GetKeyDown(KeyCode.F)){
                letter.enabled = true;
                Debug.Log("!");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isletter = false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            letter.enabled = false;
        }
    }
}
