using Data;
using Data.Difficults;

public class AcceptLevelsDeterminator
{
    private LevelsInfo _levelsInfo;

    public AcceptLevelsDeterminator(LevelsInfo levelsInfo) =>
        _levelsInfo = levelsInfo;

    public void Determine()
    {
        IDifficult difficult = LevelsProgress.Instance.GetDifficultByType(_levelsInfo.CurrentDifficult);

        if (_levelsInfo.CurrentDifficult != typeof(Hard))
            difficult.IncreaseAcceptLevels();
    }
}
