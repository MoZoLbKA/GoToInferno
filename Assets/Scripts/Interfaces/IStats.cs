﻿using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IStats
    {
        public IEnumerable<Stat> GetStats();
    }
}
