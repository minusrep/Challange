using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trading : MonoBehaviour
{
    [SerializeField]
    private List<Trader> mainGuild;

    [SerializeField]
    private List<Trader> cashGuild;

    private void Awake()
    {
        OneTimeTransactions();
        FilterTraders();
    }

    private void OneTimeTransactions()
    {
        int traderNumber = 0;

        while (traderNumber < mainGuild.Count)
        {
            Trader left = mainGuild[traderNumber];
            traderNumber++;
            Trader right = mainGuild[traderNumber];
            traderNumber++;

            if (left.Trade() && right.Trade())
            {
                left.Money += 4;
                right.Money += 4;
            }
            else if (!left.Trade() && right.Trade())
            {
                left.Money += 5;
                right.Money += 1;
            }
            else if (left.Trade() && !right.Trade())
            {
                left.Money += 1;
                right.Money += 5;
            }
            else if (!left.Trade() && !right.Trade())
            {
                left.Money += 2;
                right.Money += 2;
            }

            //     Debug.Log(left.name + " traded with " + right.name);
        }
    }

    private void RepeatTrade(int times)
    {
        for (int i = 0; i < times; i++)
        {
            OneTimeTransactions();
        }
    }

    private void FilterTraders()
    {
        cashGuild = mainGuild;

        for (int i = 0; i < 12; i++)
        {

            Trader bestTrader = null, worstTrader = null;

            int biggest = 0, smallest = 1000;
            bool operationIsDone = false;

            //������� ������������ ���������� ����� � ������� � �����������.
            foreach(Trader trader in cashGuild)
            {
                if (biggest < trader.Money)
                {
                    biggest = trader.Money;
                }

                if (smallest > trader.Money)
                {
                    smallest = trader.Money;
                }
            }
            //������� ������� ���������, � �������� ����� ���������� ���.
            foreach(Trader trader in cashGuild)
            {
                if (trader.Money == biggest)
                {
                    bestTrader = trader;
                    cashGuild.Remove(trader);
                    break;
                }
            }
            
        /// �� ������� ������� ������� � ������� �������, ������� �� ����, ������� ������� �� ���� �� ��������� ����������,
        /// ������� �� ������� ������� ����������� ��� �������, �������� ��������� ���� � ����, ���� foreach �� ����� ����������
        /// � ������ �� ���������� �����, ���� �� ������� ��� ������ ���� �� ���� ������.
        /// 
        /// � ���������� �� ���� �������� ������ � ���� � �������������� :(
            foreach (Trader trader in mainGuild)
            {
                foreach(Trader _trader in cashGuild)
                {
                    if (trader.Money == smallest && _trader.Money == smallest && !operationIsDone)
                    {
                        Debug.Log("Last foreach");
                        trader.Type = bestTrader.Type;
                        cashGuild.Remove(_trader);
                        operationIsDone = true;
                        break;
                    }
                }

            }
        }
    }

}

