using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Agava.YandexGames;

public class LeaderboardCanvas : MonoBehaviour
{
    [SerializeField] private List<LeaderPlace> _leaderPlaces = new List<LeaderPlace>();
    [SerializeField] private TMP_Text _playerTopPlaceText;

    private void OnEnable()
    {
        ShowLeaders();
    }

    private void ShowLeaders()
    {
        Leaderboard.GetEntries("Leaderboard1", (result) =>
        {
            ShowPlayerPlace(result);
            ShowFirstLeaders(result);
        });
    }

    private void ShowPlayerPlace(LeaderboardGetEntriesResponse result)
    {
        _playerTopPlaceText.text = result.userRank.ToString();
    }

    private void ShowFirstLeaders(LeaderboardGetEntriesResponse result)
    {
        string leaderName;
        int leaderScore;
        int leadersCount = _leaderPlaces.Count;

        for (int i = 0; i < leadersCount; i++)
        {
            LeaderboardEntryResponse entry = result.entries[i];

            if(entry != null)
            {
                leaderName = GetLeaderName(entry);
                leaderScore = GetLeaderScore(entry);

                _leaderPlaces[i].SetLeaderData(leaderName, leaderScore);
                _leaderPlaces[i].gameObject.SetActive(true);
            }
        }
    }

    private int GetLeaderScore(LeaderboardEntryResponse entry)
    {
        return entry.score;
    }

    private string GetLeaderName(LeaderboardEntryResponse entry)
    {
        string leaderName;

        leaderName = entry.player.publicName;

        if (string.IsNullOrEmpty(leaderName))
            leaderName = SetAnonimusName();

        return leaderName;
    }

    private string SetAnonimusName()
    {
        string leaderName = " ";
        int playerLanguageIndex = UnityEngine.PlayerPrefs.GetInt("LanguageIndex");

        if (playerLanguageIndex == 0)
            leaderName = "Аноним";
        if (playerLanguageIndex == 1)
            leaderName = "Anonymous";
        if (playerLanguageIndex == 2)
            leaderName = "Anonim";

        return leaderName;
    }
}