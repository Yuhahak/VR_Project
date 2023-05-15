using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool DoorOpen = false;
    public bool PhotoOn = false; //PhotoOn true �� Photo�� PhotoPrame ������

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

            if (collider.gameObject.tag == "Checker") //���� ���̾��� �±װ� Checker���
            {

                
                Debug.Log("������ üũ, True");

                if (gameObject.tag == "Photo")
                {
                    Debug.Log("������ üũ, Photo");
                    if (collider.transform.GetComponent<PhotoCheck>())
                    {
                        PhotoOn = true; //�ִϸ��̼� ������ ���� key
                        collider.transform.GetComponent<PhotoCheck>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //�������� �����ϰ� DoorOpen�� true�� �Ѵ�.
                }

                if (gameObject.tag == "Photo1")
                {
                    Debug.Log("������ üũ, Photo1");
                    if (collider.transform.GetComponent<PhotoCheck1>()) // �� GetComponent�� ���������ν� cheker ������ ������
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck1>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //�������� �����ϰ� DoorOpen�� true�� �Ѵ�.
                }

                if (gameObject.tag == "Photo2")
                {
                    Debug.Log("������ üũ, Photo2");
                    if (collider.transform.GetComponent<PhotoCheck2>()) // �� GetComponent�� ���������ν� cheker ������ ������
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck2>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //�������� �����ϰ� DoorOpen�� true�� �Ѵ�.
                }

                if (gameObject.tag == "DoorKey")
                {
                    Debug.Log("������ üũ, DoorKey");

                    if (collider.transform.GetComponent<DoorCheck>()) {
                        Debug.Log("���� �����ϴ�.");
                        DoorOpen = true; //���� �̻�� ����

                        collider.transform.GetComponent<DoorCheck>().DoorOpen();
                    }

                    /*if (collider.transform.GetComponent<PhotoCheck2>()) // �� GetComponent�� ���������ν� cheker ������ ������
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck2>().PhotoCheckOpen(gameObject);

                    }*/

                    //Destroy(gameObject); //�������� �����ϰ� DoorOpen�� true�� �Ѵ�.
                }
            }

        }
    }
}
