using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DañoAJefe : MonoBehaviour
{
    //Atributos
    public int vidaJefe = 6;
    public float salto = 3;
    public Text ganador;
    public Text inicio;
    public GameObject audioFinal;
    AudioSource efecto;
    Animator animacion;


    private void Awake()//Cargara los componentes
    {
        animacion = GetComponent<Animator>();
        efecto = GetComponent<AudioSource>();
    }
    void Start()//Paramos el tiempo de juego
    {
        Time.timeScale = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))//Cada vez que haga contacto
        {
            efecto.Play();//Activamos sonido
            animacion.Play("Daño");//Activamos animacion
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * salto);//Dara propulsion al usuario
            vidas();//Restara las vidas
        }
    }

    void vidas()
    {//Descontara una vida
        vidaJefe--;
    }
    void efectosAnimacion()
    {
        //Desactivaremos el sprit principal,activaremos el segundario y lo destruiremos todo
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, 0.15f);
    }
    void chekeoVida()
    {
        if (vidaJefe < 4)
        {
            //Activamos la segunda animacion
            animacion.SetBool("Perdida", true);
        }
        if (vidaJefe <= 0)
        //Se encargara de activar todo cuando llegue a cero
        {
            animacion.SetBool("CambioDaño", true);
            Invoke("efectosAnimacion", 0.15f);
            audioFinal.gameObject.SetActive(true);//Activamos el objeto con el audio final
            ganador.gameObject.SetActive(true);//Mensaje final
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))//Ocurre al fianl de la escena
            {
                SceneManager.LoadScene("Creditos");//Buscara y activara la siguiente escena que haya
                Time.timeScale = 1;//Reanuda el tiempo
            }
        }
    }

    void mostrarMensaje()//Mensaje de incio de mapa
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inicio.gameObject.activeSelf == true || Input.GetKeyDown(KeyCode.Space) && inicio.gameObject.activeSelf == true)//Se encargara que el timescale no de problemas
        {
            inicio.gameObject.SetActive(false);//Desactiva el texto
            Time.timeScale = 1;
        }
    }
    private void Update()
    {
        mostrarMensaje();
        chekeoVida();//Comprobara todo el tiempo la vida del gameobject
    }
}
