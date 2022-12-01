using System.Globalization;

namespace скоропечатанье
{
    internal class Program
    {
        static void Main(string[] args)
        {
            account();

        }
        static void account()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.Clear();
            test();
        }
        static List<char> test()
        {
            Console.Clear();
            List<string> texts = new List<string>() { "Великий русский писатель, драматург, публицист, граф Лев Николаевич Толстой родился 9 сентября (28 августа по старому стилю) 1828 года в имении Ясная Поляна Крапивенского уезда Тульской губернии (ныне Щекинского района Тульской области) в одном из самых знатных русских дворянских семейств. Он был четвертым ребенком в семье. Детство будущего писателя прошло в Ясной Поляне. Он рано осиротел, потеряв сначала мать, которая умерла, когда мальчику было два года, а затем и отца.В 1837 году семья переехала из Ясной Поляны в Москву. Опекуншей осиротевших детей стала их тетка, сестра отца Александра Ильинична Остен-Сакен. В 1841 году, после ее смерти, юный Толстой с сестрой и тремя братьями переехал в Казань, где жила другая тетка - Пелагея Ильинична Юшкова, ставшая их опекуншей.", "В октябре 1805 года русские войска занимали села и города эрцгерцогства Австрийского, и еще новые полки приходили из России, и, отягощая постоем жителей, располагались у крепости Браунау. В Браунау была главная квартира главнокомандующего Кутузова.\r\n11-го октября 1805 года один из только что пришедших к Браунау пехотных полков, ожидая смотра главнокомандующего, стоял в полумиле от города. Несмотря на нерусскую местность и обстановку: фруктовые сады, каменные ограды, черепичные крыши, горы, видневшиеся вдали, — на нерусский народ, с любопытством смотревший на солдат, — полк имел точно такой же вид, какой имел всякий русский полк, готовившийся к смотру где-нибудь в середине России.\r\nС вечера, на последнем переходе, был получен приказ, что главнокомандующий будет смотреть полк на походе. Хотя слова приказа и показались неясны полковому командиру и возник вопрос, как разуметь слова приказа: в походной форме или нет? — в совете батальонных командиров было решено представить полк в парадной форме на том основании, что всегда лучше перекланяться, чем недокланяться." };
            List<char> text = new List<char>();
            foreach (char i in texts[new Random().Next(0, 2)])
            {
                text.Add(i);
            }
            foreach (char i in text)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Для начала теста нажмите Space");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar)
            {
                sam_test(text);
            }
            return text;
        }

        static void sam_test(List<char> text)
        {
            Thread zazaza = new Thread(_ =>
            {
                int left_position = 0;
                int top_position = 0;
                foreach (char i in text)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    Console.SetCursorPosition(left_position, top_position);
                    Console.Write(i);
                    if (key.KeyChar == i)
                    {
                        if (key.Key != ConsoleKey.Enter)
                        {
                            left_position++;
                        }
                        if (key.Key == ConsoleKey.Enter)
                        {
                            top_position++;
                        }
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(key.KeyChar);
                    }
                    if (key.KeyChar != i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(key.KeyChar);
                        Thread.Sleep(Timeout.Infinite);
                        if (key.KeyChar == i)
                        {
                            Thread.ResetAbort();
                        }
                    }
                }
            });
            Thread timer = new Thread(_ =>
            {
                int time = 60;
                while (time != 0)
                {
                    {
                        Thread.Sleep(1000);
                        time--;
                        Console.SetCursorPosition(100, 20);
                        Console.WriteLine("Таймер:  " + time);
                    }
                }
            });
            timer.Start();
            Thread.Sleep(10);
            zazaza.Start();

        }
        
        
    }
}