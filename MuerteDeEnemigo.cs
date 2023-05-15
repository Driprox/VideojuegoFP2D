using UnityEngine;

public class MuerteDeEnemigo : MonoBehaviour
{
    //Atributo
    Animator animacion;
    AudioSource efecto;
    public float saltoMuerte = 4;

    private void Awake()
    {
        animacion = GetComponent<Animator>();
        efecto = GetComponent<AudioSource>();
    }
    void tiempo() //Se encarga de desactivar el sripte para activar el segundo que indicara la muerte
    {
        GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);//Activa el gameobject hijo en la posicion 0
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))//Basado en frutas
        {            
            //Hay un else if para cada tipo de enemigo que tiene una serie de objectos asignados
            if (gameObject.transform.GetChild(1).gameObject)
            {
                Destroy(gameObject.transform.GetChild(1).gameObject);//Destruira el campo de boxcollider que hace daño al juagdor primero para que no cree problemas
            }
            else if (gameObject.transform.GetChild(1).gameObject && gameObject.transform.GetChild(2).gameObject)
            {
                Destroy(gameObject.transform.GetChild(1).gameObject);
                Destroy(gameObject.transform.GetChild(2).gameObject);
            }
            else if (gameObject.transform.GetChild(2).gameObject && gameObject.transform.GetChild(3).gameObject)
            {
                //Para los enemigos que tiene disparo destruir sus game object
                Destroy(gameObject.transform.GetChild(2).gameObject);
                Destroy(gameObject.transform.GetChild(3).gameObject);
            }
            efecto.Play();//Llamos al efecto
            animacion.Play("Daño");//Activa la animacion del enemigo
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * saltoMuerte);//El jugador podra saltar cuando lo mate     
            Invoke("tiempo", 0.25f);//Invocara el metodo anterior con ese margen de tiempo
            Destroy(gameObject, 0.5f);//Destruira el gameobject al completo
        }
    }
}



