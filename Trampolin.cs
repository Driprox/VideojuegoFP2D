using UnityEngine;

public class Trampolin : MonoBehaviour

{
    //Atributo
    public float salto;
    AudioSource efecto;
    private void Awake()
    {
        efecto = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            efecto.Play();
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * salto);//Hara saltar al jugador por el numero colocado en el ejey cada vez que haga contacto
            gameObject.GetComponent<Animator>().Play("TrampolinOn");//Llamara a ala animacion del trampolin
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            efecto.Stop();//Lo desactivara cundo salga    
        }
    }
}
