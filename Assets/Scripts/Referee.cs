using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerCanvasDrawer _playerCanvasDrawer;

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
        _playerMover.Stop();
        _playerCanvasDrawer.DrawWinPanel();
    }

    public void DeclairLose()
    {
        _playerMover.Stop();
        _playerCanvasDrawer.DrawDefeatPanel();
    }
}