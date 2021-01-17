using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkBot.Commands;
using VkNet.Model;

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
            foreach (var i in Trigger.Hello)
            {
                if (message.Text.ToLower().Contains(i))
                {
                    Bot.Send(message.PeerId.Value, "Салют, братишка!\n\n" +
                       "Чем могу помочь?");
                }
            }

            foreach (var i in Trigger.Buy)
            {
                if (message.Text.ToLower().Contains(i))
                {
                    Bot.Send(message.PeerId.Value, "Для покупки ты можешь обратиться к самому автору битов - https://vk.com/lefiee\n\n" +
                       "Или же ты можешь написать менеджеру проекта - https://vk.com/fuck_your_m0ther\n\n");
                }
            }
        }
    }
}
