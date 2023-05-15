using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool DoorOpen = false;
    public bool PhotoOn = false; //PhotoOn true 시 Photo와 PhotoPrame 합쳐짐

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

            if (collider.gameObject.tag == "Checker") //닿은 레이어의 태그가 Checker라면
            {

                
                Debug.Log("아이템 체크, True");

                if (gameObject.tag == "Photo")
                {
                    Debug.Log("아이템 체크, Photo");
                    if (collider.transform.GetComponent<PhotoCheck>())
                    {
                        PhotoOn = true; //애니메이션 조작을 위한 key
                        collider.transform.GetComponent<PhotoCheck>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //아이템을 삭제하고 DoorOpen을 true로 한다.
                }

                if (gameObject.tag == "Photo1")
                {
                    Debug.Log("아이템 체크, Photo1");
                    if (collider.transform.GetComponent<PhotoCheck1>()) // 이 GetComponent를 변경함으로써 cheker 구분을 진행함
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck1>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //아이템을 삭제하고 DoorOpen을 true로 한다.
                }

                if (gameObject.tag == "Photo2")
                {
                    Debug.Log("아이템 체크, Photo2");
                    if (collider.transform.GetComponent<PhotoCheck2>()) // 이 GetComponent를 변경함으로써 cheker 구분을 진행함
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck2>().PhotoCheckOpen(gameObject);

                    }

                    //Destroy(gameObject); //아이템을 삭제하고 DoorOpen을 true로 한다.
                }

                if (gameObject.tag == "DoorKey")
                {
                    Debug.Log("아이템 체크, DoorKey");

                    if (collider.transform.GetComponent<DoorCheck>()) {
                        Debug.Log("문이 열립니다.");
                        DoorOpen = true; //아직 미사용 변수

                        collider.transform.GetComponent<DoorCheck>().DoorOpen();
                    }

                    /*if (collider.transform.GetComponent<PhotoCheck2>()) // 이 GetComponent를 변경함으로써 cheker 구분을 진행함
                    {
                        PhotoOn = true;
                        collider.transform.GetComponent<PhotoCheck2>().PhotoCheckOpen(gameObject);

                    }*/

                    //Destroy(gameObject); //아이템을 삭제하고 DoorOpen을 true로 한다.
                }
            }

        }
    }
}
