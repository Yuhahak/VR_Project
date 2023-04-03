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
    public GameObject heldItem;
    public Transform hand;
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.Q;


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
        if (pickupActivated)
        {
            if(hitInfo.transform != null) // 조준선에 아이템이 있을때
            {

                if (Input.GetKeyDown(pickupKey) && heldItem == null)
                {
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject.tag == "Player")
                        {
                            Destroy(hitInfo.transform.gameObject);
                            Debug.Log("아이템 픽업");
                            heldItem = Instantiate(item, hand);
                            heldItem.transform.localPosition = Vector3.zero;
                            heldItem.transform.localRotation = Quaternion.identity;
                            heldItem.GetComponent<Rigidbody>().isKinematic = true;
                            break;
                        }
                    }
                }
                InfoDisappear();
            }
        }
    }

    void CheckItem()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item" && heldItem == null)
            {
                ItemInfoAppear();
            }
            if (hitInfo.transform.tag == "Lock" && heldItem == null)
            {
                ItemInfoAppear();
            }

        }
        else
        {
            InfoDisappear();
        }
    }

    void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;
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

                heldItem.GetComponent<Rigidbody>().isKinematic = false;
                heldItem.transform.parent = null;
                heldItem = null;
            }

            pickupActivated = false;
        }

    }
}
