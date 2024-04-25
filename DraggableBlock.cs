using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DraggableBlock : XRGrabInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        SetGripOrientation(args.interactorObject);
    }

    private void SetGripOrientation(IXRSelectInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            matchAttachmentPoints = true;
            attachTransform.position = interactor.attachTransform.position;
            attachTransform.rotation = interactor.attachTransform.rotation;
        }
        else
        {
            matchAttachmentPoints = false;
        }
    }
}

