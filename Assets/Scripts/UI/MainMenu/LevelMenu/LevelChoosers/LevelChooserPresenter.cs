using UnityEngine;

public class LevelChooserPresenter
{
    private readonly LevelsRow _levelsRow;
    private readonly StateMachine _stateMachine;
    private LevelsInfo _levelsInfo;

    public LevelChooserPresenter(LevelsRow levelsRow, LevelsInfo levelsInfo, StateMachine stateMachine)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
        _levelsRow = levelsRow;
    }
    
    public void ShowLevels(int count) =>
        _levelsRow.ShowLevelChoosers(count);
    
    public void StartGame(string levelName)
    {
        _levelsInfo.SceneName = levelName;

        if (_levelsInfo.CurrentDifficult == null)
            Debug.Log("kek");

        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }
}