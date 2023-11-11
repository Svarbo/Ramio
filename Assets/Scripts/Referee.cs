using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
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
        _playerCanvasDrawer.DrawWinPanel();
    }

    public void DeclairLose()
    {
        _playerCanvasDrawer.DrawDefeatPanel();
    }
}