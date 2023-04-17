using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool DoorOpen = false;
    public bool PhotoOn = false; //PhotoOn true 시 Photo와 PhotoPrame 합쳐진 것

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); //반경 내 레이어 추출
        foreach (Collider collider in colliders) //레이어 추출 훑음
        {
            if (collider.gameObject.tag == "Checker") //닿은 레이어의 태그가 Cheker라면
            {
                
                DoorOpen = true;
                PhotoOn = true;
                Debug.Log("아이템 체크, True");
                if(collider.transform.GetComponent<PhotoCheck>())
                {
                    collider.transform.GetComponent<PhotoCheck>().PhotoCheckOpen(gameObject);
                }
                //Destroy(gameObject); //아이템을 삭제하고 DoorOpen을 true로 한다.
            }
        }
    }
}
