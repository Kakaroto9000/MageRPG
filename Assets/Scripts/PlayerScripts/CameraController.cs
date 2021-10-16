using UnityEngine;
using Mirror;

public class CameraController : MonoBehaviour
{
    private void Awake()
    {
        if(!gameObject.transform.parent.GetComponent<NetworkIdentity>().isLocalPlayer)
        {
            Camera camera = gameObject.GetComponent<Camera>();
            Destroy(camera);
        }
    }
    void Start()
    {
        
    }
}
