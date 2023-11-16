using System;

public class Referee : IDisposable
{
    private readonly Player _player;
    private readonly PlayerCanvasDrawer _playerCanvasDrawer;

    public Referee(Player player, PlayerCanvasDrawer playerCanvasDrawer)
    {
        _player = player;
        _playerCanvasDrawer = playerCanvasDrawer;
        _player.PlayerDied += DeclairLose;
    }

    public void DeclairWin()
    {
        _playerCanvasDrawer.DrawWinPanel();
    }

    public void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
    }

    public void Dispose()
    {
        _player.PlayerDied -= DeclairLose;
    }
}