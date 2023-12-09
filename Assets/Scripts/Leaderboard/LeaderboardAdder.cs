using System;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using ConstantValues;
using Data;
using Data.Difficults;
using UnityEngine;

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
            Agava.YandexGames.Leaderboard.GetPlayerEntry(nameLeaderboard, _ =>
            {
                Agava.YandexGames.Leaderboard.SetScore(nameLeaderboard, countTry);
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