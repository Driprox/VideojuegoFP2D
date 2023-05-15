using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    //Se haran todos los contactos de entrada,mantenimietno y salida para mostrar todos los mensajes del tutorial
    public Text npc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npc.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npc.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            npc.gameObject.SetActive(false);
        }
    }
}
