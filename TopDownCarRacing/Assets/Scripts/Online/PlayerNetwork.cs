using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking.Transport;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{

    List<NetworkConnection> activeSpawns = new List<NetworkConnection>();
    
    private readonly NetworkVariable<PlayerNetworkData>
        _netState = new(writePerm: NetworkVariableWritePermission.Owner);

    private Vector3 _vel;
    private float _rotVel;
    [SerializeField] private float _InterpolationTime = 0.1f;
    private bool _1stframe = true;

    

    private void Update()
    {
        if (IsOwner)
        {
            if (_1stframe)
            {
                gameObject.transform.position = new Vector3(-50, 6, 0);
                _1stframe = false;
            }

            gameObject.name = "Player_one";
            _netState.Value = new PlayerNetworkData()
            {
                
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles
            };
        }
        else
        {
            gameObject.name = "Player_two";
            transform.position = Vector3.SmoothDamp(transform.position, _netState.Value.Position, ref _vel,
                _InterpolationTime);
            transform.rotation = Quaternion.Euler(0,
                0,
                Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, _netState.Value.Rotation.z, ref _rotVel,
                    _InterpolationTime));
        }
        
    }

    struct PlayerNetworkData : INetworkSerializable
    {

        private float _x;
        private float _y;
        private float _zRot;

        internal Vector3 Position
        {
            get => new Vector3(_x, _y, 0);
            set
            {
                _x = value.x;
                _y = value.y;
            }
        }

        internal Vector3 Rotation
        {
            get => new Vector3(0, 0, _zRot);
            set => _zRot = value.z;
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _x);
            serializer.SerializeValue(ref _y);
            serializer.SerializeValue(ref _zRot);
        }
    }
}
