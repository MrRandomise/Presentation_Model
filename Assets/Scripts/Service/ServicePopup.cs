using System;
using UnityEngine;
using UnityEngine.UI;
namespace Lessons.Architecture.PM
{
    [Serializable]
    public class ServicePopup
    {
        public GameObject Popup;

        public Button CloseButton;

        public Title Title;

        public Info Info;

        public ProgressBar ProgressBar;

        public Stats Stats;

        public LevelUp LevelUp;
    }
}