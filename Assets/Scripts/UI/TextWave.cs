using TMPro;
using UnityEngine;

    public class TextWave : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
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
    }
