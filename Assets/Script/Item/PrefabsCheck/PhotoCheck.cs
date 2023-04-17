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
        //PhotoCheckOpen();
    }

    public void PhotoCheckOpen(GameObject g)
    {
        if (isOpen == false)
        {
            if (Checker.instance.PhotoOn == true)
            {
                Debug.Log("액자와 사진이 합쳐졌습니다.");
                item = Instantiate(GetComponent<ItemPickUp>().item.itemPrefab);
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = transform.position;
                isOpen = true;
                Destroy(g);
            }
        }
    }
}
