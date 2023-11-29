using System.Collections.Generic;
using UnityEngine;

namespace UI.MainMenu.LevelMenu.LevelChoosers
{
    public class LevelsRow : MonoBehaviour
    {
        [SerializeField] private List<LevelChooser> _levelChoosers;

        public IReadOnlyList<LevelChooser> LevelChoosers => _levelChoosers;

        public void ShowLevelChoosers(int count)
        {
            for (int i = 0; i < _levelChoosers.Count; i++)
            {
                if (count > 0)
                    _levelChoosers[i].Show();
                else
                    _levelChoosers[i].Hide();

                count--;
            }
        }
    }
}