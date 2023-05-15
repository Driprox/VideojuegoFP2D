using UnityEngine;

public class FuegoTrampa : MonoBehaviour
{
    Animator animacion;
    private void Awake()
    {
        //Llamamos a la animacion
        animacion = GetComponent<Animator>();
    }
    //Activaremos y desactivaremos segun la condicion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animacion.Play("Fuegoencendido");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animacion.Play("Fuegoencendido");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animacion.Play("Apagado");
        }
    }
}
