using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ColumnScript : MonoBehaviour
{
    GameObject floater;
    XRBaseInteractable interactable;

    //void awake
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponentInParent<XRBaseInteractable>();
        if (interactable != null)
        {
            interactable.activated.AddListener(XRBaseInteractable);
        }
    }
}
