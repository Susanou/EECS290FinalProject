using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//this is from the 2DGameKit Code, 
public class TransportEndpoint : MonoBehaviour
{
    public enum DestinationTag
    {
        A, B, C, D, E, F, G,
    }


    public DestinationTag destinationTag;    // This matches the tag chosen on the TransitionPoint that this is the destination for.
    [Tooltip("This is the gameobject that has transitioned.  For example, the player.")]
    public GameObject transitioningGameObject;
}
