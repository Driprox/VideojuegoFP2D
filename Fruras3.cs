using UnityEngine;

public class Fruras3 : MonoBehaviour
{
    AudioSource efecto;
    private void Awake()//Carga complemento
    {
        efecto = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //Cuando contacto en triger
    {
        if (collision.CompareTag("Player"))
        {
            efecto.Play();//Activa sonido
            GetComponent<SpriteRenderer>().enabled = false;//Hara contacto con el tag  player y lo desactivara el sprite
            gameObject.transform.GetChild(0).gameObject.SetActive(true);//Activara el aset del recoger en la posicion 0                                                                        
            FindObjectOfType<ContadorNivel3>().cambioNivel();
            Destroy(gameObject, 0.5f);//Destruira la mazana y el hijo juntos con un intervalo de 5 milisegundos
        }
    }
}
