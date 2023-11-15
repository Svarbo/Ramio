using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public class CheckpointChooserView : MonoBehaviour
    {
        [SerializeField] private Button _trueAnswer;
        [SerializeField] private Button _falseAnswer;

        public event Action<bool> CheckpointChanged;
        
        private void OnEnable()
        {
            _trueAnswer.onClick.AddListener(Test);            
            _falseAnswer.onClick.AddListener(Test2);            
        }

        private void OnDisable()
        {
            _trueAnswer.onClick.RemoveListener(Test);            
            _falseAnswer.onClick.RemoveListener(Test2);            
        }

        private void Test2()
        {
            CheckpointChanged?.Invoke(false);
            Debug.Log("false");
            gameObject.SetActive(false);
        }

        private void Test()
        {
            CheckpointChanged?.Invoke(true);
            Debug.Log("True");
            gameObject.SetActive(false);
        }
    }
}