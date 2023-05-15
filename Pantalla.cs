using UnityEngine;
using UnityEngine.UI;

public class Pantalla : MonoBehaviour
{
    private Dropdown botonDesplegable;
    private void Awake()//Llamos a los componentes que usaaremos
    {
        botonDesplegable = GetComponent<Dropdown>();
        botonDesplegable.onValueChanged.AddListener(delegate { tamaño(); });
    }
    public void completa(bool activa)//Controlara la pantalla completa indiferentemente de que este pulsado lo haremos nosotros
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void tamaño()
    {
        string opciones = botonDesplegable.options[botonDesplegable.value].text;//Buscamos los numeros que tenemos en el boton y los introducimos en los marcadores correspondientes
        string[] partes = opciones.Split('x');//Lo separa por donde digamos
        int ancho = int.Parse(partes[0]);
        int alto = int.Parse(partes[1]);//Los separamos y asignamos                
        Screen.SetResolution(ancho, alto, Screen.fullScreen);//Cambiamos la resolucion                
    }
}
