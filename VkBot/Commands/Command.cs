using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VkNet.Abstractions;

namespace VkBot.Commands
{
    public interface Command
    {
        string Name { get; set; }
        string Text { get; set; }
        object Data { get; set; }
    }
}
