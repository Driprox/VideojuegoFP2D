using UnityEngine;

public class PlataformaM : MonoBehaviour
{
    //Atributos
    public float velocidad;
    public Transform[] Puntos;
    public float tiempoVuelta = 2;
    float tiempoEspera;
    int i = 0;
    AudioSource efecto;
    void movimiento()
    {
        //Movera el personaje colocandole como referencia los puntos que se introducen por Unity y los sincroniza con los frames del pc gracias a time
        transform.position = Vector2.MoveTowards(transform.position, Puntos[i].transform.position, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, Puntos[i].transform.position) < 0.1f) //Esto cumplira un minimo para el desplazamiento
        {
            if (tiempoEspera <= 0)//No se movera hasta pasar el tiempo de espera
            {
                if (Puntos[i] != Puntos[Puntos.Length - 1])//Nos dira cuantos puntos hay y le quitaremos uno
                {
                    i++;
                }
                else //Cuando no haya mas puntos volveremos al punto 0
                {
                    i = 0;
                }
                tiempoEspera = tiempoVuelta;//Nuestro tiempo vuleve a ser el inicial
            }
            else
            {
                tiempoEspera -= Time.deltaTime;//Empieza de 0
            }
        }
    }
    //Comprueba y sale del objeto padre paa que no se caiga el personaje
    private void OnCollisionEnter2D(Collision2D collision)
    {
        efecto.Play();//Activa el sonido
        collision.collider.transform.SetParent(transform);//Lo convierte en hijo en cunto lo toca
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        efecto.Stop();//Para el sonido
        collision.collider.transform.SetParent(null);//Desactiva cuando sale
    }
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }

    void Start()
    {
        tiempoEspera = tiempoVuelta;//Iguala los tiempos
    }
    void FixedUpdate()//Mejor para los movimientos
    {
        movimiento();
    }
}
