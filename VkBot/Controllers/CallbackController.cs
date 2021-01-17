using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase
    {
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        private readonly IConfiguration _configuration;
        private readonly IVkApi _vkApi;
        private readonly Random _random;
        public CallbackController(IConfiguration configuration)
        {
            _configuration = configuration;
            _random = new Random();
        }


        [HttpPost]
        public IActionResult Callback([FromBody] Updates updates)
        {
            // Тип события
            switch (updates.Type)
            {
                // Ключ-подтверждение
                case "confirmation":
                {
                    return Ok(_configuration["Config:Confirmation"]);
                }

                // Новое сообщение
                case "message_new":
                {
                    // Десериализация
                    var msg = Message.FromJson(new VkResponse(updates.Object));


                        _vkApi.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams()
                        {
                            RandomId = _random.Next(int.MinValue, int.MaxValue),
                            PeerId = msg.PeerId.Value,
                            Message = "Отъебись"
                        });
                    break;
                }
            }

            return Ok("ok");
        }
    }
}
