using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    private static System.Random randNum = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        //����Ʈ�� ũ�⸸ŭ �ݺ�
        while (n > 1)
        {
            n--;
            //0���� ũ�ų� ���� int32.maxValue ���� ���� 32��Ʈ ��ȣ �ִ� ���� �Դϴ�.
            int k = randNum.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}