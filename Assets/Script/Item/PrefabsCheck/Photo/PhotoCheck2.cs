using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PhotoCheck2 : MonoBehaviour
{
    private bool isOpen = false; //��ħ�� 1ȸ�� �����ϵ����ϴ� bool

    public GameObject item;
    private RaycastHit hitInfo;
    public static PhotoCheck2 instance;
/*
    public Animator padeAnim;*/
    

    private void Awake()
    {
        PhotoCheck2.instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //PhotoCheckOpen(); CHEKER.CS���� �ҷ���
    }

    public void PhotoCheckOpen(GameObject g)
    {
        if (isOpen == false)
        {
            if (Checker.instance.PhotoOn == true)
            {
                Debug.Log("���ڿ� ������ ���������ϴ�.");
                item = Instantiate(GetComponent<ItemPickUp>().item.itemPrefab);
                item.GetComponent<Rigidbody>().isKinematic = true; //����
                item.transform.position = transform.position;
                item.layer = 0; //layer�� 0���� �����Ͽ� ���� �� ������ ����
                isOpen = true;
                
                Destroy(g);

            }
        }
        /*padeAnim.SetBool("isOpenTrue", true);*/
    }

}
