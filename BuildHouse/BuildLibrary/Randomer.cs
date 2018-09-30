using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildLibrary
{
    internal static class Randomer
    {
        private static Random rand;

        static Randomer()
        {
            rand = new Random();
        }

        public static string RandomName()
        {
            string[] names = {  "Авдей",
                                "Аверкий",
                                "Авксентий",
                                "Агафон",
                                "Александр",
                                "Алексей",
                                "Альберт",
                                "Альвиан",
                                "Анатолий",
                                "Андрей",
                                "Антон",
                                "Антонин",
                                "Анфим",
                                "Аристарх",
                                "Аркадий",
                                "Арсений",
                                "Артём",
                                "Артур",
                                "Архипп",
                                "Афанасий",     "Богдан",
                                                "Борис",    "Вадим",
                                                            "Валентин",
                                                            "Валерий",
                                                            "Валерьян",
                                                            "Варлам",
                                                            "Варфоломей",
                                                            "Василий",
                                                            "Венедикт",
                                                            "Вениамин",
                                                            "Викентий",
                                                            "Викентий",
                                                            "Виктор",
                                                            "Виссарион",
                                                            "Виталий",
                                                            "Владимир",
                                                            "Владислав",
                                                            "Владлен",
                                                            "Влас",
                                                            "Всеволод",
                                                            "Вячеслав",     "Савва",
                                                                            "Савелий",
                                                                            "Самуил",
                                                                            "Святополк",
                                                                            "Севастьян",
                                                                            "Семён",
                                                                            "Сергей",
                                                                            "Сильвестр",
                                                                            "Созон",
                                                                            "Спиридон",
                                                                            "Станислав",
                                                                            "Степан",       "Гавриил",
                                                                                            "Галактион",
                                                                                            "Геннадий",
                                                                                            "Георгий",
                                                                                            "Герасим",
                                                                                            "Герман",
                                                                                            "Глеб",
                                                                                            "Гордей",
                                                                                            "Григорий",     "Даниил",
                                                                                                            "Демид",
                                                                                                            "Демьян",
                                                                                                            "Денис",
                                                                                                            "Дмитрий",
                                                                                                            "Добрыня",
                                                                                                            "Донат",
                                                                                                            "Дорофей",      "Евгений",
                                                                                                                            "Евграф",
                                                                                                                            "Евдоким",
                                                                                                                            "Евсей",
                                                                                                                            "Евстафий",
                                                                                                                            "Егор",
                                                                                                                            "Емельян",
                                                                                                                            "Еремей",
                                                                                                                            "Ермолай",
                                                                                                                            "Ефим",         "Ждан",
                                                                                                                                            "Зиновий",
                                                                                                                                            "Иакинф",
                                                                                                                                            "Иван",
                                                                                                                                            "Игнатий",
                                                                                                                                            "Игорь",
                                                                                                                                            "Иларион",
                                                                                                                                            "Иннокентий",
                                                                                                                                            "Илья",
                                                                                                                                            "Ираклий",
                                                                                                                             "Фаддей",      "Ириней",
                                                                                                                             "Фёдор",
                                                                                                                             "Макар",
                                                                                                                             "Максим",
                                                                                                                             "Марк",
                                                                                                                             "Матвей",
                                                                                                                             "Никита",
                                                                                                                             "Олег",
                                                                                                                             "Николай",
                                                                                                                             "Юрий",
                                                                                                                             "Яков",};
            return names[rand.Next(names.Length)]; 
        }
        
        public static int Next(int maxCount)
        {
            return rand.Next(maxCount);
        }
    }
}