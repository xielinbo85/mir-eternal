﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameServer.Templates
{
	// Token: 0x020002CD RID: 717
	public sealed class 角色成长
	{
		// Token: 0x060006F6 RID: 1782 RVA: 0x00035FB4 File Offset: 0x000341B4
		static 角色成长()
		{
			
			Dictionary<byte, int> dictionary = new Dictionary<byte, int>();
			dictionary[1] = 100;
			dictionary[2] = 200;
			dictionary[3] = 300;
			dictionary[4] = 400;
			dictionary[5] = 600;
			dictionary[6] = 900;
			dictionary[7] = 1200;
			dictionary[8] = 1700;
			dictionary[9] = 2500;
			dictionary[10] = 6000;
			dictionary[11] = 8000;
			dictionary[12] = 10000;
			dictionary[13] = 15000;
			dictionary[14] = 30000;
			dictionary[15] = 40000;
			dictionary[16] = 50000;
			dictionary[17] = 70000;
			dictionary[18] = 100000;
			dictionary[19] = 120000;
			dictionary[20] = 140000;
			dictionary[21] = 250000;
			dictionary[22] = 300000;
			dictionary[23] = 350000;
			dictionary[24] = 400000;
			dictionary[25] = 500000;
			dictionary[26] = 700000;
			dictionary[27] = 1000000;
			dictionary[28] = 1400000;
			dictionary[29] = 1800000;
			dictionary[30] = 2000000;
			dictionary[31] = 2400000;
			dictionary[32] = 2800000;
			dictionary[33] = 3200000;
			dictionary[34] = 3600000;
			dictionary[35] = 4000000;
			dictionary[36] = 4800000;
			dictionary[37] = 5600000;
			dictionary[38] = 8200000;
			dictionary[39] = 9000000;
			dictionary[40] = 12000000;
			dictionary[41] = 16000000;
			dictionary[42] = 30000000;
			dictionary[43] = 50000000;
			dictionary[44] = 80000000;
			dictionary[45] = 120000000;
			dictionary[46] = 280000000;
			dictionary[47] = 360000000;
			dictionary[48] = 400000000;
			dictionary[49] = 420000000;
			dictionary[50] = 430000000;
			dictionary[51] = 440000000;
			dictionary[52] = 460000000;
			dictionary[53] = 480000000;
			dictionary[54] = 500000000;
			dictionary[55] = 520000000;
			dictionary[56] = 550000000;
			dictionary[57] = 600000000;
			dictionary[58] = 700000000;
			dictionary[59] = 800000000;
			角色成长.升级所需经验 = dictionary;
			角色成长.宠物升级经验 = new ushort[]
			{
				5,
				10,
				15,
				20,
				25,
				30,
				35,
				40,
				45
			};
			角色成长.DataSheet = new Dictionary<int, Dictionary<GameObjectProperties, int>>();
			string path = CustomClass.GameData目录 + "\\System\\GrowthAttribute.txt";
			string[] array = Regex.Split(File.ReadAllText(path).Trim(new char[]
			{
				'\r',
				'\n',
				'\r'
			}), "\r\n", RegexOptions.IgnoreCase);
            Dictionary<string, int> dictionary2 = array[0].Split(new char[]
            {
                '\t'
            }).ToDictionary((string K) => K, (string V) => Array.IndexOf<string>((string[])array[0].Split(new char[]
            {
                '\t'
            }), V));
			for (int i = 1; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'\t'
				});
				if (array2.Length > 1)
				{
					Dictionary<GameObjectProperties, int> dictionary3 = new Dictionary<GameObjectProperties, int>();
					int num = (int)((GameObjectProfession)Enum.Parse(typeof(GameObjectProfession), array2[0]));
					int num2 = Convert.ToInt32(array2[1]);
					int key = num * 256 + num2;
					for (int j = 2; j < array[0].Split(new char[]
					{
						'\t'
					}).Length; j++)
					{
						GameObjectProperties GameObjectProperties;
						if (Enum.TryParse<GameObjectProperties>(array[0].Split(new char[]
						{
							'\t'
						})[j], out GameObjectProperties) && Enum.IsDefined(typeof(GameObjectProperties), GameObjectProperties))
						{
							dictionary3[GameObjectProperties] = Convert.ToInt32(array2[dictionary2[GameObjectProperties.ToString()]]);
						}
					}
					角色成长.DataSheet.Add(key, dictionary3);
				}
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000060BB File Offset: 0x000042BB
		public static Dictionary<GameObjectProperties, int> 获取数据(GameObjectProfession 职业, byte 等级)
		{
			return 角色成长.DataSheet[(int)((byte)职业) * 256 + (int)等级];
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x000027D8 File Offset: 0x000009D8
		public 角色成长()
		{
			
			
		}

		// Token: 0x04000C39 RID: 3129
		public static Dictionary<int, Dictionary<GameObjectProperties, int>> DataSheet;

		// Token: 0x04000C3A RID: 3130
		public static readonly Dictionary<byte, int> 升级所需经验;

		// Token: 0x04000C3B RID: 3131
		public static readonly ushort[] 宠物升级经验;
	}
}