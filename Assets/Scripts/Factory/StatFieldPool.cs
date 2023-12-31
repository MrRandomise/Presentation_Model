using System.Collections.Generic;

namespace Lessons.Architecture.PM
{
    public sealed class StatFieldPool
    {
        private List<StatField> _statFieldList = new List<StatField>();

        private ServicePopup _servicePopup;


        public StatFieldPool(ServicePopup servicePopup) 
        {
            _servicePopup = servicePopup;
        }

        public void AddPool(CharacterInfo characterInfo)
        {
            var count = characterInfo.Stats.Count - _statFieldList.Count;
            for(int i = 0; i < count; i++)
            {
                var _statField = UnityEngine.Object.Instantiate(_servicePopup.Stats.StatPrefab);
                _statField.transform.SetParent(_servicePopup.Stats.StatsContainer.transform);
                _statFieldList.Add(_statField);
                _statField.gameObject.SetActive(false);
            }
        }

        public StatField GetStatFieldList(int index)
        {
            return _statFieldList[index];
        }

        public int GetCountFieldList()
        {
            return _statFieldList.Count;
        }
    }
}