using System;
using TDAventure.Properties;

namespace TDAventure
{
    internal class Program
    {
        public static int lifepoint = 3;
        public static String adventurer;
        public static String[] inventory = new String[2];
        public static bool goUp = false;

        static void setName()
        {
            Console.WriteLine("Bienvenue jeune aventurier, quel est votre nom ?");
            adventurer = Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            Function.ShowTitle();
            String direction, retry;
            setName();
            Function.start();
            Start:
            direction = Function.forest(); // Forêt (départ)
           if (direction == "g") // Direction => Clairière 
           {
               direction = Function.glade(); // Clairière
               if (direction == "c") // Direction => Chateau
               {
                   direction = Function.castle(); // Chateau 
                   if (direction == "p") // Direction => Porte
                   {
                       Console.WriteLine("Vous tombez nez-à-nez avec un garde, celui-ci vous attaque ! ");
                       Function.setLifePoint(3);
                       Console.WriteLine("Vous etes à " + lifepoint + "PV");
                       Console.WriteLine("Game Over !");
                   }else
                   {
                       direction = Function.corridor();
                       if (direction == "d")
                       {
                           Console.WriteLine("Félicitations vous avez trouvé la princesse ! ");
                       }
                       else
                       {
                           Console.WriteLine("Vous tombez nez à nez avec un garde, celui-ci vous attaque !");
                           Function.setLifePoint(3);
                           Console.WriteLine("Game Over !");
                       }
                   }
               }
               else
               {
                   Function.randEncounter();
                   if(lifepoint > 0){
                        direction = Function.castle();
                        if ((direction == "p") && (inventory[0] == "épée"))
                        {
                           Console.WriteLine("Vous vous trouvez face à face avec un garde, vous l'attaquez !");
                           Function.randFight();
                            if (lifepoint > 0)
                            {
                                direction = Function.corridor();
                                if (direction == "d")
                                {
                                    Console.WriteLine("Félicitations vous avez trouvé la princesse ! ");
                                }
                                else if ((direction == "g") && (inventory[0] == "épée"))
                                {
                                    Console.WriteLine("Vous tombez nez à nez avec un garde, celui-ci vous attaque !");
                                    Function.randFight();
                                    if (lifepoint > 0)
                                    {
                                        Console.WriteLine("Vous revenez sur vos pas et ouvrez l'autre porte.");
                                        Console.WriteLine("Félicitations ! Vous avez trouvé la princesse !");
                                    }
                                }
                            }
                        }
                        else
                        {
                            direction = Function.corridor();
                            if (direction == "d")
                            {
                                Console.WriteLine("Félicitations vous avez trouvé la princesse ! ");
                            }
                            else if ((direction == "g") && (inventory[0] == "épée"))
                            {
                                Console.WriteLine("Vous tombez nez à nez avec un garde, celui-ci vous attaque !");
                                Function.randFight();
                                if (lifepoint > 0)
                                {
                                    Console.WriteLine("Vous revenez sur vos pas et ouvrez l'autre porte.");
                                    Console.WriteLine("Félicitations ! Vous avez trouvé la princesse !");
                                }
                            }
                        }
                   }
                   else
                   {
                       Console.ReadKey();
                   }
               }
           }
           else
           {
               Console.WriteLine("Vous chutez dans un ravin, vous perdez 1 points de vie ! ");
               Function.setLifePoint(1);
               Console.WriteLine("Souhaitez-vous essayer de remonter ? input : (o|n)"); 
               direction = Console.ReadLine();
               if (direction == "o")
               {
                   while (goUp == false)
                   {
                       goUp = false;
                       Random r = new Random();
                       int rand = r.Next(1, 13);
                       if (rand <= 3)
                       {
                           
                           Console.WriteLine("Vous ne réussissez pas à remonter le ravin...");
                           Console.WriteLine("Vous perdez 1 PV !");
                           Function.setLifePoint(1);
                           Console.WriteLine("Voulez-vous retenter votre chance ? (o|n)");
                           retry = Console.ReadLine();
                           while (retry == "o" && lifepoint > 0)
                           {
                               rand = r.Next(1, 13);
                               if (rand <= 3)
                               {
                                   Console.WriteLine("Vous ne réussissez pas à remonter le ravin...");
                                   Console.WriteLine("Vous perdez 1 PV !, il vous reste "+lifepoint+" PV.");
                                   Function.setLifePoint(1);
                                   Console.WriteLine("Voulez-vous retenter votre chance ? (o|n)");
                                   retry = Console.ReadLine();
                                   
                               }
                           }
                           Console.WriteLine("Vous etes à "+lifepoint+" PV : Game Over !");
                           Console.ReadKey();
                       }
                       else
                       {
                           Console.WriteLine(
                               "Vous réussisez à grimper et vous sortir de là ! Vous rebroussez chemin...");
                           goUp = true;
                           goto Start;
                       }
                   }
               }

           }

        }
    }
}