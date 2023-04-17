using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool DoorOpen = false;
    public bool PhotoOn = false; //PhotoOn true �� Photo�� PhotoPrame ������ ��

    public static Checker instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
    }

    void CheckItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); //�ݰ� �� ���̾� ����
        foreach (Collider collider in colliders) //���̾� ���� ����
        {
            if (collider.gameObject.tag == "Checker") //���� ���̾��� �±װ� Cheker���
            {
                
                DoorOpen = true;
                PhotoOn = true;
                Debug.Log("������ üũ, True");
                if(collider.transform.GetComponent<PhotoCheck>())
                {
                    collider.transform.GetComponent<PhotoCheck>().PhotoCheckOpen(gameObject);
                }
                //Destroy(gameObject); //�������� �����ϰ� DoorOpen�� true�� �Ѵ�.
            }
        }
    }
}
