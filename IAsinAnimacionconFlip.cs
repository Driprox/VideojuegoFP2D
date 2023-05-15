using System.Collections;
using UnityEngine;

public class IAsinAnimacionconFlip : MonoBehaviour
{
    //ATRIBUTOS
    SpriteRenderer imagen;
    public float velocidad = 0.5f;
    public float tiempoVuelta = 2;
    public Transform[] Puntos;
    Vector2 posicionActual;
    float tiempoEspera;
    int i = 0;
    void Awake()//Cargamos los componentes de animacion y la imagen
    {
        imagen = gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        tiempoEspera = tiempoVuelta;//Iguala los tiempos        
    }
    void movimiento()
    {
        //Movera el personaje colocandole como referencia los puntos que se introducen por Unity y los sincroniza con los frames del pc con time
        transform.position = Vector2.MoveTowards(transform.position, Puntos[i].transform.position, velocidad * Time.deltaTime);
        if (Vector2.Distance(transform.position, Puntos[i].transform.position) < 0.1f) //Esto cumplira un minimo pra el desplazamiento
        {
            if (tiempoEspera <= 0)//Esperara hasta que el tiempo sea 0
            {
                if (Puntos[i] != Puntos[Puntos.Length - 1])//Nos dira cuantos puntos hay y les quitara uno
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
                tiempoEspera -= Time.deltaTime;//Sera el fin al tocar un punto
            }
        }
    }
    IEnumerator chekeo()//Chekeara la posicion para rotar el eje x con una rutina y activara las animaciones que hagan falta
    {
        posicionActual = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > posicionActual.x)
        {
            imagen.flipX = true;
        }

        else if (transform.position.x < posicionActual.x)
        {
            imagen.flipX = false;
        }
    }
    void FixedUpdate()//Mejor para el movimiento
    {
        StartCoroutine(chekeo());
        movimiento();
    }
}