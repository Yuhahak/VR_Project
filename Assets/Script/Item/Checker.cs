using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public bool DoorOpen = false;

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Checker")
            {
                Debug.Log("아이템 체크");
                DoorOpen = true;
                Destroy(gameObject);

            }
        }
    }
}
