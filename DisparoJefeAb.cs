using UnityEngine;

public class DisparoJefeAb : MonoBehaviour
{
    //Atributos para el editor
    public float distanciaDisparo = 0.5f;
    public float tiempoAtaque = 1.5f;
    public GameObject bala;
    float tiempoActual;
    AudioSource efecto;
    private void Awake()//Cargamos complemento
    {
        efecto = GetComponent<AudioSource>();
    }
    void Start()
    {
        tiempoActual = 0;//Establecera el tiempo de comienzo en 0
    }

    void ataqueJefeA()
    {
        //Se utilizara el metodo RaycastHit2D para establecer un rayo que se usara para marcar al usuario
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaDisparo); //Creamos el metodo por el eje derecho de x
        if (hit.collider != null) //Si el rayo hace contacto con algo pasa lo siguiente
        {
            if (hit.collider.CompareTag("Player"))//Si es el jugador
            {
                if (tiempoActual < 0) //Tiempo optimo para la espera
                {
                    efecto.Play();//Activamos sonido
                    tiempoActual = tiempoAtaque;//Lo iguala para no dispara mas hasta que vuelva a 0
                    Instantiate(bala, transform.position, transform.rotation);//Crea el objeto todas las veces que haga el contacto el rayo
                }
            }
        }
    }
    void Update()
    {
        tiempoActual -= Time.deltaTime; //Iguala el tiempo con el del sistema
        ataqueJefeA();
    }
}