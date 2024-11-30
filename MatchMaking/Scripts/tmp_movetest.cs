using UnityEngine;
using Photon.Pun;

public class tmp_movetest : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    private bool isJump;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (PV.IsMine)
        {
            float axis = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 7,
                                            0,
                                            Input.GetAxisRaw("Vertical") * Time.deltaTime * 7));
            if (Input.GetKey(KeyCode.Space))
            {
                isJump = true;
                PV.RPC("Jump", RpcTarget.All, axis); //RPC 함수 호출 
            }
        }
    }

    //RPC 함수
    [PunRPC]
    private void Jump(float axis)
    {
        if (!isJump)
            return;
        rigidbody.AddForce(Vector3.up * .5f, ForceMode.Impulse);
        isJump = false;
    }
}
