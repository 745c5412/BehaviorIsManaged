

// Generated on 10/25/2012 10:43:00
using System;
using System.Collections.Generic;
using BiM.Protocol.Tools;

namespace BiM.Protocol.Data
{
    [D2OClass("Weapon")]
    public class Weapon : Item
    {
        public int apCost;
        public int minRange;
        public int range;
        public Boolean castInLine;
        public Boolean castInDiagonal;
        public Boolean castTestLos;
        public int criticalHitProbability;
        public int criticalHitBonus;
        public int criticalFailureProbability;
    }
}