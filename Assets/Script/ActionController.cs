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

    //������ üũ
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
        if(heldItem != null) // �������� ��� ������
        {
            switch (heldItem.name) // heldItem �ȿ� ������Ʈ �̸���
            {
                case ("Rock(Clone)"): // Rock(Clone) �̶��
                    IsRock = true; 
                    break;
                case ("Gun(Clone)"):
                    IsGun = true;
                    break;
            }
            
        }
        else // �������� ��� ���� �ʴٸ�
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
        if (pickupActivated) // true�� ���� �۵�
        {
            
            if (hitInfo.transform != null)
            {

                if (Input.GetKeyDown(pickupKey) && heldItem == null)
                {
                    
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject.tag == "Player") //Player �±׸� ���� �ִ� ��
                        {
                            Destroy(hitInfo.transform.gameObject); //���� �� �������� �����´� CheckItem���� Ȯ�� ����
                            Debug.Log("������ �Ⱦ�");
                            heldItem = Instantiate(item, hand);
                            heldItem.transform.localPosition = Vector3.zero;
                            heldItem.transform.localRotation = Quaternion.identity;
                            heldItem.GetComponent<Rigidbody>().isKinematic = true;
                            break;
                        }
                    }
                }
                InfoDisappear(); //pickupActivated �ʱ�ȭ
            }
        }
    }

    void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask)) //�þ߿� ���� �� �ľ�
        {

            if (hitInfo.transform.tag == "Item" && heldItem == null) // ���ӿ� ���� ������Ʈ�� tag�� Item�̰� �տ� ����� ���ٸ�
            {
                ItemInfoAppear(); //�ش� �Լ� ���� (�۾� ��Ÿ����)
            }
            if (hitInfo.transform.tag == "Lock" && heldItem == null) /// tag�� Lock�̾ �Ȱ��� ����
            {
                ItemInfoAppear();
            }

        }
        else
        {
            InfoDisappear(); //�۾� ����
        }
    }

    void ItemInfoAppear()
    {
        pickupActivated = true; //false ���� true�� ����
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName; // ItemPickUp script���� ������
        item = hitInfo.transform.GetComponent<ItemPickUp>().item.itemPrefab; // ��κ� �߿� ** itempickup��ũ��Ʈ�� �����ص� �������� ���� �������� ����


    }

    void InfoDisappear()
    {
        actionText.gameObject.SetActive(false);
        if (heldItem != null)
        {
            if (Input.GetKeyDown(dropKey))
            {
                Debug.Log("������ ��������");

                heldItem.GetComponent<Rigidbody>().isKinematic = false; //���� ����
                heldItem.transform.parent = null;
                heldItem = null;
            }

            pickupActivated = false;
        }

    }
}
