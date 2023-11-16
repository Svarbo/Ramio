using UI.Level.EndGame;
using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] PlayerCanvasDrawer _playerCanvasDrawer;
    
    private void OnEnable()
    {
        _player.PlayerDied += DeclairLose;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= DeclairLose;
    }

    public void DeclairWin()
    {
        _playerCanvasDrawer.DrawWinPanel();
    }

    public void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
    }
}