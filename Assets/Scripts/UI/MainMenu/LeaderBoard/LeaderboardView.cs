using Agava.YandexGames;
using ConstantValues;
using System.Collections.Generic;
using Data;
using Data.Difficults;
using TMPro;
using UnityEngine;

namespace UI.MainMenu.LeaderBoard
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private List<LeaderPlace> _easyLeaderPlaces = new List<LeaderPlace>();
        [SerializeField] private List<LeaderPlace> _mediumLeaderPlaces = new List<LeaderPlace>();
        [SerializeField] private List<LeaderPlace> _hardLeaderPlaces = new List<LeaderPlace>();
        [SerializeField] private TMP_Text _easyPlayerTopPlaceText;
        [SerializeField] private TMP_Text _mediumPlayerTopPlaceText;
        [SerializeField] private TMP_Text _hardPlayerTopPlaceText;
        [SerializeField] private TMP_Text _easyPlayerAttemptionsCountText;
        [SerializeField] private TMP_Text _mediumPlayerAttemptionsCountText;
        [SerializeField] private TMP_Text _hardPlayerAttemptionsCountText;

        private void OnEnable()
        {
            ShowPlayerPlace(null, _easyPlayerTopPlaceText, _easyPlayerAttemptionsCountText);
            //ShowFirstLeaders(easy.GetType().ToString(), _easyLeaderPlaces);
            // ShowFirstLeaders(medium.GetType().ToString(), _mediumLeaderPlaces);
            // ShowFirstLeaders(hard.GetType().ToString(), _hardLeaderPlaces);

            //ShowPlayerPlace(easy.GetType().ToString(), _easyPlayerTopPlaceText, _easyPlayerAttemptionsCountText);
            // ShowPlayerPlace(medium.GetType().ToString(), _mediumPlayerTopPlaceText, _mediumPlayerAttemptionsCountText);
            // ShowPlayerPlace(hard.GetType().ToString(), _hardPlayerTopPlaceText, _hardPlayerAttemptionsCountText);
        }

        private void ShowPlayerPlace(string leaderboardName, TMP_Text playerTopPlaceText, TMP_Text playerAttemptionsCountText)
        {
            #region MyRegion
            // Leaderboard.GetPlayerEntry(leaderboardName, (result) =>
            // {
            //     if (result == null)
            //     {
            //         playerTopPlaceText.text = "-";
            //         playerAttemptionsCountText.text = "-";
            //     }
            //     else
            //     {
            //         playerTopPlaceText.text = result.rank.ToString();
            //         playerAttemptionsCountText.text = result.score.ToString();
            //     }
            // });
            #endregion

            IDifficult easy = LevelsProgress.Instance.GetDifficultByType(typeof(Easy));

            Leaderboard.GetPlayerEntry(easy.GetType().ToString(), result =>
            {
                playerAttemptionsCountText.text = result.score.ToString();
                playerTopPlaceText.text = result.rank.ToString();
            });
        }

        private void ShowFirstLeaders(string leaderboardName, List<LeaderPlace> leaderPlaces)
        {
            //YandexGamesSdk.
            Leaderboard.GetEntries(leaderboardName, (result) =>
            {
                string leaderName;
                int leaderScore;
                int leadersCount = leaderPlaces.Count;

                for (int i = 0; i < leadersCount; i++)
                {
                    LeaderboardEntryResponse entry = result.entries[i];

                    if (entry != null)
                    {
                        leaderName = GetLeaderName(entry);
                        leaderScore = GetLeaderScore(entry);

                        leaderPlaces[i].SetLeaderData(leaderName, leaderScore);
                        leaderPlaces[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        leaderPlaces[i].SetLeaderData(entry.player.publicName, entry.score);
                        leaderPlaces[i].gameObject.SetActive(true);
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