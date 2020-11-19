using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadPoint.JaggedArrayTranslate
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateAnagramsArray(new string[] { "кот", "Бот", "тоК", "ооо", "кол", "ЛОК", "фыв", "аываыва", "12йцу", "2йцуйцу" });

            CreateAnagramsArray(new string[] {});
        }

        /// <summary>
        /// Создать массив анаграмм
        /// </summary>
        /// <param name="wordArray">Массив слов</param>
        /// <returns></returns>
        public static string[][] CreateAnagramsArray(string[] wordArray)
        {
            string[][] anagramsArray = (string[][])Array.CreateInstance(typeof(string[]), 0);

            foreach (var word in wordArray)
            {
                var indexAnagramSet = findIndexAnagramSet(anagramsArray, word);

                if (indexAnagramSet != null)
                {
                    var newArrayLength = anagramsArray[indexAnagramSet.Value].Length + 1;

                    Array.Resize<string>(ref anagramsArray[indexAnagramSet.Value], newArrayLength);

                    anagramsArray[indexAnagramSet.Value][newArrayLength - 1] = word;
                }
                else
                {
                    var newResultArrayLength = anagramsArray.Length + 1;

                    Array.Resize<string[]>(ref anagramsArray, newResultArrayLength);

                    anagramsArray.SetValue(Array.CreateInstance(typeof(string), 1), newResultArrayLength - 1);

                    anagramsArray[newResultArrayLength - 1][0] = word;
                }
            }

            return anagramsArray;
        }

        /// <summary>
        /// Поиск индекса набора анаграм для слова
        /// </summary>
        /// <param name="result"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        private static int? findIndexAnagramSet(string[][] result, string word)
        {
            for (int i = 0; i < result.Length; i++)
            {
                var valRes = result[i];

                if (valRes == null)
                    continue;

                var lengthValRes = valRes.Length;

                if (lengthValRes != 0 && isAnagramm(valRes[0], word))
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Проверка что одна строка является анаграммой другой строки
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool isAnagramm(string str1, string str2)
        {
            string orderedCharString1 = string.Concat(str1.ToLower().OrderBy(c => c));
            string orderedCharString2 = string.Concat(str2.ToLower().OrderBy(c => c));

            return orderedCharString1 == orderedCharString2;
        }
    }
}
