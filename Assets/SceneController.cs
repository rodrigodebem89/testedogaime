﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy == null)//se não houver inimigos na cena, eles são criados
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;//método para spawnar o inimigo
            _enemy.transform.position = new Vector3(0, 1, 0);

            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

        }
    }
}
