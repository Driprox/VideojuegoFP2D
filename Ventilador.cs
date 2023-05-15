using UnityEngine;

public class Ventilador : MonoBehaviour
{
    public float salto;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * salto);//Hara flotar al jugador por el numero colocado en el eje y cada vez que haga contacto
        }
    }
}
