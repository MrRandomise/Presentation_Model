namespace Lessons.Architecture.PM
{
    public sealed class CharacterManager
    {
        private CharacterManagerInfo _characterManagerInfo;
        private CharacterManagerStats _characterStatsManager;
        private CharacterManagerLevel _characterLevelManager;
        private CharactersConfig _characterConfig;
        private StatFieldPool _statsFieldPool;

        public CharacterManager(CharacterManagerInfo userInfo, CharacterManagerStats characterStatsManager, CharacterManagerLevel characterLevelManager, StatFieldPool statsFieldPool)
        {
            _characterManagerInfo = userInfo;
            _characterStatsManager = characterStatsManager;
            _characterLevelManager = characterLevelManager;
            _statsFieldPool = statsFieldPool;
        }

        public void CharacterInfoInitialize(CharactersConfig characterInfo)
        {
            _characterConfig = characterInfo;
            _characterManagerInfo.InitializeCharacterInfo(characterInfo.name, characterInfo.Description, characterInfo.Icon);
            _characterStatsManager.InitializeCharacterStats(_characterConfig);
        }

        public CharacterManagerInfo GetManagerInfo() 
        { 
            return _characterManagerInfo;
        }

        public CharacterManagerStats GetManagerStats()
        {
            return _characterStatsManager;
        }

        public CharacterManagerLevel GetManagerLevel()
        {
            return _characterLevelManager;
        }

        public CharactersConfig GetCharacterConfig()
        {
            return _characterConfig;
        }

        public StatFieldPool GetStatsFieldPool()
        {
            return _statsFieldPool;
        }
    }
}
