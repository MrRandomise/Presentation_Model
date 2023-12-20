using System.Collections.Generic;
using System;

namespace Lessons.Architecture.PM
{
    public sealed class StatFieldPool
    {
        private List<StatField> _statFieldList = new List<StatField>();

        private ServicePopup _servicePopup;

        private int _lastField = 1;

        public StatFieldPool(ServicePopup servicePopup) 
        {
            _servicePopup = servicePopup;
        }

        public void AddPool(CharacterInfo characterInfo)
        {
            var count = characterInfo.Stats.Count - _statFieldList.Count;
            for(int i = 0; i < count; i++)
            {
                var _statField = UnityEngine.Object.Instantiate(_servicePopup.StatPrefab);
                _statField.transform.SetParent(_servicePopup.StatsContainer.transform);
                _statFieldList.Add(_statField);
                _statField.gameObject.SetActive(false);
            }
        }

        public void RemovePool()
        {
            if(_statFieldList.Count - 1> 0)
            {
                _statFieldList.Remove(_statFieldList[_statFieldList.Count - _lastField]);
            }
            else
            {
                throw new Exception($"No field to remove");
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