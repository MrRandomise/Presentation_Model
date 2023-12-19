using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatsManager
    {
        private CharacterStat _characterStat;

        private CharacterInfo _characterInfo;

        private ServiceStatsInfo _serviceStatsInfo;

        public CharacterStatsManager(ServiceStatsInfo serviceStatsInfo, CharacterStat characterStat, CharacterInfo characterInfo)
        {
            _characterStat = characterStat;
            _characterInfo = characterInfo;
            _serviceStatsInfo = serviceStatsInfo;
        }

        public void ShowStatsInfo(CharactersConfig characterInfo)
        {
            try
            {
                _serviceStatsInfo.Stat1.text = $"{_characterInfo.GetStat("Speed").Name} : ";
                _serviceStatsInfo.Stat1Value.text = _characterInfo.GetStat("Speed").Value.ToString();

                _serviceStatsInfo.Stat2.text = $"{_characterInfo.GetStat("Intellegence").Name} : ";
                _serviceStatsInfo.Stat2Value.text = _characterInfo.GetStat("Intellegence").Value.ToString();

                _serviceStatsInfo.Stat3.text = $"{_characterInfo.GetStat("Stamina").Name} : ";
                _serviceStatsInfo.Stat3Value.text = _characterInfo.GetStat("Stamina").Value.ToString();

                _serviceStatsInfo.Stat4.text = $"{_characterInfo.GetStat("Damage").Name} : ";
                _serviceStatsInfo.Stat4Value.text = _characterInfo.GetStat("Damage").Value.ToString();

                _serviceStatsInfo.Stat5.text = $"{_characterInfo.GetStat("Dexterity").Name} : ";
                _serviceStatsInfo.Stat5Value.text = _characterInfo.GetStat("Dexterity").Value.ToString();

                _serviceStatsInfo.Stat6.text = $"{_characterInfo.GetStat("Regeneration").Name} : ";
                _serviceStatsInfo.Stat6Value.text = _characterInfo.GetStat("Regeneration").Value.ToString();
            }
            catch
            {
                InitialStats(characterInfo);
            }
        }

        public void InitialStats(CharactersConfig characterInfo)
        {
            _characterInfo.AddStat(new CharacterStat());

            _characterStat.ChangeValue("Intellegence", characterInfo.Intellegence);
            _characterInfo.AddStat(_characterStat);

            _characterStat.ChangeValue("Stamina", characterInfo.Stamina);
            _characterInfo.AddStat(_characterStat);

            _characterStat.ChangeValue("Damage", characterInfo.Damage);
            _characterInfo.AddStat(_characterStat);

            _characterStat.ChangeValue("Dexterity", characterInfo.Dexterity);
            _characterInfo.AddStat(_characterStat);

            _characterStat.ChangeValue("Regeneration", characterInfo.Regeneration);
            _characterInfo.AddStat(_characterStat);

            test();
        }

        private void test()
        {
            foreach (var stat in _characterInfo._stats)
            {
                Debug.Log(stat.Name);
            }
        }
    }
}
