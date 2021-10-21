using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatriceScript : MonoBehaviour
{


    public Text resulta ;
    public Text calcul ;

    public int calcule1;
    public int calcule2;
    public int solution;

    public float calculeFloat1;
    public float calculeFloat2;
    public float solutionFloat;

    public char index;
    public bool indexFloat;

    public Button virgule;
    public Button moins;
    public Button plus;
    public Button divise;
    public Button multiplie;

    private void Start()
    {
        resulta.text = "0";
        calcul.text = "0";
    }

    public void BoutonAC()
    {
        resulta.text = "0";
        calcul.text = "0";
    }

    public void Bouton0()
    {

        resulta.text = (resulta.text + "0");
        calcul.text = (calcul.text + "0");

    }

    public void Bouton1()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "1");
            calcul.text = (calcul.text + "1");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', '1');
            calcul.text = calcul.text.Replace('0', '1');
            resulta.text = (resulta.text + "1");
            calcul.text = (calcul.text + "1");
        }   

    }

    public void Bouton2()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "2");
            calcul.text = (calcul.text + "2");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "2");
            calcul.text = (calcul.text + "2");
        }

    }

    public void Bouton3()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "3");
            calcul.text = (calcul.text + "3");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "3");
            calcul.text = (calcul.text + "3");
        }

    }

    public void Bouton4()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "4");
            calcul.text = (calcul.text + "4");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "4");
            calcul.text = (calcul.text + "4"); ;
        }   

    }

    public void Bouton5()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "5");
            calcul.text = (calcul.text + "5");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "5");
            calcul.text = (calcul.text + "5");
        }  

    }

    public void Bouton6()
    {
        if (indexFloat)
        {
            resulta.text = (resulta.text + "6");
            calcul.text = (calcul.text + "6");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "6");
            calcul.text = (calcul.text + "6");
        }
    }

    public void Bouton7()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "7");
            calcul.text = (calcul.text + "7");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "7");
            calcul.text = (calcul.text + "7");
        }
    }

    public void Bouton8()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "8");
            calcul.text = (calcul.text + "8");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "8");
            calcul.text = (calcul.text + "8"); ;
        }
    }

    public void Bouton9()
    {

        if (indexFloat)
        {
            resulta.text = (resulta.text + "9");
            calcul.text = (calcul.text + "9");
        }
        else
        {
            resulta.text = resulta.text.Replace('0', ' ');
            calcul.text = calcul.text.Replace('0', ' ');
            resulta.text = (resulta.text + "9");
            calcul.text = (calcul.text + "9");
        }
    }

    public void BoutonPourCent()
    {
        calculeFloat2 = float.Parse(resulta.text);

        solutionFloat = calculeFloat2 / 100;
        resulta.text = solutionFloat.ToString();
        calcul.text = resulta.text;

    }

    public void BoutonDivisé()
    {

        divise.interactable = false;
        multiplie.interactable = false;
        moins.interactable = false;
        plus.interactable = false;

        index = '/';
        resulta.text = "";
        int.TryParse(calcul.text, out calcule1);
        virgule.interactable = true;

        if (!resulta.text.Equals("/"))
        {
            calcul.text = (calcul.text + " / ");
        }
    }

    public void BoutonMultiplier()
    {
        divise.interactable = false;
        multiplie.interactable = false;
        moins.interactable = false;
        plus.interactable = false;

        index = 'X';
        resulta.text = "";
        int.TryParse(calcul.text, out calcule1);
        virgule.interactable = true;
        multiplie.interactable = false;

        if (!resulta.text.Equals("X"))
        {
            calcul.text = (calcul.text + " X ");
        }
    }

    public void BoutonMoins()
    {
        divise.interactable = false;
        multiplie.interactable = false;
        moins.interactable = false;
        plus.interactable = false;

        index = '-';
        resulta.text = "";
        int.TryParse(calcul.text, out calcule1);
        virgule.interactable = true;

        if (!resulta.text.Equals("-"))
        {
            calcul.text = (calcul.text + " - ");
        }
        
     
    }

    public void BoutonPlus()
    {
        divise.interactable = false;
        multiplie.interactable = false;
        moins.interactable = false;
        plus.interactable = false;

        if (indexFloat)
        {
            calculeFloat1 = float.Parse(calcul.text);
        }

        index = '+';
        resulta.text = "";
        int.TryParse(calcul.text, out calcule1);
        virgule.interactable = true;
        plus.interactable = false;

        if (!resulta.text.Equals("+"))
        {
            calcul.text = (calcul.text + " + ");
        }
    }


    public void BoutonPoint()
    {
        indexFloat = true; 
 

        if (!resulta.text.Equals(",") && !calcul.text.Equals(","))
        {
            resulta.text = (resulta.text + ",");
            calcul.text = (calcul.text + ",");
            virgule.interactable = false;
        }
    }

    public void BoutonEgale()
    {
        virgule.interactable = true;
        multiplie.interactable = true;
        plus.interactable = true;
        moins.interactable = true;
        divise.interactable = true;

        calculeFloat2 = float.Parse(resulta.text);

        int.TryParse(resulta.text, out calcule2);

        Calcule();
        
    }



    private void Calcule()
    {
        switch (index)
        {
            case '+':

                if (indexFloat)
                {
                    calculeFloat2 = float.Parse(resulta.text);
                    solutionFloat = calculeFloat1 + calculeFloat2;
                    resulta.text = solutionFloat.ToString();
                }
                else
                {
                    solution = calcule1 + calcule2;
                    resulta.text = solution.ToString();
              
                }
               
                break;

            case '-':

                if (indexFloat)
                {
                    calculeFloat2 = float.Parse(resulta.text);
                    solutionFloat = calculeFloat1 - calculeFloat2;
                    resulta.text = solutionFloat.ToString();
                }
                else
                {
                    solution = calcule1 - calcule2;
                    resulta.text = solution.ToString();
              
                }

                break;

            case '/':

                if (indexFloat)
                {
                    calculeFloat2 = float.Parse(resulta.text);
                    solutionFloat = calculeFloat1 / calculeFloat2;
                    resulta.text = solutionFloat.ToString();
                }
                else
                {
                    solution = calcule1 / calcule2;
                    resulta.text = solution.ToString();
                
                }
                break;

            case 'X':

                if (indexFloat)
                {
                    calculeFloat2 = float.Parse(resulta.text);
                    solutionFloat = calculeFloat1 * calculeFloat2;
                    resulta.text = solutionFloat.ToString();
                }
                else
                {
                    solution = calcule1 * calcule2;
                    resulta.text = solution.ToString();
                
                }
                break;
        }
    }










    /* idée a garder absolument, faire en sorte que les chiffre s'ajoute les uns apres les autres exempls ( 111111) ce qui veut dite ( 1 + 1 + 1 + 1)
     * ensuite quand on touche un operateur arithmetique on transfert le texte de la case resulta a la case calcule  exemple result.innerHTML = calcul.innerHTML
     *  (15 +) => direction calcule, et dans le resulta on continue d'affiché la suite du calcule
     *  et quand on fai egale on affcihe le resultat dans la fenetre resulta, mais on conserve le calcule iniation dans la zone de camcule */


}
