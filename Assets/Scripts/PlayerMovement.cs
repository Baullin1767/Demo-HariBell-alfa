using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed= 5f;
    [SerializeField]
    float runSpeed = 10f;
    [SerializeField]
    CharacterController controller;

    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine){ return; }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && x != 0 && z != 0)
        {
            
        }

        Vector3 move = transform.right * x + transform.forward * z;

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * walkSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * runSpeed * Time.deltaTime);
        }

        
    }
}
