using System.Collections.Generic;
using UI.MainMenu.LevelMenu.Views.Levels;
using UnityEngine;

namespace UI.MainMenu.Views.Levels
{
    public class LevelsRow : MonoBehaviour
    {
        [SerializeField] private List<LevelChooser> _levelChoosers;
        public IReadOnlyList<LevelChooser> LevelChoosers => _levelChoosers;

        public void ShowLevelChoosers(int count)
        {
            for (int i = 0; i < count; i++)
                _levelChoosers[i].Show();
        }
    }
}