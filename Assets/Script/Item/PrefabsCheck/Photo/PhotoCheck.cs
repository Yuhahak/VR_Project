using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PhotoCheck : MonoBehaviour
{
    private bool isOpen = false; //합침을 1회만 가능하도록하는 bool

    public GameObject item;
    private RaycastHit hitInfo;
    public static PhotoCheck instance;
/*
    public Animator padeAnim;*/
    

    private void Awake()
    {
        PhotoCheck.instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //PhotoCheckOpen(); CHEKER.CS에서 불러옴
    }

    public void PhotoCheckOpen(GameObject g)
    {
        if (isOpen == false)
        {
            if (Checker.instance.PhotoOn == true)
            {
                Debug.Log("액자와 사진이 합쳐졌습니다.");
                item = Instantiate(GetComponent<ItemPickUp>().item.itemPrefab);
                item.GetComponent<Rigidbody>().isKinematic = true; //고정
                item.transform.position = transform.position;
                item.layer = 0; //layer를 0으로 변경하여 집을 수 없도록 만듦
                isOpen = true;
                
                Destroy(g);

            }
        }
        /*padeAnim.SetBool("isOpenTrue", true);*/
    }

}
