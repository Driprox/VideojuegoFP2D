using UnityEngine;

public class ComprobarSueloJugador : MonoBehaviour
{
    public static bool cheack;//Hago static para llamar en otros scripts
    //Comprueba si el cuadrado del collider del personaje hace contacto con las fisicas de lo considerado suelo del grid
    private void OnTriggerEnter2D(Collider2D collision)//En cuanto haga contacto a la primera
    {
        cheack = true;
    }
    private void OnTriggerStay2D(Collider2D collision)//Lo hara mas estable
    {
        cheack = true;
    }
    private void OnTriggerExit2D(Collider2D collision)//Y si sale del contacto devuelve un false
    {
        cheack = false;
    }
}
