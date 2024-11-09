using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Interactable _currentInteractable = null;

    private GameObject _interactPopupBase;

    private GameObject _interactRendering = null;
    private Vector3 _interactOffset = Vector2.zero;
    private SpriteRenderer _popupSpriteRenderer;

    void Start()
    {
        _interactPopupBase = (GameObject)Resources.Load("Prefabs/InteractPopUp", typeof(GameObject));
        Debug.Log(_interactPopupBase);
        _popupSpriteRenderer = _interactPopupBase.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        Interactable closest = null;
        float closestDistance = float.MaxValue;
        foreach (Collider2D collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null && interactable.enabled)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = interactable;
                    _interactOffset = new Vector3(0, (collider.bounds.size.y / 2.0f) + (_popupSpriteRenderer.bounds.size.y), 0);
                }
            }
        }

        if (closest != _currentInteractable && _interactRendering != null)
        {
            Destroy(_interactRendering);
            _interactRendering = null;
        }
        _currentInteractable = closest;
        if (closest != null)
        {
            if (_interactRendering == null)
            {
                _interactRendering = Instantiate(_interactPopupBase, closest.transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                closest.onInteract.Invoke();
            }
        }
        if (_currentInteractable != null && _interactRendering != null)
        {
            _interactRendering.transform.position = _currentInteractable.transform.position + _interactOffset;
        }
    }

    void OnDisable()
    {
        if (_interactRendering != null)
        {
            Destroy(_interactRendering);
            _interactRendering = null;
        }
    }
}
