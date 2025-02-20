using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
                
                //Debug.Log("hi");
                //GameManager.Instance.roomName = RoomSettingManager.Instance.roomNameIF.text;
                //Debug.Log("HWP : " + GameManager.Instance.roomName);
            }
            else
            {
                
                //Debug.Log("bye");
                //RoomSettingManager.Instance.roomNameIF.text = GameManager.Instance.roomName;
                //Debug.Log("HWP : " + GameManager.Instance.roomName);
            }
            
        }

        public void Move()
        {
            SubmitPositionRequestRpc();
        }

        [Rpc(SendTo.Server)]
        void SubmitPositionRequestRpc(RpcParams rpcParams = default)
        {
            var randomPosition = GetRandomPositionOnPlane();
            transform.position = randomPosition;
            Position.Value = randomPosition;
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}