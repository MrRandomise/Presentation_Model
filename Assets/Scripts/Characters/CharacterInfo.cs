using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterInfo
    {
        public event Action<CharacterStat> OnStatAdded;
        public event Action<CharacterStat> OnStatRemoved;

        public HashSet<CharacterStat> Stats = new();

        public void AddStat(CharacterStat stat)
        {
            if (Stats.Add(stat))
            {
                OnStatAdded?.Invoke(stat);
            }
        }

        public void RemoveStat(CharacterStat stat)
        {
            if (Stats.Remove(stat))
            {
                OnStatRemoved?.Invoke(stat);
            }
        }

        public CharacterStat GetStat(string name)
        {
            foreach (var stat in Stats)
            {
                if (stat.Name == name)
                {
                    return stat;
                }
            }

            throw new Exception($"Stat {name} is not found!");
        }

        public bool CheckStat(string name)
        {
            foreach (var stat in Stats)
            {
                if (stat.Name == name)
                {
                    return true;
                }
            }

            return false;
        }
        public CharacterStat[] GetStats()
        {
            return Stats.ToArray();
        }
    }
}