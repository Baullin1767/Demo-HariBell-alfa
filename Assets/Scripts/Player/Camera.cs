using Photon.Pun;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    [SerializeField]
    float mouseSensitivity = 100f;
    [SerializeField]
    Transform playerBody;
    
    PhotonView photonView;
    Camera _camera;

    float xRotation = 0f;


    void Start()
    {
        photonView = GetComponent<PhotonView>();
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        _camera.gameObject.SetActive(photonView.IsMine);

        Look();
    }

    private void Look()
    {

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
