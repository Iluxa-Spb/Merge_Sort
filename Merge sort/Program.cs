using System;

namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 13, 3, 8, 1, 15, 2, 3, 7, 4 };
            Console.WriteLine("Массив до сортировки: ");
            foreach (int i in mas) Console.Write(i +" ");
            Console.WriteLine("");
            mas = Sort(mas);
            Console.WriteLine("Массив после сортировки: ");
            foreach (int i in mas) Console.Write(i +" ");
        }
        /// <summary>
        /// Функция деления массива на подмасивы
        /// </summary>
        /// <param name="buff">Принимает целочисленный массив.</param>
        /// <returns>Возвращает отсортированный целочисленный массив.</returns>
        public static int[] Sort(int[] buff)
        {
            /// <remarks>
            /// Рекурсия идет до тех пор, пока массив делится
            /// </remarks>
            if (buff.Length == 1) 
                return buff;
            else
            {
                /// <remarks>
                /// 1 часть, пустой массив
                /// </remarks>
                int[] left = new int[buff.Length/2];
                /// <remarks>
                /// 2 часть, пустой массив
                /// </remarks>
                int[] right = new int[buff.Length - left.Length];
                /// <remarks>
                /// Заполняем новосозданные массивы значениями
                /// </remarks>
                for (int i = 0; i < buff.Length; i++)
                { 
                    if (i < (int)buff.Length/2)
                        left[i] = buff[i];
                    else
                        right[i - (int)buff.Length / 2] = buff[i];
                }
                /// <remarks>
                /// Рекурсия левого массива
                /// </remarks>
                left = Sort(left);
                /// <remarks>
                /// Рекурсия правого массива
                /// </remarks>
                right = Sort(right);
                /// <remarks>
                /// Отправляем заполненные значениями массивы в следующий метод
                /// </remarks>
                buff = SortNext(left, right);
                return buff;
            }
        }
        /// <summary>
        /// Функция сортировки
        /// </summary>
        /// <param name="left">Левый субмассив</param>
        /// <param name="right">Правый субмассив</param>
        /// <returns>Соединенный отсортированный массив</returns>
        public static int[] SortNext(int[] left, int[] right)
        {
            /// <remarks>
            /// Создаем результирующий массив из суммы длин массивов из аргументов метода
            /// </remarks>
            int[] buff = new int[left.Length + right.Length];
            int l = 0, r = 0;
            for (int i = 0; i < left.Length + right.Length; i++)
            /// <remarks>
            /// Сравниваем массивы, меняем местами элементы, заполняем новосозданный массив
            /// </remarks>
            {
                /// <remarks>
                ///если правая часть уже использована, дальнейшее движение происходит только в левой
                ///проверка на выход правого массива за пределы
                /// </remarks>
                if (r >= right.Length)
                {
                    buff[i] = left[l];
                    l++;
                }
                /// <remarks>
                ///проверка на выход за пределы левого массива
                ///и сравнение текущих значений обоих массивов
                /// </remarks>
                else if (l < left.Length && left[l] < right[r])
                {
                    buff[i] = left[l];
                    l++;
                }
                /// <remarks>
                ///если текущее значение правой части больше
                /// </remarks>
                else
                {
                    buff[i] = right[r];
                    r++;
                }
            }
            return buff;
        }
    }
}
