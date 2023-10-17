using System;
using UnityEngine;

namespace Camera
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _target;
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