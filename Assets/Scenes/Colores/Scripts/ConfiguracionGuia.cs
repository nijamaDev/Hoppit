﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Colores;

namespace Colores
{
    public class ConfiguracionGuia : MonoBehaviour
    {
        public static ConfiguracionGuia instance;

        public int contador = 0;
        public AccionBoton accionBoton;
        public MostrandoPuntaje mostrandoPuntaje;
        public ModeSystemGameManager gameManager;
        public ColoresGameManager coloresGameManager;
        public Señales señales;
        public List<string> colores;
        public AudioManager manager;
        private int color, auxiliar,correcto;

        void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {
            accionBoton = FindObjectOfType<AccionBoton>();
            gameManager = FindObjectOfType<ModeSystemGameManager>();
            coloresGameManager = FindObjectOfType<ColoresGameManager>();
            señales = FindObjectOfType<Señales>();
            mostrandoPuntaje = FindObjectOfType<MostrandoPuntaje>();
        }

        public void VerificarBoton(int color)
        {
            for (int i=0; i<4;i++)
            {
                if (gameObject.GetComponentInChildren<TextMesh>().text == colores[i])
                    auxiliar = i + 1;
            }

            if (accionBoton.colorFijo == auxiliar)
            {
                gameManager.Score += contador;
                coloresGameManager.correctos += contador;
                coloresGameManager.correctosSeguidos += 1;
                mostrandoPuntaje.puntajeObtenido = contador;
                Destroy(gameObject);
                coloresGameManager.fallas = 0;
                señales.senal = 1;
            }
            else if((accionBoton.colorFijo != auxiliar) && (accionBoton.colorFijo!=5))
            {
                señales.senal = 2;
                coloresGameManager.correctosSeguidos = 0;
                Destroy(gameObject);
                coloresGameManager.fallas++;
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.up * -coloresGameManager.velocidad * Time.deltaTime;
            color = accionBoton.colorFijo;

            if (contador != 0)
                VerificarBoton(color);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Finish"){
                contador++;
            }


            if (collision.gameObject.tag == "Respawn")
            {
                Destroy(gameObject);
                coloresGameManager.fallas++;
                coloresGameManager.correctosSeguidos = 0;
                
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Finish")
                contador--;
        }

    }
}