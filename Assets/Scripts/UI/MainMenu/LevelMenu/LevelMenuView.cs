using Data;
using Data.Difficults;
using UI.MainMenu.LevelMenu.LevelChoosers;
using UnityEngine;

namespace UI.MainMenu.LevelMenu
{
    public class LevelMenuView : MonoBehaviour
    {
        private LevelsInfo _levelsInfo;
        [field: SerializeField] public LevelsRow LevelsRow { get; private set; }
        [field: SerializeField] public DifficultChooserView DifficultChooserView { get; private set; }

        private void OnEnable()
        {
            IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);
            LevelsRow.ShowLevelChoosers(difficult.GetAcceptLevels());
        }

        public void Construct(LevelsInfo levelsInfo) =>
            _levelsInfo = levelsInfo;
    }
}