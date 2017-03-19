//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StatUtilities : MonoBehaviour { 

//    public static Stat FindStat(List<Stat> stats, int id)
//    {
//        Stat stat = stats[0];
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == id)
//            {
//                stat = stats[i];
//            }
//        }
//        return stat;
//    }

//    // if fails, returns -1
//    public static int FindStatTotal(List<Stat> stats, int id)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == id)
//            {
//                int total = stats[i].totalAmount;
//                return total;
//            }
//        }
//        return -1;
//    }

//    public static void IncreaseStat(List<Stat> stats, int id, int amount)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == id)
//            {
//                stats[i].statAmount += amount;
//            }
//        }
//    }

//    public static void BuffStat(List<Stat> stats, int id, int amount)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == id)
//            {
//                stats[i].buffedAmount += amount;
//            }
//        }
//    }
//    public static void ResetStat(List<Stat> stats, int id, int amount)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == id)
//            {
//                stats[i].buffedAmount = 0;
//            }
//        }
//    }

//    public static void HealHP(List<Stat> stats, int amount)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 4)
//            {
//                for (int j = 0; j < stats.Count; j += 1)
//                {
//                    if (stats[j].statID == 5)
//                    {
//                        if (stats[i].statAmount + amount > stats[j].totalAmount)
//                        {
//                            stats[i].statAmount = stats[j].totalAmount;
//                        }
//                        else
//                        {
//                            stats[i].statAmount += amount;
//                        }
//                        break;
//                    }

//                }
//                break;
//            }
//        }
//    }

//    static IEnumerator Fade(int max, int min)
//    {
//        for (int i = max ; min < i; i -= 1)
//        {
//            yield return i;
//        }
//    }

//    public static void HealMP(List<Stat> stats, int amount)
//    {
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 6)
//            {
//                for (int j = 0; j < stats.Count; j += 1)
//                {
//                    if (stats[j].statID == 7)
//                    {
//                        if (stats[i].statAmount + amount > stats[j].totalAmount)
//                        {
//                            stats[i].statAmount = stats[j].totalAmount;
//                        }
//                        if (stats[i].statAmount + amount < 0)
//                        {
//                            stats[i].statAmount = 0;
//                        }
//                        else
//                        {
//                            stats[i].statAmount += amount;
//                        }
//                        break;
//                    }

//                }
//                break;
//            }
//        }
//    }

//    public static void HealHPFull(List<Stat> stats)
//    {
//        int hp = 0;
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 5)
//            {
//                hp = stats[i].totalAmount;
//                break;
//            }
//        }
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 4)
//            {

//                stats[i].statAmount = hp;
//                break;
//            }
//        }
//    }
//    public static void HealMPFull(List<Stat> stats)
//    {
//        int mp = 0;
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 7)
//            {
//                mp = stats[i].totalAmount;
//                break;
//            }
//        }
//        for (int i = 0; i < stats.Count; i += 1)
//        {
//            if (stats[i].statID == 6)
//            {

//                stats[i].statAmount = mp;
//                break;
//            }
//        }
//    }

//    public static void StatsUpdate(List<Stat> stats)
//    {
//        for (int i = 0; i < stats.Count; i += 1)// need to update all stats so id doesnt matter
//        {
//            {
//                stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
//            }
//        }

//    }
//}
