using System.Collections.Generic;
using Agava.YandexGames;
using TMPro;
using UnityEngine;

namespace UI.MainMenu.LeaderBoard
{
    public class LeaderboardCanvas : MonoBehaviour
    {
        private const string LeaderboardName = "Leaderboard1";

        [SerializeField] private List<LeaderPlace> _leaderPlaces = new List<LeaderPlace>();
        [SerializeField] private TMP_Text _playerTopPlaceText;
        [SerializeField] private TMP_Text _playerAttemptionsCountText;

        private void OnEnable()
        {
            ShowFirstLeaders();
            ShowPlayerPlace();
        }

        private void ShowPlayerPlace()
        {
            Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
            {
                if (result == null)
                {
                    _playerTopPlaceText.text = "-";
                    _playerAttemptionsCountText.text = "-";
                }
                else
                {
                    _playerTopPlaceText.text = result.rank.ToString();
                    _playerAttemptionsCountText.text = result.score.ToString();
                }
            });
        }

        private void ShowFirstLeaders()
        {
            Leaderboard.GetEntries(LeaderboardName, (result) =>
            {
                string leaderName;
                int leaderScore;
                int leadersCount = _leaderPlaces.Count;

                for (int i = 0; i < leadersCount; i++)
                {
                    LeaderboardEntryResponse entry = result.entries[i];

                    if (entry != null)
                    {
                        leaderName = GetLeaderName(entry);
                        leaderScore = GetLeaderScore(entry);

                        _leaderPlaces[i].SetLeaderData(leaderName, leaderScore);
                        _leaderPlaces[i].gameObject.SetActive(true);
                    }
                }
            });
        }

        private int GetLeaderScore(LeaderboardEntryResponse entry) =>
            entry.score;

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
                leaderName = "������";
            if (playerLanguageIndex == 1)
                leaderName = "Anonymous";
            if (playerLanguageIndex == 2)
                leaderName = "Anonim";

            return leaderName;
        }
    }
}