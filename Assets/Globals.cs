using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public static int life = 100;

    public Text Vida;
    public Text Obj;
    public int enemys;
    public static int Enemys;
    public GameObject F;
    public GameObject itorial;
    public string Cena;

    // Start is called before the first frame update
    void Start()
    {
        Enemys = enemys;
        life = 100;
        F.SetActive(false);
        itorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vida.text = "Vida: " + life;

        Obj.text = "Derrote " + Enemys + " Inimigos.";

        if (life <= 0)
        {
            F.SetActive(true);
        }
        if (Enemys <= 0)
        {
            itorial.SetActive(true);
        }
    }

    public void ExitJooj()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(Cena);
    }
}
