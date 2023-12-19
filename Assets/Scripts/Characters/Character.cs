using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class Character : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CharactersConfig _classCharacter;
        [SerializeField] private Renderer _material;
        private PopupManager _popupManager;


        private PopupManager _popup;

        public void Awake()
        {
            _material.material.color = _classCharacter.CharacterColor;
            _popup = new PopupManager();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popup.ShowPopupCharacter(_classCharacter);
        }
    }
}
