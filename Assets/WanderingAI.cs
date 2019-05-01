using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;//variável para determinar em qual distância o inimigo deve reagir quando detectar um objeto
    private bool _alive;//variável para verificar se o inimigo está vivo ou morto
    // Start is called before the first frame update
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive == true)//o inimigo só se movimenta se estiver vivo
        {
            transform.Translate(0, 0, speed * Time.deltaTime);//controla a velocidade e movimentação do inimigo

        }



        Ray ray = new Ray(transform.position, transform.forward);//ray na mesma posição do inimigo que aponta para a mesma direção dele
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {//coloca um ray com circuferência em volta do inimigo
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())//método para detecar o jogador na cena
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;//método para criar a bola de fogo
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);//método para colocar a bola de fogo na frente do inimigo e apontar na mesma direçãod dele
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            if (hit.distance < obstacleRange)//se a distância for menor que o obstáculo, o inimigo continua em frente em uma nova direção randômica
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive)//set do método
    {
        _alive = alive;
    }
}
