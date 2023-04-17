using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f;
    public float rotationX;
    public float rotationY;

    public static MouseMove instance;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        MouseMove.instance = this;
    }
    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationX += mouseMoveY * sensitivity * Time.deltaTime;
        rotationY += mouseMoveX * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseMoveX * sensitivity * Time.deltaTime);
        transform.Rotate(Vector3.left * mouseMoveY * sensitivity * Time.deltaTime);

        if (rotationX >= 35f)
        {
            rotationX = 35f;
        }

        if (rotationX <= -50f)
        {
            rotationX = -50f;
        }

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0);
    }

    public void unLock() //���콺Ŀ�� ���̰�
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Lock() //���콺 Ŀ�� �Ⱥ��̰�
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
