using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BA4H
{
    class Program
    {
        public static List<int> Convolution(List<int> spectrum)
        {
            spectrum.Sort();//sortiram na pocetku pa da odmah mogu gledati razlike
            List<int> conv = new List<int>();
            for (int i = 0; i < spectrum.Count() - 1; i++)
            {
                for (int j = i; j < spectrum.Count(); j++)
                {
                    if (spectrum[j] - spectrum[i] != 0)//pazim da je razlika razlicita od 0
                        conv.Add(spectrum[j] - spectrum[i]);

                }
            }
            Dictionary<int, int> freq_dict = new Dictionary<int, int>();
            foreach (int mass in conv.Distinct())
                freq_dict[mass] = conv.Count((element) => element == mass);//svakom razlicitom elementu iz razlika za vrijednost dodam broj ponavljanja

            List<int> rj = new List<int>();


            foreach (KeyValuePair<int, int> vrij in freq_dict.OrderByDescending(key => key.Value))//pazim da je poredano po vrijednostima
            {
                for (int k = 0; k < vrij.Value; k++)
                    rj.Add(vrij.Key);
            }
            return rj;
        }
        static void Main(string[] args)
        {
            string s = "1205 392 527 1278 936 269 678 171 1188 506 1456 872 1061 1496 712 584 194 507 964 115 1636 939 137 1491 289 520 1392 1302 692 601 129 1399 993 758 103 1218 1164 229 1611 647 532 1238 274 1662 714 398 944 821 813 1521 807 1090 1579 815 383 172 217 772 377 927 547 282 1133 1121 929 506 735 1342 186 0 1336 1224 309 194 1579 698 1239 315 128 1388 1051 1032 326 807 904 1559 295 635 115 57 1167 1333 1259 1439 1708 952 1007 1221 1651 1130 1130 1382 821 463 331 1464 300 692 258 1571 1470 1118 1362 1202 57 1465 1662 1009 1527 397 225 1445 1233 627 621 1513 252 958 1015 1087 829 438 1464 1110 635 1650 704 1245 206 57 137 861 1144 103 186 1664 577 764 544 1361 154 644 733 1138 1483 836 657 1267 756 829 1637 101 366 950 1628 541 423 430 1571 826 403 1368 1001 632 1450 893 432 598 1245 1536 1030 1507 838 1650 1540 1067 1373 1668 446 97 238 301 1476 520 1258 950 429 114 1434 675 430 498 1319 1367 1181 1548 1636 1108 701 1628 1593 404 750 958 944 1765 129 1327 373 1073 244 1064 1335 526 563 1708 1708 1270 815 1259 1053 936 301 320 487 655 495 1335 560 801 1073 1594";
            List<int> spectrum = new List<int>();
            foreach (string m in s.Split(' '))
            {
                spectrum.Add(int.Parse(m));
            }
            List<int> rj = Convolution(spectrum);
            for (int i = 0; i <= rj.Count() - 1; i++)//obrnuto ih ispisujem
                Console.Write(rj[i]+" ");
            Console.ReadLine();

        }
    }
}
