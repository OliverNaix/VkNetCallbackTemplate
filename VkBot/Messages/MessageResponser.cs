using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkBot.Commands;
using VkNet.Model;

namespace VkBot.Messages
{
    public class MessageResponser
    {
        public MessageResponser(Message message)
        {
            if (message.Text.Contains("Привет"))
            {
                Bot.Send(message.PeerId.Value, "Салют, братишка!\n\n" +
                    "Хочешь купить биточек? Ты обратился по адресу!\n\n" +
                    "Для покупки просто отправь название биточка, который хочешь приобрести!");
            }
        }
    }
}
