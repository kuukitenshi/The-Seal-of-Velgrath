using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{

    [SerializeField]
    private GameObject _questPanel;

    [SerializeField]
    private GameObject _moveKeys;

    [SerializeField]
    private GameObject _spaceKey;

    [SerializeField]
    private GameObject _restartKey;

    [SerializeField]
    private GameObject _lockPickInstructions;

    private Player _player;
    private Cursor _cursor = null;

    void Start()
    {
        _player = FindObjectOfType<Player>();
        _restartKey.SetActive(SceneManager.GetActiveScene().name == "Wc_Vision");
        Cursor[] cursors = Resources.FindObjectsOfTypeAll<Cursor>();
        if (cursors != null && cursors.Length > 0)
        {
            _cursor = cursors[0];
        }
    }

    void Update()
    {
        _questPanel.SetActive(GameState.CurrentQuest != null);
        bool moveEnabled = _player.controlZone.gameObject.activeSelf;
        if (_cursor != null && !moveEnabled)
        {
            moveEnabled = _cursor.gameObject.activeInHierarchy;
        }
        _moveKeys.SetActive(moveEnabled);
        _spaceKey.SetActive(_player.controlZone.gameObject.activeSelf);
        _lockPickInstructions.SetActive(_cursor != null && _cursor.gameObject.activeInHierarchy);
    }
}
