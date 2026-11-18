using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ColumnScript : MonoBehaviour
{
    [SerializeField] GameObject floater;
    XRGrabInteractable floaterInteractable;
    List<XRGrabInteractable> objOn = new List<XRGrabInteractable>;

    private void Awake()
    {
        floaterInteractable = floater.GetComponent<XRGrabInteractable>();
        floaterInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    void Update()
    {
        if ()
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        objOn.Add(other.GetComponentInParent<XRGrabInteractable>());
        if (objOn.Last() != null)
        {
            objOn.Last().selectExited.AddListener(OnSelectExited);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        XRGrabInteractable leaver = objOn[objOn.IndexOf(other.GetComponentInParent<XRGrabInteractable>())];
        if (leaver != null)
        {
            leaver.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        floater = null;
        floaterInteractable.selectEntered.RemoveListener(OnSelectEntered);
        floaterInteractable = null; 
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        floater = args.interactableObject.colliders.First().gameObject;
    }
}