using UnityEngine;


public class IASalto : MonoBehaviour
{
    //ATRIBUTOS
    Animator animacion;
    SpriteRenderer imagen;
    public float velocidad = 0.5f;
    public float tiempoVuelta = 2;
    public Transform[] Puntos;
    public float alturaSalto = 1;
    float saltoInicio;
    Vector2 posicionActual;
    float tiempoEspera;
    int i = 0;
    void Awake()//Cargamos los componentes de animacion y la imagen
    {
        animacion = gameObject.GetComponent<Animator>();
        imagen = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        tiempoEspera = tiempoVuelta;//Iguala los tiempos
        saltoInicio = alturaSalto;
    }
    void movimiento()
    {
        //Movera el personaje colocandole como referencia los puntos que se introducen por Unity y los sincroniza con los frames del pc con time
        transform.position = Vector2.MoveTowards(transform.position, Puntos[i].transform.position, velocidad * Time.deltaTime);
        transform.Translate(Vector2.up * saltoInicio * Time.deltaTime);//Hara que salte

        if (Vector2.Distance(transform.position, Puntos[i].transform.position) < 0.1f) //Esto cumplira un minimo pra el desplazamiento
        {
            if (tiempoEspera <= 0)//Esperara hasta que el tiempo sea 0
            {
                if (Puntos[i] != Puntos[Puntos.Length - 1])//Nos dira cuantos puntos hay y les quitara uno
                {
                    i++;
                    saltoInicio = alturaSalto;//Establecera el salto en el numero que le demos
                    animacion.SetBool("Para", false);
                    if (transform.position.x < 0f)//Se encaragran de girar al personaje el eje x
                    {
                        imagen.flipX = true;
                    }
                    else if (transform.position.x > 0f)
                    {
                        imagen.flipX = false;
                    }
                }
                else //Cuando no haya mas puntos volveremos al punto 0
                {
                    i = 0;
                    saltoInicio = alturaSalto;
                    animacion.SetBool("Para", false);
                    if (transform.position.x < 0f)
                    {
                        imagen.flipX = false;
                    }
                    else if (transform.position.x > 0f)
                    {
                        imagen.flipX = true;
                    }
                }
                tiempoEspera = tiempoVuelta;//Nuestro tiempo vuleve a ser el inicial
            }
            else//Cuando llega al fin del punto
            {
                saltoInicio = 0;//Hara que pare de saltar
                tiempoEspera -= Time.deltaTime;
                animacion.SetBool("Para", true);//Activamos la animacion                
            }
        }
    }
    void FixedUpdate()//Mejor para el movimiento
    {
        movimiento();
    }
}
