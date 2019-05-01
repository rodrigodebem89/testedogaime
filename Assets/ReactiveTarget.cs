using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()//método para matar o inimigo
    {
        WanderingAI behavior = GetComponent<WanderingAI>();//checa se o objeto tem o script atrelado a ele
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);//objeto caio no chão

        yield return new WaitForSeconds(1.5f);//passa 1.5s e o objeto desaparece

        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
