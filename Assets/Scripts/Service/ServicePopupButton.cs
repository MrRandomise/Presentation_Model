using System;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class ServicePopupButton
    {
        public Button CloseButton;

        public Button LevelUpButton;

        public Button AddExperience;

        public Button AddStats;

        public Button ChangeStats;

        public Button RemoveStats;
    }
}
