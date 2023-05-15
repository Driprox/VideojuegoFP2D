using UnityEngine;

public class IAsinFlipsinAnimacion : MonoBehaviour
{
    //Atributos que se modificaran en el editor   
    public float velocidad;
    public Transform[] Puntos;
    public float tiempoVuelta = 2;
    float tiempoEspera;
    int i = 0;

    void Start()
    {
        tiempoEspera = tiempoVuelta; //Iguala el tiempo de espera
    }
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
                tiempoEspera -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()//Estbilizara mejor
    {
        movimiento();
    }
}