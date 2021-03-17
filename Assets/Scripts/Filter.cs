using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour
{
    
    List<Trader> cashGuild;
    List<Trader> filteredGuild;

    public List<Trader> FilterList(List<Trader> mainGuild)
    {
        cashGuild = mainGuild;
        filteredGuild = mainGuild;

        for (int numberOfTraders = 0; numberOfTraders < 12; numberOfTraders++)
        {
            Trader bestTrader = null;

            int smallest = 0;
            int biggest = 0;


            //������� �������� � �������
            foreach (Trader trader in cashGuild)
            {
                if (trader.Money < smallest)
                {
                    smallest = trader.Money;
                }
                
                if (trader.Money > biggest)
                {
                    biggest = trader.Money;
                }
            }
            
            //������� ������� �������� � ������� ��� �� ������������� ������, ����� �� ��� ������ �� ���������.
            foreach(Trader trader in cashGuild)
            {
                if (trader.Money == biggest)
                {
                    bestTrader = trader;
                }
                //������� ������� �������� �� ��������� ����� � �����, �� �������� ��������� ������ ��������, �������� �������.
                foreach (Trader _trader in filteredGuild)
                {
                    if (_trader.Money == smallest && trader.Money == smallest)
                    {
                        _trader.Type = bestTrader.Type;
                        cashGuild.Remove(trader);
                        break;
                    }
                }
            }
        }

        return filteredGuild;
    }
}
