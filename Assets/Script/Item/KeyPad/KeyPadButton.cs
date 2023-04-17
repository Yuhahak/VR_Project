using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadButton : MonoBehaviour
{
    [SerializeField] private Text Ans; //입력받는 텍스트

    private string Answer = "1234"; //답



    private void Update()
    {
        if (Ans.text.Length >= 5) // 입력받은 글자가 5보다 크면
        {
            Ans.text = "4글자 입니다";
            Invoke("Clear", 1f); // 1초후 clear함수 실행

        }
    }



    public void Number(int number)
    {
        Ans.text += number.ToString(); // 텍스트에 눌리 버튼의 스트링을 저장
    }


    public void Execute() //확인 함수
    {
        if(Ans.text == Answer) //입력받은 텍스트와 값이 같으면
        {
            Ans.text = "딩동댕";
            Invoke("Clear", 1f);

        }
        else
        {
            Ans.text = "땡";
            Invoke("Clear", 1f);

        }
    }



    void Clear() //클리어 함수
    {
        Ans.text = ""; //입력받은 답 초기화
    }
}
