using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class herbierMapUpgrade : MonoBehaviour
{

    public Sprite pageNiv2;
    public Sprite pageNiv3;
    private Image pageActuel;

    // Start is called before the first frame update
    void Start()
    {
        pageActuel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.s_Singleton.niveauHerbier == 1)
        {
            pageActuel.sprite = pageNiv2;
        }
        else if (GameManager.s_Singleton.niveauHerbier == 2)
        {
            pageActuel.sprite = pageNiv3;
        }
    }
}
