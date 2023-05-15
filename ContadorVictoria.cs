using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ContadorVictoria : MonoBehaviour
{
    public Text textoFinNivel;
    public Text contadorCanvas;
    public float tiempo = 60;
    public Text gameOver;
    public Text crono;
    int contadorFijo;
    int totalFrutas;
    AudioSource efecto;
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }
    void Start()
    {
        totalFrutas = transform.childCount; //Contara las frutas al principio
        crono.text = tiempo.ToString();//Sincroniza el tiempo en pantalla
        contadorFijo = totalFrutas;//Asigna el conteo inical a la variable
    }

    //Contara todas los hijos que posse el objeto hasta que quede uno
    public void cambioNivel()
    {
        if (transform.childCount == 0)//Se coloca en el game object principal de las frutas paa que descuente de hay
        {
            textoFinNivel.gameObject.SetActive(true);//Activara el texto del canvas             
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                efecto.Play();
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void cronometro()
    {
        tiempo -= Time.deltaTime; //Va descontando un segundo al tiempo en sincronia con el sistema
        if (totalFrutas < contadorFijo) //Sumara 15 segundos si se consume una fruta
        {
            tiempo = tiempo + 15;//Por cada frutas que comes
            contadorFijo--;//Descuenta el contador
            if (tiempo > 60) //Impedira que el crono supere el 1 m de juego
            {
                tiempo = 60;
            }
        }

        if (tiempo <= 0)//Game Over por tiempo
        {
            gameOver.gameObject.SetActive(true); //Activara y reiniciara el nivel cuando no quede tiempo
            Time.timeScale = 0;//Para el tiempo
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))//Pulsar el boton izquierdo para pasar al reiniciar el nivel o espacio
            {
                Time.timeScale = 1;//Activa el tiempo
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void Update()
    {
        totalFrutas = transform.childCount;//Actualiza la variable de las frutas para el metodo crono
        contadorCanvas.text = totalFrutas.ToString();//Transforma el int en string y al principio del nivel               
        crono.text = tiempo.ToString("f0");//Quita los decimales del crono
        cronometro();//Metodo de crono
        cambioNivel();//Llamamos al metodo final
    }
}
