using UnityEngine;

public class HouseLockpickHidder : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockPick;

    [SerializeField]
    private GameObject _houseEnter;

    [SerializeField]
    private SoundManager _soundManager;

    private Player _player;
    private PlayerInteractor _playerInteractor;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _playerInteractor = FindObjectOfType<PlayerInteractor>();
        Interactable interactable = GetComponent<Interactable>();
        interactable.onInteract.AddListener(() =>
        {
            _lockPick.SetActive(true);
            _player.enabled = false;
            _playerInteractor.enabled = false;
        });
        if (GameState.ApHouseUnlocked)
        {
            gameObject.SetActive(false);
            return;
        }
    }

    void Update()
    {
        if (Pin.pinCounter == 5)
        {
            _lockPick.SetActive(false);
            gameObject.SetActive(false);
            _houseEnter.SetActive(true);
            _player.enabled = true;
            _playerInteractor.enabled = true;
            GameState.ApHouseUnlocked = true;
            _soundManager.PlayOneTimeSFX(_soundManager._lockOpened);
            Pin.pinCounter = 0;
        }
    }
}
