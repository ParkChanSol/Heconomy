﻿
/*
    ooooo   ooooo                     .o8        .ooooo.   
    `888'   `888'                    "888       888' `Y88. 
     888     888   .ooooo.  oooo d8b  888oooo.  888    888 
     888ooooo888  d88' `88b `888""8P  d88' `88b  `Vbood888 
     888     888  888ooo888  888      888   888       888' 
     888     888  888    .o  888      888   888     .88P'  
    o888o   o888o `Y8bod8P' d888b     `Y8bod8P'   .oP'     

    Directed by Herb9.
*/

using MiNET;
using MiNET.Plugins.Attributes;

namespace HeconomyAPI.Command
{

    public class Money
    {

        protected HeconomyAPI Plugin { get; set; }

        public Money(HeconomyAPI plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "money", Description = "Shows your money amount.", Permission = "heconomyapi.command.money")]
        public void execute(Player sender)
        {
            int amount = Plugin.GetMoney(sender.Username);

            string symbol = Plugin.GetMoneySymbol();

            sender.SendMessage(HeconomyAPI.Prefix + $" Your money amount: {amount}{symbol}");
        }
    }
}
