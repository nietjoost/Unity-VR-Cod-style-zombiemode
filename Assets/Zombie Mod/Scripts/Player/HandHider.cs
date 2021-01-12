using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    private XRDirectInteractor interactor = null;

    private void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }

    private void OnEnable()
    {
        interactor.onSelectEnter.AddListener(Hide);
        interactor.onSelectExit.AddListener(Show);
    }

    private void OnDisable()
    {
        interactor.onSelectEnter.RemoveListener(Hide);
        interactor.onSelectExit.RemoveListener(Show);
    }

    private void Show(XRBaseInteractable interactable)
    {
        gameObject.SetActive(true);
    }

    private void Hide(XRBaseInteractable interactable)
    {
        gameObject.SetActive(false);
    }
}
