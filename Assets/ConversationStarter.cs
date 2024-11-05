using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation MyConversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ConversationManager.Instance.StartConversation(MyConversation);

                Cursor.visible = true; // Unlocks Cursor
                Cursor.lockState = CursorLockMode.None;

            }
        } 
     }
}
