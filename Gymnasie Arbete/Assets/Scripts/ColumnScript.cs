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
    List<XRGrabInteractable> objOn = new List<XRGrabInteractable>();
    [SerializeField] Vector3 floatPos;
    Rigidbody floatRB;

    private void Awake()
    {
        floaterInteractable = floater.GetComponent<XRGrabInteractable>();
        floaterInteractable.selectEntered.AddListener(OnSelectEntered);
        floatPos = transform.position;
        floatPos += new Vector3(0, 1f);
        floatRB = floater.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(floater != null)
        {
            floater.transform.Rotate(new Vector3(0, 1));
            floatRB.linearVelocity = Vector3.zero;

            floater.transform.position = floatPos;
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
        XRGrabInteractable leaver = other.GetComponentInParent<XRGrabInteractable>();
        objOn.Remove(leaver);
        if (leaver != null)
        {
            leaver.selectExited.RemoveListener(OnSelectExited);
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
        if (floater = null)
        {
            floater = args.interactableObject.colliders.First().gameObject;
            floaterInteractable = floater.GetComponent<XRGrabInteractable>();
            floaterInteractable.selectEntered.AddListener(OnSelectEntered);
            floatRB = floater.GetComponent<Rigidbody>();
        }   
    }
}