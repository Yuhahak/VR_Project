using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHand : MonoBehaviour
{
    public GameObject item; //해당 Item
    public Transform hand; // 손 위치
    public KeyCode pickupKey = KeyCode.E; //Item 잡는 키
    public KeyCode dropKey = KeyCode.Q; //Item 버리는 키

    private GameObject heldItem; //손에 든 아이템 > 따로 오브젝트 만들어서 넣어주어야함

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && heldItem == null) //E키를 누르고 손에 아이템이 없을 경우
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f); //충돌 배열에 순차적으로 컴퍼넌트 값 변경을 위한 배열 Physics.OverlapSphere로 주변 충돌체 감지
            foreach (Collider collider in colliders) //collider 배열을 훑음
            {
                if (collider.gameObject.tag == "Item") // Item tag가 달린 오브젝트 감지 시 > 작동하려면 Item오브젝트에 Item tag를 단다
                { 
                    Debug.Log("1"); //로그에 1 등록
                    heldItem = Instantiate(item, hand); //heldItem에 item 객체를 hand 위치에 생성
                    heldItem.transform.localPosition = Vector3.zero; //부모 위치 기준 zero
                    heldItem.transform.localRotation = Quaternion.identity; //원래 회전 각도 적용
                    heldItem.GetComponent<Rigidbody>().isKinematic = true; // 물리엔진의 영향을 받지 않음
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(dropKey) && heldItem != null) //Q키를 누르고 손에 아이템이 있을 경우
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false; // 물리엔진의 영향을 받음 (아래로 툭 떨어진다든지의 퍼포먼스가 있음)
            heldItem.transform.parent = null; // parent의 위치를 참조하지 않음
            heldItem = null;  //heldItem을 null로 변경 즉, 손에 Item을 들 수 있는 상태로 원상복귀
        }
    }
}
