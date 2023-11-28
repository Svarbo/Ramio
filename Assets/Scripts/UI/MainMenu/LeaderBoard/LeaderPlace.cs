using TMPro;
using UnityEngine;

public class LeaderPlace : MonoBehaviour
{
    [SerializeField] private TMP_Text _leaderNamePlace;
    [SerializeField] private TMP_Text _leaderScorePlace;

    public void SetLeaderData(string leaderName, int leaderScore)
    {
        _leaderNamePlace.text = leaderName;
        _leaderScorePlace.text = leaderScore.ToString();
    }
}