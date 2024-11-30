using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCamera : MonoBehaviourPun
{

    public CinemachineVirtualCamera playerCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void assignCamera()
    {
        if (photonView.IsMine == true)
        {
            CinemachineVirtualCamera playerCam = FindObjectOfType<CinemachineVirtualCamera>();
            playerCam.Follow = transform;
            playerCam.LookAt = transform;
        }
    }
}
