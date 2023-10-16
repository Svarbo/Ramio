using System;
using Configs;
using UnityEngine;

namespace Players
{
    public class PlayerInputController : MonoBehaviour
    {
        public Action<Vector2> Moved;
        public Action Jump;
        
        private float _axis;

        private void Update()
        {
            _axis = Input.GetAxis(InputInfo.Horizontal);

            if (_axis > 0)
                Moved?.Invoke(Vector2.right);
            else if (_axis < 0)
                Moved?.Invoke(Vector2.left);
            else if(_axis == 0)
                Moved?.Invoke(Vector2.zero);
            
            _axis = Input.GetAxis(InputInfo.Vertical);
            
            if (_axis > 0)
                Jump?.Invoke();
        }
    }
}