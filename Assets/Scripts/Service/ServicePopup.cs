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

        public TMP_Text CharacterName;

        public TMP_Text CharacterDescription;

        public TMP_Text CharactterCurrLevel;

        public Image CharacterIcon;

        public Image CurrentProgressBar;

        public TMP_Text CurrExp;

        public TMP_Text NeedExp;

        public Sprite ActiveLevelButton;

        public Sprite DeactiveLevelButton;

        public GameObject StatsContainer;

        public StatField StatPrefab;
    }
}