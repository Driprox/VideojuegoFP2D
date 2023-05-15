using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{
    //Metodos para el canvas  en el menu de opciones desplegables
    AudioSource efectos;
    private void Awake()
    {
        efectos = GetComponent<AudioSource>();
    }
    public void menuDesplegable()
    {
        efectos.Play();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);//Activa el hijo
        Time.timeScale = 0;//Para el tiempo
    }
    public void menuOpciones()
    {
        SceneManager.LoadScene("Opciones"); //Vovera al menu principal
        Time.timeScale = 1;
    }
    public void volver()
    {
        efectos.Play();
        Time.timeScale = 1;//Inicia el tiempo
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void menuPrincipal()
    {
        efectos.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Inicio"); //Vovera al menu principal

    }
    public void salir()
    {
        efectos.Play();
        Application.Quit();//Saldra del juego cuando este montado en el exe
    }

}
