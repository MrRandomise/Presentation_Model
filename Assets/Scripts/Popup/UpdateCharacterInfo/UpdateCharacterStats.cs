namespace Lessons.Architecture.PM
{
    public sealed class UpdateCharacterStats
    {
        private CharacterManagerStats _characterManagerStats;
        private StatFieldPool _statFieldPool;

        public UpdateCharacterStats(CharacterManagerStats characterManagerStats, StatFieldPool statFieldPool)
        {
            _characterManagerStats = characterManagerStats;
            _statFieldPool = statFieldPool;
        }

        public void ShowStats()
        {
            var _statlist = _characterManagerStats.GetCharacterStats();
            for(int i = 0; i < _statlist.Stats.Count; i++)
            {
                var _field = _statFieldPool.GetStatFieldList(i);
                _field.gameObject.SetActive(true);
                _field.SetFieldStat(_statlist.GetStats()[i]);
            }
        }
    }
}
