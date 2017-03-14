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
using MiNET.Utils;

namespace HeconomyAPI.Command
{

    public class Pay
    {

        private HeconomyAPI Plugin;

        public Pay(HeconomyAPI plugin)
        {
            Plugin = plugin;
        }

        [Command(Name = "pay", Description = "Pays money to player.", Permission = "heconomyapi.command.pay")]
        public void Execute(Player sender)
        {
            sender.SendMessage(ChatColors.Green + "Usage: /pay <player: string> <amount: int>");
        }

        [Command(Name = "pay", Description = "Pays money to player.", Permission = "heconomyapi.command.pay")]
        public void Execute(Player sender, string player)
        {
            sender.SendMessage(ChatColors.Green + "Usage: /pay <player: string> <amount: int>");
        }

        [Command(Name = "pay", Description = "Pays money to player.", Permission = "heconomyapi.command.pay")]
        public void Execute(Player sender, string player, int amount)
        {
            string symbol = Plugin.GetMoneySymbol();

            int minimum = Plugin.GetMinimumMoney();

            if((!Plugin.IsRegisteredPlayer(player)) || (Plugin.GetPlayer(player, sender.Level) == null))
            {
                sender.SendMessage(ChatColors.Red + "Invaild player.");
            }
            else if((amount <= minimum) || (amount > Plugin.GetMoney(sender.Username)))
            {
                sender.SendMessage(ChatColors.Red + "Not enough money.");
            }
            else
            {
                Player receiver = Plugin.GetPlayer(player, sender.Level);

                Plugin.SetMoney(sender.Username, Plugin.GetMoney(sender.Username) - amount);
                Plugin.SetMoney(receiver.Username, Plugin.GetMoney(receiver.Username) + amount);

                sender.SendMessage(ChatColors.Blue + "You paid " + amount + symbol + " to " + receiver.Username + ".");

                receiver.SendMessage(ChatColors.Blue + "You have received " + amount + symbol + " from " + sender.Username + ".");
            }
        }
    }
}
