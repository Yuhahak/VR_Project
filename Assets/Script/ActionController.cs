using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;

    private bool pickupActivated = false;

    private RaycastHit hitInfo;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Text actionText;

    public GameObject item;
    public GameObject itemLetter;
    public GameObject heldItem = null;
    public Transform hand;
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.Q;

    //아이템 체크
    public bool IsRock = false; 
    public bool IsGun = false;


    public static ActionController instance;

    private void Awake()
    {
        ActionController.instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();
        if(heldItem != null) // 아이템을 들고 있을때
        {
            switch (heldItem.name) // heldItem 안에 오브젝트 이름이
            {
                case ("Rock(Clone)"): // Rock(Clone) 이라면
                    IsRock = true; 
                    break;
                case ("Gun(Clone)"):
                    IsGun = true;
                    break;
            }
            
        }
        else // 아이템을 들고 있지 않다면
        {
            IsRock = false;
            IsGun = false;
        }
    }



    

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
        
    }

    void CanPickUp()
    {
        if (pickupActivated) // true일 때만 작동
        {
            
            if (hitInfo.transform != null)
            {

                if (Input.GetKeyDown(pickupKey) && heldItem == null)
                {
                    
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject.tag == "Player") //Player 태그를 갖고 있는 자
                        {
                            Destroy(hitInfo.transform.gameObject); //삭제 후 프리펩을 가져온다 CheckItem에서 확인 가능
                            Debug.Log("아이템 픽업");
                            heldItem = Instantiate(item, hand);
                            heldItem.transform.localPosition = Vector3.zero;
                            heldItem.transform.localRotation = Quaternion.identity;
                            heldItem.GetComponent<Rigidbody>().isKinematic = true;
                            break;
                        }
                    }
                }
                InfoDisappear(); //pickupActivated 초기화
            }
        }
    }

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask)) //시야에 닿은 것 파악
        {

            if (hitInfo.transform.tag == "Item" && heldItem == null) // 에임에 닿은 오브젝트가 tag가 Item이고 손에 든것이 없다면
            {
                ItemInfoAppear(); //해당 함수 실행 (글씨 나타내줌)
            }
            if (hitInfo.transform.tag == "Lock" && heldItem == null) /// tag가 Lock이어도 똑같이 동작
            {
                ItemInfoAppear();
            }

        }
        else
        {
            InfoDisappear(); //글씨 없음
        }
    }

    void ItemInfoAppear()
    {
        pickupActivated = true; //false 에서 true로 변경
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName; // ItemPickUp script에서 가져옴
        item = hitInfo.transform.GetComponent<ItemPickUp>().item.itemPrefab; // 요부분 중요 ** itempickup스크립트에 저장해둔 프리펩을 고대로 가져오는 구문


    }

    void InfoDisappear()
    {
        actionText.gameObject.SetActive(false);
        if (heldItem != null)
        {
            if (Input.GetKeyDown(dropKey))
            {
                Debug.Log("아이템 내려놓기");

                heldItem.GetComponent<Rigidbody>().isKinematic = false; //고정 해제
                heldItem.transform.parent = null;
                heldItem = null;
            }

            pickupActivated = false;
        }

    }
}
