using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHand : MonoBehaviour
{
    public GameObject item; //�ش� Item
    public Transform hand; // �� ��ġ
    public KeyCode pickupKey = KeyCode.E; //Item ��� Ű
    public KeyCode dropKey = KeyCode.Q; //Item ������ Ű

    private GameObject heldItem; //�տ� �� ������ > ���� ������Ʈ ���� �־��־����

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && heldItem == null) //EŰ�� ������ �տ� �������� ���� ���
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); //�浹 �迭�� ���������� ���۳�Ʈ �� ������ ���� �迭 Physics.OverlapSphere�� �ֺ� �浹ü ����
            foreach (Collider collider in colliders) //collider �迭�� ����
            {
                if (collider.gameObject.tag == "Item") // Item tag�� �޸� ������Ʈ ���� �� > �۵��Ϸ��� Item������Ʈ�� Item tag�� �ܴ�
                { 
                    Debug.Log("1"); //�α׿� 1 ���
                    heldItem = Instantiate(item, hand); //heldItem�� item ��ü�� hand ��ġ�� ����
                    heldItem.transform.localPosition = Vector3.zero; //�θ� ��ġ ���� zero
                    heldItem.transform.localRotation = Quaternion.identity; //���� ȸ�� ���� ����
                    heldItem.GetComponent<Rigidbody>().isKinematic = true; // ���������� ������ ���� ����
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(dropKey) && heldItem != null) //QŰ�� ������ �տ� �������� ���� ���
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false; // ���������� ������ ���� (�Ʒ��� �� �������ٵ����� �����ս��� ����)
            heldItem.transform.parent = null; // parent�� ��ġ�� �������� ����
            heldItem = null;  //heldItem�� null�� ���� ��, �տ� Item�� �� �� �ִ� ���·� ���󺹱�
        }
    }
}
