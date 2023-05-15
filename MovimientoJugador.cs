using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    //Atributos para los movimientos
    public float velocidad = 0;
    public float salto = 4;
    public float saltoPulsacionProlongada = 0.5f;
    public float saltoPulsacionCorta = 1;
    public float alturaDobleSalto = 2.5f;
    bool comprobacionSuelo;
    Rigidbody2D jugador;
    void Awake()//Cargara el componente
    {
        jugador = GetComponent<Rigidbody2D>();//Seleciono el componente rigi y lo meto en la variable
    }
    void movimiento()
    {
        //Mueve a la izquierda
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Animator>().SetBool("Correr", true);///Lo uso para activar la animacion de correr
        }
        //Mueve a la derecha 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Animator>().SetBool("Correr", true);
        }
        //No mueve al personaje si no se hace nada
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Correr", false);//Se usa para deciler que vuelva a la animacion de parado
        }
    }//Mueve al personaje con a y d

    void saltar()//Permite saltar,doble salto haciendo uso del eje y y la comprobacion del suelo, y la caida reducida o ampliada por la pulsacion de space
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (ComprobarSueloJugador.cheack)//Chekeamos que  estamos en el suelo  y activamos salto
            {

                jugador.velocity = new Vector2(jugador.velocity.x, salto);
                comprobacionSuelo = true;
            }
            else
            {
                //animaciones
                gameObject.GetComponent<Animator>().SetBool("Correr", false);
                gameObject.GetComponent<Animator>().SetBool("Saltar", true);

                if (Input.GetKeyDown(KeyCode.Space))//Pulsamos solo una ves el boton
                {
                    if (comprobacionSuelo == true)
                    {
                        gameObject.GetComponent<Animator>().SetBool("Doble", true);
                        jugador.velocity = new Vector2(jugador.velocity.x, alturaDobleSalto);//Doble salto
                        comprobacionSuelo = false;
                    }
                }
            }
        }
        if (ComprobarSueloJugador.cheack)//Si no pulsamos nada desactivamos pulsaciones
        {
            gameObject.GetComponent<Animator>().SetBool("Saltar", false);
            gameObject.GetComponent<Animator>().SetBool("Doble", false);//DSesactivo la animacion salto
        }

        //Estos if dos haran que si se pulsa flojo el space salte mas o menos
        if (jugador.velocity.y < 0)
        {
            jugador.velocity += Vector2.up * Physics2D.gravity.y * (saltoPulsacionProlongada) * Time.deltaTime;
        }
        else if (jugador.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            jugador.velocity += Vector2.up * Physics2D.gravity.y * (saltoPulsacionCorta) * Time.deltaTime;
        }
    }
    void Update()//Mejor para elsato y que lo compruebe todo el tiempo
    {
        saltar();
    }
    void FixedUpdate()//Para que sea mas estable
    {
        movimiento();
    }
}
