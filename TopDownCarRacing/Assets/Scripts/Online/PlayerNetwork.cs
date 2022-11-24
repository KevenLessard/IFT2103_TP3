using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private readonly NetworkVariable<PlayerNetworkData>
        _netState = new(writePerm: NetworkVariableWritePermission.Owner);

    private Vector3 _vel;
    private float _rotVel;
    [SerializeField] private float _cheapInterpolationTime = 0.1f;

    private void Update()
    {
        if (IsOwner)
        {
            _netState.Value = new PlayerNetworkData()
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles
            };
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _netState.Value.Position, ref _vel,
                _cheapInterpolationTime);
            transform.rotation = Quaternion.Euler(0,
                0,
                Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, _netState.Value.Rotation.z, ref _rotVel,
                    _cheapInterpolationTime));
        }
    }

    struct PlayerNetworkData : INetworkSerializable
    {
        private float _x, _y;
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
