using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("Bullet")) //총알과 닿았을때
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false; // 중력이 작용하도록
        }
    }
}
