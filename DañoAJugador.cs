using UnityEngine;
using UnityEngine.SceneManagement;

public class DañoAJugador : MonoBehaviour
{
    //Sirve para declara si un enemigo hace contacto con el persoanaje y reinicia la partida    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
            collision.gameObject.GetComponent<Animator>().Play("Daño");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Cargamos la misma escena
        }
    }
}
