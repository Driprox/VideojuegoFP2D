using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuVolumen : MonoBehaviour
{    //Atributos    
    public AudioMixer control;//Componente de musica
    AudioSource efecto;
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }
    public void musica(float volumen)
    {
        control.SetFloat("Volumen", volumen);//Le dara al boton la posibilidad de mandarle valores 
    }
    public void volver()
    {
        efecto.Play();
        SceneManager.LoadScene("Inicio"); //Vovera al menu principal
    }
}
