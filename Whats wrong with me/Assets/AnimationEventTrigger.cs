using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTrigger : MonoBehaviour
{
    public Animator dogoController;

    public void DogWalk()
    {
        dogoController.SetBool("DogRun", true);
    }
}
