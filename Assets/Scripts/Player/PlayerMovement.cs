using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed= 5f;
    [SerializeField]
    float runSpeed = 10f;
    [SerializeField]
    CharacterController controller;

    bool controlLock = true;
    
    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine) { return; }

        Move();
    }

    
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (controlLock == true)
            {
                controlLock = false;
            }
            else
            {
                controlLock = true;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (!controlLock)
        {
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
}
