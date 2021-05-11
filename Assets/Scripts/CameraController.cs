using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet;

    // FixedUpdate
    public void FixedUpdate()
    {
        transform.position = player.transform.position + offSet ;
    }
}
