using Photon.Pun;
using UnityEngine;

public class Interective : MonoBehaviour
{
    [SerializeField]
    UnityEngine.Camera Camera;
    [SerializeField]
    float maxDistanceRay;
    Ray ray;
    RaycastHit hit;

    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (!photonView.IsMine) { return; }
        Ray();
        DrawRay();
        Interact();
    }

    void Ray() 
    {
        ray = Camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    void DrawRay() 
    {
        if (Physics.Raycast(ray, out hit, maxDistanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.blue);
        }
        if (hit.transform == null)
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.red);
        }
    }

    void Interact() 
    {
        if (hit.transform != null && hit.transform.GetComponent<_InteractiveObject>())
        {
            Debug.DrawRay(ray.origin, ray.direction * maxDistanceRay, Color.green);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.transform.GetComponent<_InteractiveObject>().Interective();
            }
        }
    }
}
