using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkBot.Commands;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkBot.Messages
{
    public class Trigger
    {
        public static List<string[]> Triggers = new List<string[]>()
            {
                Hello,
                Buy
            };

        public static string[] Hello = new string[]
            {
            "привет",
            "салют",
            "шалом",
            "здарова",
            "дороу",
            "здравствуйте",
            };

        public static string[] Order = new string[]
            {
                "заказать",
                "сделать"
            };

        public static string[] Buy = new string[]
            {
                "купить",
                "приобрести",
                "использовать"
            };
    }
    public class MessageResponser
    {
        public MessageResponser(Message message)
        {
            bool answered = false;

            foreach (var i in Trigger.Hello)
            {
                if (message.Text.ToLower().Contains(i))
                {
                    Bot.Send(message.PeerId.Value, "Салют, братишка!\n\n" +
                       "Чем могу помочь?");

                    answered = true;
                }
            }

            foreach (var i in Trigger.Buy)
            {
                if (message.Text.ToLower().Contains(i))
                {
                    Bot.Send(message.PeerId.Value, "Для покупки ты можешь обратиться к самому автору битов - https://vk.com/lefiee\n\n" +
                       "Или же ты можешь написать менеджеру проекта - https://vk.com/fuck_your_m0ther\n\n");

                    answered = true;
                }
            }

            foreach (var i in Trigger.Order)
            {
                if (message.Text.ToLower().Contains(i))
                {
                    Bot.Send(message.PeerId.Value, "Если ты хочешь заказать бит, то, пожалуйста, опиши каким ты хочешь его услышать." +
                        "\n\nПример:\n\n" +
                        "Жанр: Rap\n" +
                        "BPM: 140\n" +
                        "Интсрументал: пианино, флейта\n" +
                        "и т.д\n\n" +
                        "Как битмейкер приступит к работе я тебя обязательно оповещу.");

                    answered = true;
                }
            }

            if (message.Attachments.Count > 0)
            {
                var attach = message.Attachments;

                foreach (var item in attach)
                {
                    Bot.Send(message.PeerId.Value, "Хочешь купить данный бит?");

                    answered = true;
                }
            }

            if (!answered)
            {
                Bot.Send(message.PeerId.Value, "Бро, я всего лишь бот, и только появился на этот полный рэперов свет, так что если я тебе не смог помочь, то обратись, пожалуйста, к моим друзьям\n\n" +
                    "Автор битов - https://vk.com/lefiee\n" +
                    "или\n" +
                    "Менеджер проекта - https://vk.com/fuck_your_m0ther\n\n");
            }
        }
    }
}
