﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJ
{
    class NewRound
    {
        private Disrtibution disrtibution = new Disrtibution();
       
        public void StartTheGame()
        {
            Console.WriteLine("G'day! Let's begin? y/n");
            if (Console.ReadLine() == "y")
            {
                InitiateNewRound();
            }
        }

        public void InitiateNewRound()
        {           
            disrtibution.Start(out ICharacter player, out ICharacter bot);
            CheckMoneyAmount(player, bot);
            //AskForNewRound();
        }
       
        private void AskForNewRound()
        {
            Console.WriteLine("One more round? y/n");
            if (Console.ReadLine() == "y")
            {
                this.InitiateNewRound();
                return;
            }
            Console.WriteLine("Thanks for the game");
            Console.ReadKey();
        }
        
        private void CheckMoneyAmount(ICharacter player, ICharacter bot)
        {
            if (player.Money < 19)
            {
                Console.WriteLine("Player lost");
                return;
            }

            if (bot.Money < 19)
            {
                Console.WriteLine("Player won");
                return;
            }
            AskForNewRound();
        }
    }
}