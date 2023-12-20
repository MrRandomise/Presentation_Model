using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class StatField : MonoBehaviour
    {
        [SerializeField] private TMP_Text fieldText;

        private CharacterStat _characterStat;

        public void SetFieldStat(CharacterStat characterStat)
        {
            _characterStat = characterStat;
            fieldText.text = $"{characterStat.Name} : {characterStat.Value}";
        }

        public CharacterStat GetCharacterStat()
        {
            return _characterStat;
        }
    }
}
