using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public class ServicePopup
    {
        public GameObject Popup;

        public Button CloseButton;

        public TMP_Text CharacterName;

        public TMP_Text CharacterDescription;

        public TMP_Text CharactterCurrLevel;

        public Image CharacterIcon;

        public Image CurrentProgressBar;

        public Button LevelUpButton;

        public Button AddExperience;

        public TMP_Text CurrExp;

        public TMP_Text NeedExp;

        public Sprite ActiveLevelButton;

        public Sprite DeactiveLevelButton;
    }
}