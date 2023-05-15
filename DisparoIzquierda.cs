using UnityEngine;

public class DisparoIzquierda : MonoBehaviour
{
    //Atributos para el editor
    public Animator animacion;
    public float distanciaDisparo = 0.5f;
    public float tiempoAtaque = 1.5f;
    public GameObject bala;
    float tiempoActual;
    AudioSource efecto;
    private void Awake()//Cargar el componenete
    {
        efecto = GetComponent<AudioSource>();
    }
    void Start()
    {
        tiempoActual = 0;//Establecera el tiempo de comienzo en 0
    }
    void disparo()
    {
        //Se utilizara el metodo RaycastHit2D para establecer un rayo que se usara para marcar al usuario
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, distanciaDisparo); //Creamos el metodo raycasht pra el eje x por la izquierda
        if (hit.collider != null) //Si el rayo hace contacto con algo pasa lo siguiente
        {
            if (hit.collider.CompareTag("Player"))//Si da al jugador
            {

                if (tiempoActual < 0) //Tiempo optimo para la espera
                {
                    efecto.Play();
                    animacion.Play("Disparo");//Activa la animacion
                    tiempoActual = tiempoAtaque;//Lo iguala para no dispara mas hasta que vuelva a 0
                    Instantiate(bala, transform.position, transform.rotation);//Crea el objeto todas las veces que haga el contacto
                }
            }
        }
    }
    void Update()
    {
        tiempoActual -= Time.deltaTime; //Iguala el tiempo con el del sistema
        disparo();
    }
}