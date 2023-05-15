using UnityEngine;

public class Frutas : MonoBehaviour
{
    AudioSource efecto;
    private void Awake()//Carga el complemento
    {
        efecto = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //Los collider estan en trigger
    {
        if (collision.CompareTag("Player"))
        {
            efecto.Play();//Activa sonido
            GetComponent<SpriteRenderer>().enabled = false;//Hara contacto con el tag  player y lo desactivara el sprite
            gameObject.transform.GetChild(0).gameObject.SetActive(true);//Activara el aset del recoger en la posicion 0
            FindObjectOfType<ContadorVictoria>().cambioNivel();//Lo uso para enlazarlo con el contador que esta el objeto frutas que lo enviara antes de ser destruido            
            Destroy(gameObject, 0.5f);//Destruira la mazana y el hijo juntos con un intervalo de 5 milisegundos
        }
    }
}
