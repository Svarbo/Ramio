using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Menu
{
    public class DynamicGameName : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private Color _color1;
        private Color _color2;
        private Color _color3;
        private Color _color4;

        private WaitForSeconds _waitForSeconds;
        private int _counter;

        private void Awake()
        {
            MyClass myClass = new MyClass();
            myClass.Xer  //событие
                +=//подписка
                MyClassOnPerformed; // метод
            myClass.Xer += MyClassOnPerformed2;
            myClass.СимуляцияНажатияКнопки();
        }

        private void MyClassOnPerformed2()
        {
            Debug.Log("Performed2");
        }

        private void MyClassOnPerformed() =>
            Debug.Log("Performed");

        private void Start()
        {
            // _waitForSeconds = new WaitForSeconds(1.6f);
            // _color1 = SetColor();
            // _color2 = SetColor();
            // _color3 = SetColor();
            // _color4 = SetColor();
            //
            // StartCoroutine(StartTextAnimationCoroutine());
        }

        private void Update()
        {
            _text.ForceMeshUpdate();
            TMP_TextInfo textInfo = _text.textInfo;
          
            for (int i = 0; i < textInfo.characterCount; ++i)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                    continue;

                Vector3[] verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; ++j)
                {
                    Vector3 orig = verts[charInfo.vertexIndex + j];
                    verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; ++i)
            {
                TMP_MeshInfo meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                _text.UpdateGeometry(meshInfo.mesh, i);
            }
        }

        private IEnumerator StartTextAnimationCoroutine()
        {
            while (true)
            {
                if (_counter >= 3)
                {
                    _color1 = SetColor();
                    _color2 = SetColor();
                    _color3 = SetColor();
                    _color4 = SetColor();
                    _counter = 0;
                }

                _counter++;
                _text.colorGradient = new VertexGradient(_color1, _color2, _color3, _color4);
                //_text.colorGradientPreset = new TMP_ColorGradient(_color1, _color2, _color3, _color4);
                yield return _waitForSeconds;
            }
        }

        private Color SetColor() =>
            new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1);
    }

    internal class MyClass
    {
        public event Action Xer;

        public void СимуляцияНажатияКнопки() =>
            InvokePerformed();

        private void InvokePerformed()
        {
            Xer?.Invoke();
        }
    }
}