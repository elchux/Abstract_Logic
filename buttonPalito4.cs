using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class buttonPalito4 : MonoBehaviour
{  public int palitoRemove, xArray = 0, yArray = 0, filasTemp = 1, columnasTemp = 1, iterator = 0;
    public bool isGone, prueba=false;
    public Animator vanish;
    playController4 playController_script4;
    mediaPlayer mediaPlayer_scriptButton;
    
    public void PalitoOut()//           validacion!
    {
        //TOCO PALITO
        if (Input.touchCount == 1 || Input.GetMouseButton(0) == true)

                    // (IF AISLADO PARA INICIAR:
        {           //  PALITO/FILA    NO JUGADO          &&                          PUEDO INICIAR JUGAR PALITO                                                                (SOLO FILAS)
            if   ((playController_script4.palitojugado == -1)&&(playController_script4.newPalitoAvailable == true&&playController_script4.turnoBegin==false))
            { // ==>                   INICIA TURNO                                                       (SIGO JUGANDO)                                                          DEFINO PALITO/FILA A JUGAR   
                            playController_script4.turnoBegin = true; playController_script4.palitoStill = true; playController_script4.palitojugado = (int.Parse(this.gameObject.transform.name)) / 1000; 
             }//                      SIGO JUGANDO??(PALITO STILL)                                                               PALITO CORRECTO?
            if ((playController_script4.palitoStill == true && ((int.Parse(this.gameObject.transform.name))/1000==playController_script4.palitojugado)))
            {
                PalitoOutProcess();
            }
        }
}
    public void PalitoOutProcess()  //palito a la verga
    {
        mediaPlayer_scriptButton.MyAudioS2(21);
        palitoRemove = int.Parse(this.gameObject.transform.name);
        columnasTemp = palitoRemove % 10;
        palitoRemove /= 10;
        filasTemp = palitoRemove % 10;
        palitoRemove /= 10;
        yArray = palitoRemove % 10;
        xArray = palitoRemove / 10;
        playController_script4.RefreshArrayV2V3(xArray, yArray,filasTemp,columnasTemp);
        vanish.SetBool("palitoGone", true);
        //  vanish.gameObject.GetComponent<Animator>().SetBool("palitoGone", false);
        Invoke(nameof(VanishBoolReset), 0.1f);
        this.gameObject.SetActive(false);
    }

    public void VanishBoolReset() {
        vanish.SetBool("palitoGone", false);
    }


    //StartCoroutine(AnimationGone());

    /*public IEnumerator AnimationGone() 
    {
        isGone = true;
        this.gameObject.GetComponent<Animator>().SetBool("palitoGone", true) ;
        yield return new WaitForSeconds(1.1f    );
    }
    
         
        this.gameObject.GetComponent<Animator>().SetBool("palitoGone", true);
        Time.timeScale = 0.25f;
        Invoke(nameof(PalitoGone), 0.5f);

         
         
         */
    void Start()
    {
        playController_script4 = FindObjectOfType<playController4>();
        mediaPlayer_scriptButton = FindObjectOfType<mediaPlayer>();
    }
    void Update()
    {

    }
}
