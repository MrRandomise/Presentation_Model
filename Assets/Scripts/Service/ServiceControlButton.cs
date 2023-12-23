using System;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class ServiceControlButton
    {
        public AddExperience AddExpControl;
        
        public AddStat AddStatControl;
        
        public ChangeStat ChangeStatControl;

        public RemoveStat RemoveStatControl;
    }
}
