using UnityEngine;
using UnityEngine.SceneManagement;

public class JugarSalir : MonoBehaviour

{
    AudioSource efecto;
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }
    //Metodos para el menu principal y de opciones
    public void Jugar()
    {
        efecto.Play();
        SceneManager.LoadScene("Tutorial"); //Pasara al tutorial
    }
    public void Opciones()
    {
        efecto.Play();
        SceneManager.LoadScene("Opciones"); //Abrira opciones
    }
    public void Salir()
    {
        efecto.Play();
        Application.Quit();//Saldra del juego  el .exe
    }
    public void niveles()
    {
        efecto.Play();
        SceneManager.LoadScene("Niveles");//Pantalla de los niveles
    }
}
