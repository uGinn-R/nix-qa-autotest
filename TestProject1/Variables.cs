using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;


namespace TestProject1
{
    class Variables
    {
        public Dictionary<string, By> locators = new Dictionary<string, By>()
        {
            { "enterBtn", By.CssSelector(".login>a[href]")},
            { "loginField", By.XPath("//input[@name='username']") },
            { "passwordField", By.XPath("//input[@name='password']") },
            { "loginBtn", By.XPath("//button[@id='loginbtn']") },
            { "hamburgerBtn", By.XPath("//button[@class='hamburger']")},
            { "qaBtn", By.CssSelector(".list-group a[href='https://education.nixsolutions.com/badges/view.php?type=2&id=11']")},
            { "quizLink", By.XPath("//a[@class='list-group-item list-group-item-action  navbar-item' and @href='https://education.nixsolutions.com/course/view.php?id=11']") },
            { "testLink", By.XPath("//li[@class='activity quiz modtype_quiz ']//a")},
            { "startQuizBtn", By.XPath("//div[@class='singlebutton quizstartbuttondiv']//button[@type='submit']") },
            { "nextBtn", By.XPath("//input[@type='submit' and @name='next']")},
            { "correctAnswer", By.XPath($"//div[@class='answer']/div/label[text()=' ANSWER HERE ']")},
            { "processAttemptBtn", By.XPath("//div[@class='singlebutton']//form[@action[contains(.,'processattempt')]]")},
            { "confirmBtn", By.XPath("//input[@id[contains(.,'confirmyes')]]")}
        };

        public Dictionary<string, string> Questions = new Dictionary<string, string>() 
        {
            { "Який з елементів є необов'язковим у запиті HTTP?","тіло повідомлення" },
            { "Що не є характеристикою текстового формату JSON?","підтримує безліч складних типів даних, включаючи зображення, діаграми та інші типи даних" },
            { "Що включає елемент HTML?","Тег, що відкриває, вміст і закриває тег"},
            { "Що таке класи еквівалентності?","набір вхідних (або вихідних) даних ПЗ, які обробляються програмою за одним алгоритмом або призводять до одного результату"},
            { "За допомогою якого тега додаються список?","<li>"},
            { "У якому кодуванні слід зберігати HTML-документ?","UTF-8"},
            { "Визначте вид тестування, спрямований на перевірку змін, зроблених у додатку для підтвердження того факту, що раніше функціональність працює як і раніше.","Regression testing"},
            { "Bug, дефект - це:","невідповідність фактичного результату роботи програми очікуваному"},
            { "Яке твердження правильне?","QA включає QC і тестування"},
            { "Якого типу зв'язку немає в БД?","багато до одного"},
            { "Який із елементів може бути відсутнім в архітектурі клієнт-сервер?","БД"},
            { "Коли потрібно починати писати тестову документацію?","Перед початком тестування"},
            { "Що не є характеристикою мобільного веб-додатку?","можна включити отримання Push-повідомлень"},
            { "Який із наведених дефектів має високий пріоритет та низьку серйозність:","граматична помилка на ім'я компанії"},
            { "На якому з рівнів тестування проводиться перевірка окремих частин вихідного коду і всі знайдені дефекти найчастіше виправляються відразу в коді без занесення їх у систему відстеження помилок?","Unit testing"},
            { "Який із документів найбільш високорівневий?","План тестування"},
            { "Які є підходи до організації інтеграційного тестування?","Bottom up, Top down, Big Bang"},
            { "Що не є властивістю таблиць у реляційних базах даних?","всі значення в межах одного рядка мають один тип"},
            { "У якому форматі задаються параметри відображення тегів, на які впливає CSS?","властивість: значення;"},
            { "Які пункти є характеристиками iOS платформи?","суворі правила відбору додатків для публікації до магазину додатків|висока продуктивність"},
            { "Який із тверджень про якість тестування мобільних додатків є найбільш вірним?","Тестування на базі пристроїв найбільш коректне, тому що надає найреальніші результати"},
            { "Хто розставляє пріоритети при плануванні спринту до Скраму?","Product owner"},
            { "Що не є характеристикою тестування ПЗ?","процес пошуку всіх наявних у продукті дефектів з метою надання інформації про якість продукту замовнику"},
            { "Які основні ролі включає Скрам-команда?","Scrum master, Product owner, Developers team"},
            { "Канбан дошка повинна відображати:","актуальний стан завдань"},
            { "Який вид тестування не є характерним для перевірки web-додатків?","всі види тестування можуть застосовуватись"}
        };

        public readonly string[] Arguments = new string[] { "--incognito" };
        public readonly string Url = "https://education.nixsolutions.com";
        public readonly string TestUrl = $"{Environment.CurrentDirectory}/html/Beginner.html";
        public const string login = "uginn";
        public const string password = "*FAKEPASSWORD*";
    }
}
