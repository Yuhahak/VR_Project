using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public GameObject Password;

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
        if (collision.gameObject.tag == "Player") //�÷��̾�� �������
        {
            Password.gameObject.SetActive(true); //�н����� UI�� Ų��
            MouseMove.instance.unLock(); // ���콺 Ŀ���� ���̰�
        }
    }

    private void OnCollisionExit(Collision collision) // �÷��̾�� ����������
    {
        Password.gameObject.SetActive(false); // �н����� UI�� ����
        MouseMove.instance.Lock(); //���콺Ŀ�� �Ⱥ��̰� ��

    }
}
