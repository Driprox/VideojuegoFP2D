using UnityEngine;

public class Caja : MonoBehaviour
{
    //Atributos
    Animator animacion;
    SpriteRenderer imagen;
    public int vidas = 1;
    public int salto = 2;
    AudioSource efecto;
    private void Awake()//Cargamos componentes
    {
        efecto = GetComponent<AudioSource>();
        animacion = GetComponent<Animator>();
        imagen = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            efecto.Play();//Musica
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * salto);//Dara impluso
            animacion.Play("Dañocaja");//Animacion
            vida();//Restara vidas
            Invoke("contador", 0.5f);//Activara la destruccion del game object
        }
    }
    void vida()//Descontamos vidas
    {
        vidas--;
    }
    void contador()
    {
        if (vidas <= 0)//Cuando el contador de vidas llege a 0
        {
            imagen.enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;//Desactivamos el boxcollider para que no de problemas
            gameObject.transform.GetChild(1).gameObject.SetActive(false);//Desactivamos el segundo de masa
            gameObject.transform.GetChild(0).gameObject.SetActive(true);//Activamos las piezas de destruccion de la caja
            Destroy(gameObject, 0.8f);//Destruimos el objeto
        }
    }
}
