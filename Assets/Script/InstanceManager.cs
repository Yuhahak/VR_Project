using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public static InstanceManager s; // 아이템 소유 여부를 판단할 스크립트
    
    private void Awake()
    {
        s = this;
    }

    public bool key1 = false;
    public bool openBox = false;
}
