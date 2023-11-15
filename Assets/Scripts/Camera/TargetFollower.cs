using System;
using UnityEngine;

namespace Camera
{
    public class TargetFollower : MonoBehaviour
    {
        [field: SerializeField] public Vector3 _offset { get; set; }
        [field: SerializeField] public  Transform _target { get; set; }
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void LateUpdate()
        {
            _transform.position = _target.position + _offset;
        }
    }
}