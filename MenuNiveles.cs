using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    //Abrimos los diferentes niveles
    AudioSource efecto;
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }
    public void nivel1()
    {
        efecto.Play();
        SceneManager.LoadScene("Nivel1");
    }
    public void nivel2()
    {
        efecto.Play();
        SceneManager.LoadScene("Nivel2");
    }
    public void nivel3()
    {
        efecto.Play();
        SceneManager.LoadScene("Nivel3");
    }
    public void volver()
    {
        efecto.Play();
        SceneManager.LoadScene("Inicio");
    }
}
