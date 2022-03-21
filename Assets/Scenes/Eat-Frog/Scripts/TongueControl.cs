﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Eat_frog_Game
{
    public class TongueControl : MonoBehaviour
    {

        public float limit, start;
        private bool activate, move, l;
        public bool limitTounge;
        private SpriteRenderer tongue;
        private LineRenderer lineRenderer;
        private estirolengua _estirolengua;
        private Objective Objective;
        private FrogController frog;
        public Transform _firepoint;

        public float vel_tongue;

        private InsectEaterGameManager _gameManager;

        public InsectEaterGameManager GameManager { get => _gameManager; set => _gameManager = value; }

        void Awake()
        {
            Objective = FindObjectOfType<Objective>();
            frog = FindObjectOfType<FrogController>();
            _estirolengua = FindObjectOfType<estirolengua>();
            tongue = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            vel_tongue = 20f;
            _gameManager.limitreached = false;
            activate = true;
            move = true;
        }

        // Update is called once per frame
        void Update()
        {
            movetounge();
        }

        private void movetounge()
        {
            if (!activate)
            {
                return;
            }
            if (_gameManager.Active)
            {
                if (activate)
                {
                    Vector3 temp = this.transform.position;
                    Vector3 temp2 = this.transform.position;
                    _estirolengua.RenderLine(temp, false, _firepoint);
                    tongue.sortingOrder = 3;
                    if (move)
                    {
                        temp += this.transform.up * Time.deltaTime * 15f;
                    }
                    else
                    {
                        temp -= this.transform.up * Time.deltaTime * 35f;
                    }

                    this.transform.position = temp;

                    if (temp.y >= limit)
                    {
                        move = false;
                        _gameManager.limitreached = true;
                    }

                    if (temp.y < start)
                    {
                        tongue.sortingOrder = 2;
                        activate = false;
                        frog.Tongue = true;
                        _gameManager.limitreached = false;
                        frog.animator.SetBool("Volver", false);
                        //notoco = false;
                        Destroy(gameObject);
                    }

                    _estirolengua.RenderLine(temp, true, _firepoint);
                }
            }
            else
            {

            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Negra" || other.gameObject.tag == "Cafe" || other.gameObject.tag == "Roja"
            || other.gameObject.tag == "Blanca" || other.gameObject.tag == "Mariposa_dorada")
            {
                move = false;
                Debug.Log(other.gameObject.tag);
                Debug.Log(_gameManager.limitreached);
                Objective.se(other.gameObject.tag, _gameManager.limitreached);
            }

        }
    }
}
