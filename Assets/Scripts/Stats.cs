using System;
using UnityEngine;

[Serializable]
public class Stats
{
    public int MeteorsKilled { get; set; }

    public int BestScore { get; set; }

    public int GlobalScore { get; set; }

    public int Deaths { get; set; }

    public int ShieldsDestroyed { get; set; }

    public int PowerUpsTaken { get; set; }
}
