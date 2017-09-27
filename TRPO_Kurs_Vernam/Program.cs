using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ТРПО_курсач
{
    public class OnTimePad
    {
        Dictionary<char, int> alph = new Dictionary<char, int>();
        Dictionary<int, char> alph_r = new Dictionary<int, char>();

        public OnTimePad(IEnumerable<char> Alphabet)
        {
            int i = 0;
            foreach (char c in Alphabet)
            {
                alph.Add(c, i);
                alph_r.Add(i++, c);
            }
        }
        public string Crypt1(string Text, string Key, bool Crypt)
        {
            char[] key = Key.ToCharArray();
            char[] text = Text.ToCharArray();
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int idx;
                if (alph.TryGetValue(text[i], out idx))
                {
                    int r = alph.Count + idx;
                    r += (Crypt ? 1 : -1) * alph[key[i % key.Length]];
                    sb.Append(alph_r[r % alph.Count]);
                }
            }

            return sb.ToString();
        }
        public string Crypt2(string Text, string Key)
        {
            char[] key = Key.ToCharArray();
            char[] text = Text.ToCharArray();
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int ind;
                if (alph.TryGetValue(text[i], out ind))
                {
                    sb.Append(alph_r[(ind ^ alph[key[i % key.Length]]) % alph.Count]);
                }
            }

            return sb.ToString();
        }

        public class Program
        {
            static string Changekey(string input, int language, int nabc)
            {

                string output = "";
                int[] masn = new int[input.Length];
                // masn массив целых чисел длинной сопоставимой с исходной строкой 
                int leng = input.Length;
                Random rand = new Random();
                int temp;
                for (int g = 0; g < input.Length; g++)//инициализ. массива
                {
                    temp = rand.Next(nabc);
                    masn[g] = temp;
                }

                switch (language)
                {
                    case 1:
                        for (int g = 0; g < input.Length; g++)
                        {
                            output += Convert.ToChar(masn[g] + 'a');

                        }
                        File.WriteAllText("Onetimenote.txt", output);
                        return output;
                    case 2:
                        for (int g = 0; g < input.Length - 1; g++)
                        {
                            output += Convert.ToChar(masn[g] + 'а');

                        }
                        File.WriteAllText("Onetimenote.txt", output);
                        return output;
                    default:
                        break;
                }
                return output;
            }
            static string fiks()
            {
                Console.WriteLine("Собрать новую систему цилиндров!");
                Console.WriteLine("1 - да");
                Console.WriteLine("2 - нет");
                switch (Console.ReadLine())
                {
                    case "1":
                        newdisks();
                        break;
                    case "2":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("404 not Found");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                Console.WriteLine("y - Проверка массива");
                switch (Console.ReadLine())
                {
                    case "y":
                        testmas();
                        break;
                }

                return "";
            }
            static string testmas()
            {
                string key = "";
                int j = 0, x = 0, i = 0;
                // k - количество цифр в ключе
                // key - ключ
                key = File.ReadAllText("jeffdisks.txt");
                char[,] maskey = new char[26, 36];
                File.AppendAllText("Empty.log", "");
                File.Replace("Empty.log", "outjeff.txt", "copy.log");
                while (i <= 1007)
                {
                    Console.Write("Новая строка: ");
                    Console.Write(x + 1);
                    Console.WriteLine(" i: " + i + " key: " + key[i]);
                    j = 0;
                    for (int g = i; g <= i + 25; g++)
                    {
                        maskey[j, x] = (key[g]);
                        Console.Write("maskey[" + j + "," + x + "]: " + maskey[j, x] + " ");
                        Console.Write("key[" + g + "]: " + key[g] + " ");
                        File.AppendAllText("outjeff.txt", "maskey[" + j + "," + x + "]: " + maskey[j, x] + " ");
                        File.AppendAllText("outjeff.txt", "key[" + g + "]: " + key[g] + " ");
                        File.AppendAllText("outjeff.txt", Environment.NewLine);
                        Console.WriteLine();
                        j++;
                    }
                    Console.WriteLine();
                    x++;
                    i += 28;
                }
                return "";
            }
            static string newdisks()
            {
                String outp = "";
                File.AppendAllText("Empty.log", "");
                File.Replace("Empty.log", "Jeffdisks.txt", "copy.log");
                for (int i = 0; i <= 35; i++)
                {
                    List<int> list = new List<int>();
                    Random rand = new Random();
                    while (list.Count < 26)
                    {
                        int n = rand.Next(1, 27);
                        if (!list.Contains(n))
                            list.Add(n);
                    }
                    outp = "";
                    int[] mas = new int[26];
                    for (int g = 0; g <= 25; g++)
                    {
                        outp += Convert.ToChar(list[g] + 'A' - 1);
                        File.AppendAllText("Jeffdisks.txt", outp[g] + "");
                    }
                    File.AppendAllText("Jeffdisks.txt", Environment.NewLine);
                }
                Console.WriteLine("Процесс завершился!!!");
                Console.Read();
                return "";
            }
            static byte Choose()
            {
                Console.Clear();
                byte flag = 0;
                while (flag == 0)
                {
                    Console.WriteLine("1 - Зашифровать");
                    Console.WriteLine("2 - Расшифровать");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            flag++;
                            return 1;
                        case "2":
                            flag++;
                            return 2;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("404 not Found");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                return 0;
            }
            public static string Input()
            {
                Console.Clear();
                byte flag = 0;
                while (flag == 0)
                {
                    Console.WriteLine("1 - Ввод с клавиатуры");
                    Console.WriteLine("2 - Ввод из файла");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            flag++;
                            Console.Clear();
                            Console.Write("Вводите: ");
                            return Console.ReadLine();
                        case "2":
                            flag++;
                            return File.ReadAllText("input.txt");
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("404 not Found");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                return "ALARM!!!";
            }
            static void Example1(string text, byte type)
            {
                string alph = "abcdefghijklmnopqrstuvwxyz";
                string key = "";
                string decrypt, encrypt;
                var pad = new OnTimePad(alph);

                switch (type)
                {
                    case 1:
                        key = Changekey(text, 1, 25);
                        Console.WriteLine("Оригинал: " + text);
                        encrypt = pad.Crypt1(text, key, true);
                        File.WriteAllText("key.txt", key);
                        File.WriteAllText("encrypt.txt", encrypt);
                        Console.WriteLine("Шифротекст: " + encrypt);
                        break;
                    case 2:
                        encrypt = File.ReadAllText("encrypt.txt");
                        Console.WriteLine("Оригинал: " + encrypt);
                        key = File.ReadAllText("key.txt");
                        decrypt = pad.Crypt1(encrypt, key, false);
                        File.WriteAllText("decrypt.txt", decrypt);
                        Console.WriteLine("Расшифровка: " + decrypt);
                        break;
                }
            }
            static void Example2(string text, byte type)
            {
                string alph = "абвгдежзийклмнопрстуфхцчшыьэюя .";
                string key = "";
                string decrypt, encrypt;
                var pad = new OnTimePad(alph);

                switch (type)
                {
                    case 1:
                        key = Changekey(text, 2, 32);
                        Console.WriteLine("Оригинал: " + text);
                        encrypt = pad.Crypt2(text, key);
                        File.WriteAllText("key.txt", key);
                        File.WriteAllText("encrypt.txt", encrypt);
                        Console.WriteLine("Шифротекст: " + encrypt);
                        break;
                    case 2:
                        encrypt = File.ReadAllText("encrypt.txt");
                        Console.WriteLine("Оригинал: " + encrypt);
                        key = File.ReadAllText("key.txt");
                        decrypt = pad.Crypt2(encrypt, key);
                        File.WriteAllText("decrypt.txt", decrypt);
                        Console.WriteLine("Расшифровка: " + decrypt);
                        break;
                }
            }
            static string Caesar(string input, byte type)
            {
                string output = "";
                int key = 0;
                Console.Write("ключ: ");
                key = int.Parse(Console.ReadLine());//ключ            
                switch (type)
                {
                    case 1:
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                                if ((input[i] + key) > 'z' || (input[i] + key) > 'Z' && input[i] <= 'Z')
                                    output += Convert.ToChar(input[i] - 26 + key);
                                else
                                    output += Convert.ToChar(input[i] + key);
                            else if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                if ((input[i] + key) > 'я' || (input[i] + key) > 'Я' && input[i] <= 'Я')
                                    output += Convert.ToChar(input[i] - 32 + key);
                                else
                                    output += Convert.ToChar(input[i] + key);
                            else
                                output += input[i];
                        }
                        return output;
                    case 2:
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                                if ((input[i] - key) < 'a' && input[i] >= 'a' || (input[i] - key) < 'A')
                                    output += Convert.ToChar(input[i] + 26 - key);
                                else
                                    output += Convert.ToChar(input[i] - key);
                            else if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                if ((input[i] - key) < 'а' && input[i] >= 'а' || (input[i] - key) < 'А')
                                    output += Convert.ToChar(input[i] + 32 - key);
                                else
                                    output += Convert.ToChar(input[i] - key);
                            else
                                output += input[i];
                            //output += Convert.ToChar(input[i] - 5);
                        }
                        return output;
                    default:
                        Console.WriteLine("Получена неизвестная ошибка, программа будет закрыта...");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                }
                return "";
            }
            static string Verrnam(byte type)
            {
                var Pad2 = new Program();
                byte flager = 0;
                string input = "";
                switch (type)
                {
                    case 1:
                        input = Input();
                        break;
                    case 2:
                        input = File.ReadAllText("key.txt");
                        break;
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                        flager = 0;
                    else if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                        flager = 1;
                }
                if (flager == 0)
                {
                    Example1(input, type);
                    Console.WriteLine();
                }
                else if (flager == 1)
                {
                    Example2(input, type);
                    Console.ReadKey();
                }
                return "";
            }
            static string Vigenere(string input, byte type)
            {
                string output = "";
                int j, nvige = 0;
                string kvige = "";
                Console.WriteLine("Введите ключ:");
                kvige = Console.ReadLine();//строка букв ключ

                switch (type)
                {
                    case 1:
                        j = 0;
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (j > kvige.Length - 1)
                                j = 0;
                            nvige += Convert.ToChar(kvige[j]);//номер элемента в коде utf-16 ключа
                            nvige = 0;

                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if (kvige[j] >= 'a')
                                    nvige += Convert.ToChar(kvige[j] - 'a' + 1);
                                else
                                    nvige += Convert.ToChar(kvige[j] - 'A' + 1);

                                if ((input[i] + nvige) > 'z' || (input[i] + nvige) > 'Z' && input[i] <= 'Z')
                                    output += Convert.ToChar(input[i] - 26 + nvige);
                                else
                                    output += Convert.ToChar(input[i] + nvige);
                            }
                            else
                            {
                                nvige = 0;
                                if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                    if (kvige[j] >= 'а')
                                        nvige += Convert.ToChar(kvige[j] - 'а' + 1);
                                    else
                                        nvige += Convert.ToChar(kvige[j] - 'А' + 1);
                                if ((input[i] + nvige) > 'я' || (input[i] + nvige) > 'Я' && input[i] <= 'Я')
                                    output += Convert.ToChar(input[i] - 32 + nvige);
                                else
                                    output += Convert.ToChar(input[i] + nvige);
                            }
                            j++;
                        }
                        return output;
                    case 2:
                        j = 0;
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (j > kvige.Length - 1)
                                j = 0;
                            nvige += Convert.ToChar(kvige[j]);//номер элемента в коде utf-16 ключа
                            nvige = 0;

                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if (kvige[j] >= 'a')
                                    nvige += Convert.ToChar(kvige[j] - 'a' + 1);
                                else
                                    nvige += Convert.ToChar(kvige[j] - 'A' + 1);

                                if ((input[i] - nvige) < 'a' && input[i] >= 'a' || (input[i] - nvige) < 'A')
                                    output += Convert.ToChar(input[i] + 26 - nvige);
                                else
                                    output += Convert.ToChar(input[i] - nvige);
                            }
                            else
                            {
                                nvige = 0;
                                if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                    if (kvige[j] >= 'а')
                                        nvige += Convert.ToChar(kvige[j] - 'а' + 1);
                                    else
                                        nvige += Convert.ToChar(kvige[j] - 'А' + 1);
                                if ((input[i] - nvige) < 'а' && input[i] >= 'а' || (input[i] - nvige) < 'А')
                                    output += Convert.ToChar(input[i] + 32 - nvige);
                                else
                                    output += Convert.ToChar(input[i] - nvige);
                            }
                            j++;
                        }
                        return output;
                    default:
                        Console.WriteLine("Получена неизвестная ошибка, программа будет закрыта...");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                }
                return "";
            }
            static string Gronsveld(string input, byte type)
            {
                Console.WriteLine("Gronsfeld");
                Console.ReadKey();
                string output = "";
                int j, key = 0, k = 0, x = 0;
                // k - количество цифр в ключе
                // key - ключ
                Console.Write("Введите ключ: ");
                key = int.Parse(Console.ReadLine());
                int dkey = key;
                while (key != 0)
                {
                    x = key % 10;
                    if (key - x != 0)
                        key = (key - x) / 10;
                    else key -= x;
                    k++;
                }
                key = dkey;
                int[] nvige = new int[k]; // массив цыфр ключа
                for (int i = k - 1; i >= 0; i--)
                {
                    x = key % 10;
                    nvige[i] = x;
                    if (key - x != 0)
                        key = (key - x) / 10;
                    else key -= x;
                }
                switch (type)
                {
                    case 1:
                        j = 0;
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (j > k - 1)
                            {
                                j = 0;
                            }
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if ((input[i] + nvige[j]) > 'z' || (input[i] + nvige[j]) > 'Z' && input[i] <= 'Z')
                                    output += Convert.ToChar(input[i] - 26 + nvige[j]);
                                else
                                    output += Convert.ToChar(input[i] + nvige[j]);
                            }
                            else
                            {
                                if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                    if ((input[i] + nvige[j]) > 'я' || (input[i] + nvige[j]) > 'Я' && input[i] <= 'Я')
                                        output += Convert.ToChar(input[i] - 32 + nvige[j]);
                                    else
                                        output += Convert.ToChar(input[i] + nvige[j]);
                            }
                            j++;
                        }
                        return output;
                    case 2:
                        j = 0;
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (j > k - 1)
                                j = 0;
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if ((input[i] - nvige[j]) < 'a' && input[i] >= 'a' || (input[i] - nvige[j]) < 'A')
                                    output += Convert.ToChar(input[i] + 26 - nvige[j]);
                                else
                                    output += Convert.ToChar(input[i] - nvige[j]);
                            }
                            else
                            {
                                if (input[i] >= 'а' && input[i] <= 'я' || input[i] >= 'А' && input[i] <= 'Я')
                                    if ((input[i] - nvige[j]) < 'а' && input[i] >= 'а' || (input[i] - nvige[j]) < 'А')
                                        output += Convert.ToChar(input[i] + 32 - nvige[j]);
                                    else
                                        output += Convert.ToChar(input[i] - nvige[j]);
                            }
                            j++;
                        }
                        return output;
                    default:
                        Console.WriteLine("Получена неизвестная ошибка, программа будет закрыта...");
                        Console.ReadKey();
                        Environment.Exit(1);
                        break;
                }
                return "";
            }
            static string Jefferson(string input, byte type)
            {
                int keysl = 0;
                string output = "", key = "";
                int j = 0, x = 0, i = 0, k = 0, r = 0, rk = 0;
                Console.WriteLine("Jefferson");
                Console.Clear();
                Console.Write("Хотите насторить?");
                Console.WriteLine("Если да нажмите - y, иначе любую кнопку");
                switch (Console.ReadLine())
                {
                    case "y":
                        fiks();
                        break;
                }
                Console.WriteLine("На сколько сдвигать: ");
                keysl = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.Write("Сдвиг: " + keysl);
                key = File.ReadAllText("jeffdisks.txt");
                char[,] maskey = new char[26, 36];
                while (i <= 1007)
                {
                    j = 0;
                    for (int g = i; g <= i + 25; g++)
                    {
                        maskey[j, x] = (key[g]);
                        j++;
                    }
                    x++;
                    i += 28;
                }
                Console.WriteLine();
                switch (type)
                {
                    case 1:
                        for (i = 0; i < input.Length; i++)
                        {
                            if (j >= 25)
                                j = 0;
                            if (k >= 35)
                                k = 0;
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if (maskey[j, 1] <= 'Z')
                                    for (x = 0; x <= 25; x++)
                                    {
                                        if (maskey[x, k] == input[i] && x + keysl < 26)
                                            output += maskey[x + keysl, k];
                                        if (maskey[x, k] == input[i] && x + keysl >= 26)
                                            output += maskey[x + keysl - 26, k];
                                    }
                            }
                            r++;
                            rk++;
                        }
                        return output;
                    case 2:
                        for (i = 0; i < input.Length; i++)
                        {
                            if (j >= 25)
                                j = 0;
                            if (k >= 35)
                                k = 0;
                            if (input[i] >= 'a' && input[i] <= 'z' || input[i] >= 'A' && input[i] <= 'Z')
                            {
                                if (maskey[j, 1] <= 'Z')
                                    for (x = 0; x <= 25; x++)
                                    {
                                        if (maskey[x, k] == input[i] && x - keysl >= 0)
                                            output += maskey[x - keysl, k];
                                        if (maskey[x, k] == input[i] && x - keysl < 0)
                                            output += maskey[x - keysl + 26, k];
                                    }
                            }
                            j++;
                            k++;

                        }

                        return output;
                }
                return "";
            }
            static void Main(string[] args)
            {
                string str = "";
                string output = "";
                byte type = 0;
                byte flag = 0;
                while (flag == 0)
                {
                    Console.WriteLine("Выберите метод шифровки");
                    Console.WriteLine("1 - алгоритм Цезаря");
                    Console.WriteLine("2 - алгоритм Вернама");
                    Console.WriteLine("3 - Виженера");
                    Console.WriteLine("4 - Гронсфельда");
                    Console.WriteLine("5 - Джефферсона");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            flag++;
                            type = Choose();
                            str = Input();
                            Console.Clear();
                            Console.Write("Текст: ");
                            Console.WriteLine(str);
                            output = Caesar(str, type);
                            break;
                        case "2":
                            flag++;
                            type = Choose();
                            Verrnam(type);
                            break;
                        case "3":
                            flag++;
                            type = Choose();
                            str = Input();
                            output = Vigenere(str, type);
                            break;
                        case "4":
                            flag++;
                            type = Choose();
                            str = Input();
                            output = Gronsveld(str, type);
                            break;
                        case "5":
                            flag++;
                            type = Choose();
                            str = Input();
                            output = Jefferson(str, type);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("404 not Found");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                Console.Clear();
                File.WriteAllText("output.txt", output);
                Console.WriteLine("Зашифрованная строка:");
                Console.WriteLine();
                Console.Write(output);
                Console.ReadKey();
            }
        }
    }
}
