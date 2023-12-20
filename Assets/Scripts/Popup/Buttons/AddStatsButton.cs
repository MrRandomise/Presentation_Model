using System.Collections.Generic; 

namespace Lessons.Architecture.PM
{
    public sealed class AddStatsButton
    {
        private ServicePopupButton _servicePopupButton;

        private List<CharacterStat> _characterStatList = new List<CharacterStat>();

        private StatFieldPool _fieldPool;

        private CharacterInfo _characterInfo;

        private UpdateCharacterStats _updateCharacterStats;
        public AddStatsButton(ServicePopupButton servicePopupButton, StatFieldPool fieldPool)
        {
            _servicePopupButton = servicePopupButton;
            _fieldPool = fieldPool;
        }

        public void InitializeButtons(List<CharacterStat> list, CharacterInfo characterInfo, UpdateCharacterStats updateCharacterStats)
        {
            _servicePopupButton.AddStats.onClick.AddListener(OnAddStats);
            _updateCharacterStats = updateCharacterStats;
            _characterStatList = list;
            _characterInfo = characterInfo;
        }

        public void OnAddStats()
        {
            foreach (CharacterStat characterStat in _characterStatList)
            {
                _characterInfo.AddStat(characterStat);
            }
            _fieldPool.AddPool(_characterInfo);
            _updateCharacterStats.ShowStats();
        }
    }
}