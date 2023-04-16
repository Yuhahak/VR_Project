using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButton : MonoBehaviour
{
    [SerializeField] private Text Ans; //�Է¹޴� �ؽ�Ʈ

    private string Answer = "1234"; //��



    private void Update()
    {
        if (Ans.text.Length >= 5) // �Է¹��� ���ڰ� 5���� ũ��
        {
            Ans.text = "4���� �Դϴ�";
            Invoke("Clear", 1f); // 1���� clear�Լ� ����

        }
    }



    public void Number(int number)
    {
        Ans.text += number.ToString(); // �ؽ�Ʈ�� ���� ��ư�� ��Ʈ���� ����
    }


    public void Execute() //Ȯ�� �Լ�
    {
        if(Ans.text == Answer) //�Է¹��� �ؽ�Ʈ�� ���� ������
        {
            Ans.text = "������";
            Invoke("Clear", 1f);

        }
        else
        {
            Ans.text = "��";
            Invoke("Clear", 1f);

        }
    }



    void Clear() //Ŭ���� �Լ�
    {
        Ans.text = ""; //�Է¹��� �� �ʱ�ȭ
    }
}
