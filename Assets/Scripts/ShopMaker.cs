using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMaker {

	public static List<List<int>> shopItems =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                1000, 1001, 1002, 1003, -1,
                1050, 1051, 1052, 1053, -1,
                1600, 1601, 1602, 1603, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }),
                new List<int>(new int[]{
                1100, 1101, 1102, 1103, -1,
                1200, 1201, 1202, 1203, 1204,
                1300, 1301, 1302, 1303, -1,
                1400, 1401, 1402, 1403, -1,
                1500, 1501, 1502, 1503, -1
            }),
                new List<int>(new int[]{
                1700, 1701, 1702, 1703, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }),
            new List<int>(new int[]{
                9100, 9101, 9102, 9103, -1,
                0, 1, 2, 3, 4,
                5, 6, 7, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }) });
    public static List<List<int>> hospital =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                9000, 9001, 9002, -1, -1,
                9003, 9004, 9005, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                 -1, -1, -1, -1, -1
            }),
            new List<int>(new int []{
                9100, 9101, 9102, 9103, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }) });
    public static List<List<int>> restuarant =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                10000, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                 -1, -1, -1, -1, -1
            }) });
}
