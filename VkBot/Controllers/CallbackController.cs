using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using VkBot.Commands;
using VkBot.Messages;
using VkNet;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
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
            _vkApi = new VkApi();

            _vkApi.Authorize(new ApiAuthParams()
            {
                AccessToken = _configuration["Config:AccessToken"],
                Settings = Settings.All,
            });

            Bot.VkApi = _vkApi;
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
                    Message msg = Message.FromJson(new VkResponse(updates.Object));

                    MessageResponser message = new MessageResponser(msg);
                       
                    break;
                }
            }

            return Ok("ok");
        }
    }
}
