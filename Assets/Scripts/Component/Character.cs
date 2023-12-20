using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class Character : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CharactersConfig _classCharacter;

        [SerializeField] private Renderer _material;

        private CharacterManager _characterManager;

        private PopupManager _popupManager;

        public void Awake()
        {
            _material.material.color = _classCharacter.CharacterColor;
        }

        [Inject]
        private void Construct(CharacterManager characterManager, PopupManager popupManager)
        {
            _characterManager = characterManager;
            _characterManager.CharacterInfoInitialize(_classCharacter);
            _popupManager = popupManager;
            _popupManager.PopupInitialize(_characterManager);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popupManager.ShowPopupCharacter();
        }
    }
}
