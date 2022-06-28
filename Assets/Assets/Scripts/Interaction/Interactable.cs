using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public abstract class Interactable : MonoBehaviour
    {
        public enum InteractionType
        {
            Click
        }

        public InteractionType interactionType;

        public abstract void Interact();
    }

