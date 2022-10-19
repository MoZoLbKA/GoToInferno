using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Stats:IStats
    {
        public List<Stat> AllStats { get; private set; }

        public Stats(List<Stat> stats)
        {
            AllStats = stats;
        }
        public IEnumerable<Stat> GetStats()
        {
            return AllStats;
        }
    }
}
