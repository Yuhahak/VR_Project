using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayer : MonoBehaviour
{
    //ĳ���� ������
    public float moveSpeed = 10.0f; //�÷��̾� ���콺 ���ǵ�
    public float jumpPower = 10.0f; //���� �
    public float gravityPower = -30.0f; //�߷�
    public float yV = 0;

    private Rigidbody rb;
    public Transform cameraTransform;
    public CharacterController characterController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
    }

    private void LateUpdate()
    {
        Move();
    }

    void Move() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); //���콺 input

        Vector3 movement = new Vector3(h, 0.0f, v);

        movement = cameraTransform.TransformDirection(movement); 
        movement *= moveSpeed;

        if (characterController.isGrounded)
        {
            yV = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yV = jumpPower; 
            }
        }

        yV += (gravityPower * Time.deltaTime);
        movement.y = yV; // ����
        
        characterController.Move(movement * Time.deltaTime);
    }
}
