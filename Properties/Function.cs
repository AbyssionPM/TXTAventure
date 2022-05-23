using System;

namespace TDAventure.Properties
{
    public static class Function
    {
        public static void ShowTitle()
        {
            Console.WriteLine(" ________  __    __  ________         ______                                   __                                   ");
            Console.WriteLine("|        \\|  \\  |  \\|        \\       /      \\                                 |  \\                                  ");
            Console.WriteLine(" \\$$$$$$$$| $$  | $$ \\$$$$$$$$      |  $$$$$$\\ __     __   ______   _______  _| $$_    __    __   ______    ______  ");
            Console.WriteLine("   | $$    \\$$\\/  $$   | $$         | $$__| $$|  \\   /  \\ /      \\ |       \\|   $$ \\  |  \\  |  \\ /      \\  /      \\ ");
            Console.WriteLine("   | $$     >$$  $$    | $$         | $$    $$ \\$$\\ /  $$|  $$$$$$\\| $$$$$$$\\\\$$$$$$  | $$  | $$|  $$$$$$\\|  $$$$$$\\");
            Console.WriteLine("   | $$    /  $$$$\\    | $$         | $$$$$$$$  \\$$\\  $$ | $$    $$| $$  | $$ | $$ __ | $$  | $$| $$   \\$$| $$    $$");
            Console.WriteLine("   | $$   |  $$ \\$$\\   | $$         | $$  | $$   \\$$ $$  | $$$$$$$$| $$  | $$ | $$|  \\| $$__/ $$| $$      | $$$$$$$$");
            Console.WriteLine("   | $$   | $$  | $$   | $$         | $$  | $$    \\$$$    \\$$     \\| $$  | $$  \\$$  $$ \\$$    $$| $$       \\$$     \\");
            Console.WriteLine("    \\$$    \\$$   \\$$    \\$$          \\$$   \\$$     \\$      \\$$$$$$$ \\$$   \\$$   \\$$$$   \\$$$$$$  \\$$        \\$$$$$$$");
        }
        public static void setLifePoint(int damage)
        {
            Program.lifepoint -= damage;
        }

        public static void start()
        {
            Console.WriteLine( Program.adventurer+ ". Vous vous trouvez dans une fôret à la recherche de votre bien aimée," +
                              " cette dernière a été capturée par un royaume ennemi." +
                              " Vous disposez de " + Program.lifepoint + " PV.");
        }

        public static String forest()
        {
            String direction;
            Console.WriteLine("Devant vous se présente deux chemins, un allant à droite, un allant à gauche, lequel choisissez-vous ? Input : (g|d)");
            direction = Console.ReadLine();
            return direction;
        }

        public static String glade()
        {
            String direction;
            Console.WriteLine("Vous vous trouvez à présent dans une clairière, un objet brillant attire votre attention." +
                              " désirez-vous aller le voir ou continuer votre chemin ? Input (c|o)");
            direction = Console.ReadLine();
            return direction;
        }

        public static String castle()
        {
            String direction;
            Console.WriteLine("Vous êtes fâce au chateau, devant vous se trouve une porte et une fenêtre, par quelle moyen voulez-vous entrer ? " +
                              " input : (p|f)");
            direction = Console.ReadLine();
            return direction;
        }

        public static String corridor()
        {
            String direction;
            Console.WriteLine("Vous vous trouvez maintenant dans un couloir, deux portes se présentent à vous, une à droite et une à gauche." +
                              " Laquelle décidez-vous d'emprunter ? input : (g|d)");
            direction = Console.ReadLine();
            return direction;
        }

        public static void randEncounter()
        {
            Random r = new Random();
            int rand = r.Next(1, 7);
            if (rand <= 3)
            {
                Console.WriteLine("Vous tombez nez-à-nez avec un monstre !");
                setLifePoint(3);
                Console.WriteLine("Vous etes à  : " + Program.lifepoint + " PV !");
                Console.WriteLine("Game Over !");
            }
            else
            {
                Console.WriteLine("Vous trouvez une épée ! Félicitations !");
                Program.inventory[0] = "épée";
                Console.WriteLine("Vous continuez votre chemin vers le chateau, fier de votre nouvelle acquisition !");
            }
        }

        public static void randFight()
        {
            Random r = new Random();
            int rand = r.Next(1, 7);
            if (rand <= 3)
            {
                Console.WriteLine("Vous gagnez le combat !");
            }
            else
            {
                Console.WriteLine("Le garde est plus entrainé que vous, il vous inflige 3 points de dégats !");
                setLifePoint(3);
                Console.WriteLine("Game Over !");
            }
        }
    }
}