using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        DoorCheckOpen();
    }

    void DoorCheckOpen()
    {
        if (isOpen == false)
        {
            if (Checker.instance.DoorOpen == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("���� ���Ƚ��ϴ�");
                isOpen = true;
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("���� ����ֽ��ϴ�.");
        }
    }
}
