﻿using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GetNumbersArr();
            MergeSortRecursive(ref numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void MergeSortRecursive(ref int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                MergeSortRecursive(ref numbers, left, middle);
                MergeSortRecursive(ref numbers, (middle + 1), right);
                Merge(ref numbers, left, middle, right);
            } 
        }
        public static void Merge(ref int[] numbers, int left, int middle, int right)
        {
            int i, j, k;

            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = numbers[left + i];
            }

            for (j = 0; j < n2; j++)
            { 
                R[j] = numbers[middle + 1 + j];
            }

            i = 0;
            j = 0;
            k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    numbers[k] = L[i];
                    i++;
                }
                else
                {
                    numbers[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                numbers[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                numbers[k] = R[j];
                j++;
                k++;
            }
        }

        private static int[] GetNumbersArr()
        {
            int[] numbers = new[] { 75604, 463284, 190358, 519906, 677003, 636527, 127957, 619621, 626781, 268678, 689719, 261043, 875278, 146574, 201353, 621131, 545264, 928219, 217907, 155838, 982082, 77578, 630091, 242267, 380191, 884157, 726634, 560120, 767119, 38207, 80522, 657285, 408338, 334486, 134182, 134982, 684021, 386186, 715685, 749029, 280596, 146352, 476122, 724224, 875433, 298218, 40517, 821128, 51420, 170468, 64835, 212396, 502439, 382603, 178047, 28376, 667156, 203884, 531783, 851935, 866859, 321933, 195077, 106754, 707369, 871651, 933641, 390973, 408439, 4973, 722399, 91450, 333280, 872623, 48175, 252773, 247270, 606662, 91456, 930114, 689836, 901642, 816097, 792216, 834709, 936345, 793630, 327971, 839125, 827899, 126363, 948866, 5175, 320881, 472310, 492291, 189700, 420969, 157337, 940402, 891147, 63602, 766799, 629307, 864422, 447668, 617816, 87104, 960285, 257389, 788888, 150957, 85428, 970328, 243843, 760978, 263139, 295037, 444320, 248543, 73819, 323092, 377004, 729272, 766496, 860707, 132562, 862181, 437908, 835982, 777265, 276603, 180981, 179980, 717373, 617837, 968867, 432, 337336, 258070, 372606, 347594, 136108, 182050, 742303, 607920, 621574, 218535, 10328, 994509, 18145, 857425, 704053, 124787, 4637, 82719, 141721, 529796, 66170, 271534, 222098, 1393, 431240, 912173, 326002, 501878, 178991, 725285, 439464, 870523, 901832, 25, 126463, 484556, 26528, 436270, 594893, 473636, 142082, 695333, 661025, 448390, 566978, 497083, 714156, 929542, 477595, 864981, 392044, 852046, 991195, 162373, 691472, 616578, 376388, 527593, 701895, 420070, 261810, 953745, 326033, 69651, 90291, 435280, 924923, 645685, 522751, 882872, 736559, 954422, 390399, 315698, 407524, 659612, 715659, 938234, 200620, 874765, 247234, 935773, 912886, 209142, 482295, 797453, 383805, 471754, 338203, 828945, 933603, 284008, 594957, 640851, 975134, 284271, 670200, 269041, 408062, 693713, 770405, 446892, 36966, 351723, 498414, 80613, 131185, 340328, 639652, 956486, 432467, 893548, 957866, 479036, 816187, 701531, 666025, 696920, 590311, 158028, 644998, 784154, 936427, 359637, 927338, 704229, 277195, 897466, 453817, 737786, 265709, 946037, 928661, 601983, 363930, 758084, 600404, 103175, 535237, 419454, 245633, 132129, 140268, 177917, 579103, 61260, 877386, 640802, 892190, 920022, 657523, 946589, 366357, 825310, 912690, 980585, 927119, 733397, 243082, 981248, 845798, 506755, 939047, 328654, 408141, 866537, 418489, 459160, 252171, 377222, 731413, 355080, 960649, 370260, 413001, 671092, 865336, 640779, 716103, 722240, 854539, 517354, 872611, 475673, 528958, 161543, 388225, 765312, 448834, 296901, 141751, 78596, 672132, 699932, 774027, 393999, 220861, 200604, 41678, 317234, 492960, 2931, 972130, 429613, 781088, 864811, 992323, 400467, 534042, 331331, 172877, 290397, 557494, 423876, 25546, 670862, 785621, 75951, 161270, 285717, 89909, 800077, 902248, 637233, 177931, 42834, 582854, 755360, 148225, 985480, 315034, 213117, 504218, 759326, 986283, 470781, 894642, 588170, 167733, 675421, 759448, 695594, 741367, 486009, 830867, 461473, 455447, 467679, 939395, 622625, 54496, 545351, 313649, 599948, 110502, 728571, 904146, 933706, 264923, 290211, 99360, 683936, 844627, 277732, 649820, 739948, 114980, 434994, 774135, 357680, 715352, 921679, 497619, 84642, 525801, 54808, 379773, 457616, 137216, 253983, 775575, 558531, 849174, 220528, 827535, 954029, 152981, 306984, 560090, 647154, 900301, 268699, 716217, 887172, 452851, 453111, 435281, 957952, 283436, 631045, 155492, 215455, 299041, 347459, 951684, 560141, 350950, 247236, 658665, 23522, 16681, 271508, 662189, 837415, 48819, 570655, 680363, 428975, 772363, 741159, 712894, 450425, 991883, 692701, 642237, 190010, 722413, 67806, 559314, 751292, 492828, 810642, 103870, 719396, 388556, 252758, 958607, 477205, 385232, 519811, 638333, 416610, 579038, 715017, 858917, 431608, 925899, 497634, 770268, 149733, 928284, 417173, 979726, 292557, 870189, 350278, 235339, 985439, 187750, 624005, 79817, 72072, 306656, 655797, 942660, 192941, 425630, 663333, 947676, 299080, 836969, 567808, 397768, 272893, 282037, 127347, 277716, 520125, 170219, 43774, 881050, 91587, 157722, 638813, 892081, 21467, 624804, 669186, 552648, 839989, 811610, 484476, 104097, 439640, 764388, 614604, 332736, 237315, 226502, 853250, 464428, 507009, 789622, 330865, 572183, 997808, 249498, 685425, 571323, 194739, 877334, 706998, 197200, 841860, 742131, 346803, 322830, 33569, 840344, 617138, 662428, 690173, 346764, 922384, 598390, 836709, 984550, 932963, 700479, 587234, 41863, 408182, 194016, 752762, 662031, 115544, 888385, 444948, 259972, 448457, 937551, 668713, 886823, 721659, 172346, 166724, 740233, 190452, 702498, 36135, 911019, 925628, 540226, 598030, 220710, 512205, 66165, 868639, 483612, 183692, 960895, 393602, 37488, 13796, 667745, 240624, 918402, 64776, 407541, 94583, 870871, 565464, 995389, 325017, 898392, 790264, 643439, 561438, 341717, 72802, 225018, 988730, 644651, 620293, 489255, 29815, 366498, 597162, 636521, 432331, 880418, 530227, 807434, 997134, 132899, 766252, 552724, 835515, 588388, 454878, 820240, 801538, 440553, 266848, 362703, 635835, 57693, 95905, 672229, 79290, 450501, 293278, 126298, 357457, 985608, 288747, 764097, 777482, 954460, 856812, 309556, 384975, 796838, 388709, 946730, 307796, 724454, 539633, 19850, 873204, 337979, 81581, 453842, 86852, 14048, 187420, 25577, 278173, 683400, 198841, 283551, 698039, 418936, 772869, 644984, 221783, 784397, 638272, 131477, 408297, 789087, 357387, 606970, 465751, 999329, 614902, 929459, 10619, 447256, 494231, 142018, 273010, 548413, 105684, 680183, 381787, 603392, 590607, 145104, 269588, 349651, 10950, 343619, 240578, 410746, 478052, 60481, 644510, 244435, 457366, 225912, 459301, 70615, 541973, 69992, 2210, 100196, 504783, 674276, 294643, 21469, 358081, 872187, 676271, 127821, 236862, 414192, 833764, 713517, 71055, 179453, 660696, 274320, 661397, 140875, 625899, 659327, 681861, 441203, 520817, 398298, 342203, 730544, 947133, 251774, 172335, 119489, 129394, 171245, 631641, 312731, 934689, 993560, 748810, 891159, 958851, 437710, 572744, 398828, 494210, 712934, 392402, 756222, 306423, 871178, 283907, 3150, 131989, 376700, 894988, 507495, 354233, 451062, 413785, 222908, 328067, 438908, 443520, 738269, 568072, 676045, 17694, 559747, 885964, 587297, 564282, 866217, 873735, 793268, 631957, 123377, 645843, 376355, 152912, 731733, 756769, 546659, 499481, 934093, 653283, 522880, 969643, 846726, 837388, 867057, 753166, 846350, 828636, 445015, 611439, 995353, 80540, 551938, 277598, 149823, 384024, 852564, 406030, 939364, 994341, 418468, 939703, 200995, 537030, 650355, 208918, 552447, 203337, 641540, 393911, 85264, 178898, 436735, 222717, 343620, 60498, 115918, 636446, 287244, 983486, 972941, 99612, 674498, 925099, 245586, 230616, 27483, 896135, 573428, 678102, 423210, 158827, 206928, 798184, 505808, 617055, 892245, 973132, 179610, 256059, 620443, 873425, 641801, 138388, 909107, 892482, 369796, 72894, 650112, 558728, 262779, 440011, 26856, 781655, 620549, 633998, 799581, 939680, 948859, 497273, 726780, 913652, 601273, 908053, 160630, 342241, 440046, 216524, 324452, 90958, 912694, 225519, 6095, 427170, 818191, 743794, 465109, 848728, 68885, 706557, 621870, 546886, 940540, 970501, 139670, 633852, 692967, 476138, 789165, 669518, 950570, 429310, 440602, 2243, 602317, 356165, 127572, 387534, 45509, 343514, 567058, 842326, 603341, 845258, 295132, 205821, 572323, 946524, 98994, 383160, 881214, 680868, 207618, 337831, 847333, 109427, 948537, 306284, 591142, 404379, 475867, 877174, 701987, 39440, 789262, 872275, 826427, 1399, 592616, 454662, 260877, 787841, 867104, 439814, 829761, 434494, 478867, 924891, 273855, 297755, 576723, 215445, 960005, 447765, 159110, 493159, 430864, 933799, 592767, 415238, 932033, 335360, 619266, 697818, 401400, 12518, 271426, 591631, 234428, 854964, 116689, 52918, 135650, 889616, 760273, 485279, 556707, 256190, 875305, 102928, 105490, 634590 };

            return numbers;
        }
    }
}
