using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet;
using VkNet.Abstractions;

namespace VkBot.Commands
{
    public static class Bot
    {
        public static IVkApi VkApi;

        private static readonly Random _random = new Random();
        public static void Send(long id, string text)
        {
            VkApi.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams()
            {
                RandomId = _random.Next(int.MinValue, int.MaxValue),
                PeerId = id,
                Message = text
            });
        }
    }
}
