using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class CharacterStat
    {
        public event Action<int> OnValueChanged;

        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public int Value { get; private set; }

        public CharacterStat(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}