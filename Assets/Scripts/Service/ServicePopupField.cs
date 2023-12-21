using System;
using TMPro;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    [Serializable]
    public sealed class ServicePopupField
    {
        public InputField AddExpField;
        public InputField AddStatField;
        public InputField AddStatValueField;
        public InputField ChangeStatField;
        public InputField ChangeStatFieldValue;
        public InputField RemoveStatField;
    }
}
