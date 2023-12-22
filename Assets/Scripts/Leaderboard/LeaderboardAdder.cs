using Agava.YandexGames;
using ConstantValues;
using Data;
using Data.Difficults;
using System;

namespace GameLeaderboard
{
    public class LeaderboardAdder
    {
        public void SetCountTryByDifficult(Type difficult)
        {
            if (PlayerAccount.IsAuthorized == false)
                return;

            int countTry = LevelsProgress.Instance.GetDifficultByType(difficult).GetAllCountTry();
            string nameLeaderboard = GetNameLeaderboardByDifficult(difficult);
            Leaderboard.GetPlayerEntry(nameLeaderboard, _ =>
            {
                Leaderboard.SetScore(nameLeaderboard, countTry);
            });
        }

        private string GetNameLeaderboardByDifficult(Type difficultType)
        {
            if (difficultType == typeof(Easy))
                return LeaderboardsNames.EasyLeaderboardName;
            else if (difficultType == typeof(Medium))
                return LeaderboardsNames.MediumLeaderboardName;
            else
                return LeaderboardsNames.HardLeaderboardName;
        }
    }
}