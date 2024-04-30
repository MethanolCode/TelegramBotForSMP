using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotForSMP
{
    class Program
    {
        public static Dictionary<string, string> Rus = new Dictionary<string, string>()
        {
            {"about", "О программе."},
            {"start_err", "Проблемы с запуском приложения."},
            {"play_err", "Проблемы с воспроизведением."},
            {"localization_err", "Проблемы с локализацией."},
            {"drop_err", "Приложение вылетает во времы работы."},
            {"app_style", "Внешний вид и стиль приложения."},
            {"sponsor", "Желаете внести свой вклад в разработку?"},
            {"set_lang", "Выбор языка"},
            {"h_err", "Команда /h использована неверно"},
            {"about_text", "О программе:\nSimpleMediaPayer (SMP) - простой медиапроигрыватель, написанный на С# WPF. " +
                            "Приложение имет русскую и английскую локализации, простой дизайн и базовый набор настроек воспроизведения." +
                            "На данный момент имеются проблемы с воспроизведением некоторых медиа форматов, но в будущем проблема будет решена.\n" +
                            "Последняя версия программы: v0.4.11\n" +
                            "Разработчик: Methanol\n" +
                            "Дата последнего обновления: 28.04.2024"},
            {"start_text", "Добрый день, вас приветствует бот техподдержки приложения SimpleMediaPlayer (v.1.0.00)\n" +
                        "Чтобы понять с чем вам нужна помощь, вы можете выбрать один из перечисленных ниже пунктов или воспользоваться меню.\n" +
                        "1) О программе.\n" +
                        "2) Проблемы с запуском приложения.\n" +
                        "3) Проблемы с воспроизведением.\n" +
                        "4) Проблемы с локализацией.\n" +
                        "5) Приложение вылетает во времы работы.\n" +
                        "6) Внешний вид и стиль приложения.\n" +
                        "7) Желаете внести свой вклад в разработку?\n" +
                        "8) Выбор языка\n" +
                        "Для выбора отправьте команду в формате /h 'номер пункта'."},
            {"sponsor_text", "Хотите поддержать проект? Вы можете сделать это звонкой монетой на счет разработчика или с помощью форка проекта на GitHub."},
            {"sponsor_give_money", "Дам денег"},
            {"sponsor_give_code", "Денег нет, давай код писать"},
            {"use_keyboard", "Пожалуйста, используйте клавиатуру правильно..."},
            {"understanding", "К сожалению, я вас не понимаю, для начала беседы отправьте команду /start"},
            {"money_hehehe", "Пришлите денег по номеру телефона, но его нужно найти. Если вы действительно хотите " +
                "поддержать автора, это маленькое недоразумение не сможет помешать"},
            {"start_err_text", "Если приложение не запускается или пытается запуститься, но тут же вылетает без объяснения причин - дело плохо." +
                "Для начала стоит сказать что приложение написано на WPF и не годится для запуска нигде, кроме как на Windows 10/11, а по системным требованиям" +
                "подойдет все что хоть чуть-чуть мощнее калькулятора. Также на устройстве должны находиться пакеты .NET (по умолчанию). Пока что в проете нет логирования и нельзя посмотреть необработанные ошибки."},
            {"play_err_text", "Во время воспроизведения видео вам могут повстречаться ошибки или недоработки. Можете написать разработчику (link)," +
                " но это делу не поможет.\nИтак, основные проблемы на текущий момент:\n1) Аудио/Видео не запускается из-за неподдерживаемого формата.\n" +
                "2) После паузы и запуска медиа не продолжается - рекомендуется перезагрузить его.\n" +
                "3) В старых версиях при определенных действиях пару раз встречались утечки памяти, есть небольшой шанс их обнаружения в новой версии...\n" +
                "Других ошибок воспроизведения (пока что) обнаружено не было"},
            {"localization_err_text", "В приложении локализация представлена двумя языками: Русским (ru-RU) и Английским (en-US). Ранее перевод был реализован другим методом," +
                " поэтому переносе могли возникнуть ошибки или недоделки. Итак, нынешний перевод хранит все строки в resx и по умолчанию мы можем динамически изменять интерфейс" +
                "(в отличии от XAML реализации), поэтому приложение перезапускается с новой локализацией. Плюсом такого методда стало то что при перезапуске приложения" +
                "сохраняется выбор языка из предыдущего сеанса. По недочетам/недопереводам пишите автору (link)."},
            {"drop_err_text", "Оно не вылетает...Оно может не работать, но точно не вылетает..."},
            {"app_style_text", "На данный момент стиль приложения один и не изменяется. Позже будет реализована поддержка как нескольких стандартных, так и пользовательских стилей."},
            {"set_lang_text", "Выберите язык в меню клавиатуры..."},
            {"", ""},
        };
        public static Dictionary<string, string> En = new Dictionary<string, string>()
        {
            {"about", "About."},
            {"start_err", "Problems starting the application."},
            {"play_err", "Playback problems."},
            {"localization_err", "Localization problems."},
            {"drop_err", "The application crashes while running."},
            {"app_style", "Appearance and style of the app."},
            {"sponsor", "Would you like to contribute to the development?"},
            {"set_lang", "Language"},
            {"h_err", "The /h command was used incorrectly"},
            {"about_text", "About the program:\n Simple Media Player (SMP) is a simple media player written in C# WPF. " +
                "The application has Russian and English localization, a simple design and a basic set of playback settings." +
                "At the moment there are problems with playing some media formats, but in the future the problem will be solved.\n"+
                "Latest version of the program: v0.4.11\n"+
                "Developer: Methanol\n" +
                "Last update date: 04/28/2024"},
            {"start_text", "Good afternoon, you are welcomed by the technical support bot of the Simple Media Player application (v.1.00)\n"+
                " To understand what you need help with, you can select one of the items listed below or use the menu.\n"+
                "1) About the program.\n" +
                "2) Problems with launching the application.\n" +
                "3) Playback problems.\n" +
                "4) Localization issues.\n" +
                "5) The application crashes during operation.\n" +
                "6) The appearance and style of the application.\n" +
                "7) Would you like to contribute to the development?" + 
                "8) Language selection \n"+
                "To select, send a command in the format /h 'item number'."},
            {"sponsor_text", "Do you want to support the project? You can do this in hard cash to the developer's account or by using a fork of the project on GitHub."},
            {"sponsor_give_money", "I'll give you money"},
            {"sponsor_give_code", "No money, let's write the code"},
            {"use_keyboard", "Please use the keyboard correctly..."},
            {"understanding", "Unfortunately, I don't understand you, send the /start command to start the conversation"},
            {"money_hehehe", "Send money by phone number, but you need to find it. If you really want to support the author, this little misunderstanding will not be able to prevent"},
            {"start_err_text", "If the application does not start or tries to start, but immediately crashes without explanation, it's bad." +
                "To begin with, it's worth saying that the application is written in WPF and is not suitable to run anywhere except on Windows 10/11, and according to the system requirements " +
                " anything will do at least a little more powerful than a calculator. There should also be packages on the device.NET (by default). So far, there is no logging in the project and it is impossible to view the raw errors."},
            {"play_err_text", "You may encounter errors or flaws while playing the video. You can write to the developer (link ), " +
                " but that won't help the case.\nSo, the main problems at the moment:\n1) Audio/The video does not start due to an unsupported format.\n"+
                "2) After pausing and starting, the media does not continue - it is recommended to restart it.\n"+
                "3) In older versions, memory leaks occurred a couple of times with certain actions, there is a small chance of their detection in the new version...\n" +
                "No other playback errors have been detected (so far)"},
            {"localization_err_text", "In the application, localization is represented by two languages: Russian (ru-RU) and English (en-US). Previously, the translation was implemented using a different method, " +
                ", so errors or imperfections could occur during the transfer. So, the current translation stores all lines in resx and by default we can dynamically change the interface " +
                " (unlike the XAML implementation), so the application is restarted with a new localization. The advantage of this method is that when restarting the application" +
                "the language selection from the previous session is saved. If there are any shortcomings / misunderstandings, write to the author (link)."},
            {"drop_err_text", "Оно не вылетает...Оно может не работать, но точно не вылетает..."},
            {"app_style_text", "At the moment, the style of the application is the same and does not change. Later, support for both several standard and custom styles will be implemented."},
            {"set_lang_text", "Select a language from the keyboard menu..."},
            {"", ""},
        };
        public static Dictionary<string, string> Cur = new Dictionary<string, string>();

        public static TelegramBotClient bot = new TelegramBotClient("");

        static void Main(string[] args)
        {
            Console.WriteLine("BOT IS ALIVE...");
            ChangeLangRu();
            new Program().Run();
            while (true) { }
        }

        public static void ChangeLangRu() => Cur = Rus;

        public static void ChangeLangEn() => Cur = En;
        private void Run()
        {
            bot.StartReceiving();
            bot.OnMessage += Bot_OnMessage;
        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var markup_base = new ReplyKeyboardMarkup();
            markup_base.Keyboard = new KeyboardButton[][]
            {
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["about"])},
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["start_err"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["play_err"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["localization_err"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["drop_err"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["app_style"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["sponsor"]) },
                            new KeyboardButton[]{new KeyboardButton("/hlp " + Cur["set_lang"]) },
            };
            markup_base.OneTimeKeyboard = true;
            try
            {
                if (e.Message.Text == "/start" || e.Message.Text == "/старт") bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["start_text"], replyMarkup: markup_base);
                else if (e.Message.Text.Contains("/hlp"))
                {
                    if (e.Message.Text.Split(' ').Length == 1)
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["h_err"]);
                        return;
                    }
                    var temp = e.Message.Text.Trim(new char[] { '/', 'h', 'l', 'p', ' '});
                    Console.WriteLine(temp.ToString());
                    if (temp == "1" || temp == Cur["about"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["about_text"], replyMarkup: markup_base);
                    else if (temp == "2" || temp == Cur["start_err"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["start_err_text"], replyMarkup: markup_base);
                    else if (temp == "3" || temp == Cur["play_err"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["play_err_text"], replyMarkup: markup_base);
                    else if (temp == "4" || temp == Cur["localization_err"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["localization_err_text"], replyMarkup: markup_base);
                    else if (temp == "5" || temp == Cur["drop_err"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["drop_err_text"], replyMarkup: markup_base);
                    else if (temp == "6" || temp == Cur["app_style"]) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["app_style_text"], replyMarkup: markup_base);
                    else if (temp == "7" || temp == Cur["sponsor"])
                    {
                        var markup = new ReplyKeyboardMarkup();
                        markup.Keyboard = new KeyboardButton[][]
                        {
                            new KeyboardButton[]{new KeyboardButton(Cur["sponsor_give_money"])},
                            new KeyboardButton[]{new KeyboardButton(Cur["sponsor_give_code"])},
                        };
                        markup.OneTimeKeyboard = true;
                        markup.ResizeKeyboard = true;
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["sponsor_text"], replyMarkup: markup);
                    }
                    else if (temp == "8" || temp == Cur["set_lang"])
                    {
                        var markup = new ReplyKeyboardMarkup();
                        markup.Keyboard = new KeyboardButton[][]
                        {
                            new KeyboardButton[]{new KeyboardButton("/set_eng")},
                            new KeyboardButton[]{new KeyboardButton("/set_rus")},
                        };
                        bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["set_lang_text"], replyMarkup: markup);
                    }
                    else { bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["use_keyboard"]); return; }
                }
                else if (e.Message.Text.Contains(Cur["sponsor_give_money"])) bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["money_hehehe"]);
                else if (e.Message.Text.Contains(Cur["sponsor_give_code"])) bot.SendTextMessageAsync(e.Message.Chat.Id, "Ну код так код...\nhttps://github.com/MethanolCode/SimpleMediaPlayer");
                else if (e.Message.Text.Contains("/set_eng")) ChangeLangEn();
                else if (e.Message.Text.Contains("/set_rus")) ChangeLangRu();
                else bot.SendTextMessageAsync(e.Message.Chat.Id, Cur["understanding"]);
            }
            catch (Exception ex)
            {
                bot.SendTextMessageAsync(e.Message.Chat.Id, "ERROR\nERR_CODE: " + ex.Message, replyMarkup: new ReplyKeyboardRemove());
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
