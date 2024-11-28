using Cinemachine;
using UnityEngine;

public class setCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    void Start()
    {
        cam.Follow = gameObject.transform;
    }
}
