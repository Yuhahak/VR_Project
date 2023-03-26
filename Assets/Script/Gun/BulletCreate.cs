using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreate : MonoBehaviour
{
    public Rigidbody prefabBullet;
    public Transform BulletPos;

    private bool isGun;


    // Start is called before the first frame update

    private void Awake()
    {
    }


    // Update is called once per frame
    void Update()
    {
        CheckGun();
    }




    void CheckGun()
    {

        if (Input.GetKeyDown(KeyCode.F) && ActionController.instance.heldItem && isGun)
        {
            Debug.Log("1");
            Rigidbody bulletRb =
                Instantiate(prefabBullet, BulletPos.position, BulletPos.localRotation);

            bulletRb.velocity = 20.0f * transform.forward;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isGun = true;
        }
        else
        {
            isGun = false;
        }
    }

   
}