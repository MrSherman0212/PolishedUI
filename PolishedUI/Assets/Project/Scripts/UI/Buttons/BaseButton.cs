using Project.SystemSound;
using UnityEngine.EventSystems;
using UnityEngine;
using Zenject;

namespace Project.UI.Buttons
{
    [RequireComponent(typeof(EventTrigger))]
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] private BtnSoundsConfig _BtnSoundsConfig;
        private SystemSoundsManager _soundsManager;
        private EventTrigger _eventTrigger;
        private EventTrigger.Entry _pointerClickEvent;
        private EventTrigger.Entry _submitEvent;
        private EventTrigger.Entry _pointerEnterEvent;
        private EventTrigger.Entry _selectEvent;
        private EventTrigger.Entry _pointerExitEvent;
        private EventTrigger.Entry _deselectEvent;

        [Inject]
        private void Init(SystemSoundsManager soundsManager)
        {
            _soundsManager = soundsManager;
            _eventTrigger = GetComponent<EventTrigger>();

            _pointerClickEvent = new() { eventID = EventTriggerType.PointerClick };
            _submitEvent = new() { eventID = EventTriggerType.Submit };
            _pointerEnterEvent = new() { eventID = EventTriggerType.PointerEnter };
            _selectEvent = new() { eventID = EventTriggerType.Select };
            _pointerExitEvent = new() { eventID = EventTriggerType.PointerExit };
            _deselectEvent = new() { eventID = EventTriggerType.Deselect };

            _pointerClickEvent.callback.AddListener(OnClick);
            _submitEvent.callback.AddListener(OnClick);
            _pointerEnterEvent.callback.AddListener(OnSelect);
            _selectEvent.callback.AddListener(OnSelect);
            _pointerExitEvent.callback.AddListener(OnDeselect);
            _deselectEvent.callback.AddListener(OnDeselect);

            _eventTrigger.triggers.Add(_pointerClickEvent);
            _eventTrigger.triggers.Add(_submitEvent);
            _eventTrigger.triggers.Add(_pointerEnterEvent);
            _eventTrigger.triggers.Add(_selectEvent);
            _eventTrigger.triggers.Add(_pointerExitEvent);
            _eventTrigger.triggers.Add(_deselectEvent);
        }

        protected virtual void OnClick(BaseEventData eventData) => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SubmitSound);

        protected virtual void OnSelect(BaseEventData eventData) => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SelectSound);

        protected virtual void OnDeselect(BaseEventData eventData) => _soundsManager.PlaySystemSound(_BtnSoundsConfig.SelectSound);
    }
}
