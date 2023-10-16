using Players;
using UnityEngine;

public class Referee : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;

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
        //_playerMover.Stop();
    }

    public void DeclairLose()
    {
        //_playerMover.Stop();
    }
}