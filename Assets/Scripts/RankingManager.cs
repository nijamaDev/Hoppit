﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class RankingManager
{
    private static readonly int _rankedScoresNumber = 5;

    public static string RecordScore(string json, int mode, int score)
    {
        var rank = JsonConversor.ConvertJsonToRanking(json);
        int posInRanking = -1;
        for (int i = 0; i < _rankedScoresNumber; i++)
        {
            if(score > rank[mode][i])
            {
                posInRanking = i;
                rank[mode].Insert(i, score);
                rank[mode].RemoveAt(_rankedScoresNumber);
                break;
            }
        }
        return JsonConversor.ConvertRankingToJson(rank);
    }
    public static List<List<int>> InitializeEmptyRanking()
    {
        var newRanking = new List<List<int>>();
        for (int i = 0; i < 5; i++)
        {
            var temp = new List<int>();
            newRanking.Add(temp);
            for (int j = 0; j < _rankedScoresNumber; j++)
            {
                newRanking[i].Add(0);
            }
        }
        return newRanking;
    }
}