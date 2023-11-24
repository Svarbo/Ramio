using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrangesCounter : MonoBehaviour
{
    [SerializeField] private List<Orange> _oranges = new List<Orange>();

    private void Awake()
    {
        int count = LevelsProgress.Instance.GetDifficultByType(typeof(Easy)).GetOrangesCount(SceneManager.GetActiveScene().name);

        for (int i = 0; i < _oranges.Count; i++)
        {
            if (i + 1 <= count)
                _oranges[i].Off();
            else
                break;
        }

        PlayerPrefs.SetInt("CurrentLevelOrangesCount", _oranges.Count);
    }
}