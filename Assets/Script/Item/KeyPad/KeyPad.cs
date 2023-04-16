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
        if (collision.gameObject.tag == "Player") //플레이어와 닿았을때
        {
            Password.gameObject.SetActive(true); //패스워드 UI를 킨다
            MouseMove.instance.unLock(); // 마우스 커서를 보이게
        }
    }

    private void OnCollisionExit(Collision collision) // 플레이어와 떨어졌을때
    {
        Password.gameObject.SetActive(false); // 패스워드 UI를 끈다
        MouseMove.instance.Lock(); //마우스커서 안보이게 락

    }
}
