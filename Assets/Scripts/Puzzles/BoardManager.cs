using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Row
{
    public FuseSlot[] rows = new FuseSlot[10];
}


public class BoardManager : MonoBehaviour
{
    public Row[] layout = new Row[9];


    public FuseLight[] row = new FuseLight[8];

    public FuseLight[] column = new FuseLight[9];


    public static BoardManager boardManager{ get; private set; }

    void Awake()
    {
        boardManager = this;
    }

    public void TurnOnLights(int a , int b,int c, int d)
    {
        row[a].TurnOn();
        column[b].TurnOn();

        row[a].NumOfCablesDup++;
        column[b].NumOfCablesDup++;

        row[c].TurnOn();
        column[d].TurnOn();

        row[c].NumOfCablesDup++;
        column[d].NumOfCablesDup++;

        Debug.Log(row[a].NumOfCablesDup + "  " + column[b].NumOfCablesDup + "  " + row[c].NumOfCablesDup + "  " + column[d].NumOfCablesDup);

        
    }
    public void TurnOffLights(int a, int b , int c, int d)
    {
        row[a].NumOfCablesDup--;
        if (row[a].NumOfCablesDup <= 0)
        {
            row[a].TurnOff();
            row[a].NumOfCablesDup = 0;
        }

        column[b].NumOfCablesDup--;
        if (column[b].NumOfCablesDup <= 0)
        {
            column[b].TurnOff();
            column[b].NumOfCablesDup = 0;
        }



        row[c].NumOfCablesDup--;
        if (row[c].NumOfCablesDup <= 0)
        {
            row[c].TurnOff();
            row[c].NumOfCablesDup = 0;
        }

        //row[c].TurnOff();
        //column[d].TurnOff();

        column[d].NumOfCablesDup--;
        if (column[d].NumOfCablesDup <= 0)
        {
            column[d].TurnOff();
            column[d].NumOfCablesDup = 0;
        }

        //row[c].NumOfCablesDup--;
        //column[d].NumOfCablesDup--;
    }
    

}
