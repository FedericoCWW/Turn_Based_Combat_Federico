using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TurnBasedCombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Clase Random para generar numeros aleatorios
            Random rng = new Random();
            Console.Title = "Turn based Combat";
            Console.Write("Hay 3 clases (ingrese cualquier otra tecla para salir del programa):\n - g = Guerrero \n - m = Mago \n - p = Paladin \nElige tu clase: ");
            // 3 clases basicas: Guerrero, Mago, Paladin.
            char text = Convert.ToChar(Console.ReadLine());
            // con un switch establezco la clase Player para el jugador, la maquina usa valores randoms.
            Player player = new Player();
            switch (text)
            {
                case 'g':
                    player.Name = "Guerrero";
                    player.Attack = 20;
                    player.Defense = 5;
                    player.HitPoints = 50;
                    break;
                case 'm':
                    player.Name = "Mago";
                    player.Attack = 10;
                    player.Defense = 10;
                    player.HitPoints = 30;
                    break;
                case 'p':
                    player.Name = "Paladin";
                    player.Attack = 12;
                    player.Defense = 7;
                    player.HitPoints = 65;
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            Console.WriteLine($"Elegiste la clase: {player.Name}");
            Player enemy = new Player();
            CrearEnemigo(enemy, rng);          //funcion para crear enemigo
            while (player.HitPoints > 0 && enemy.HitPoints > 0)
            {
                // el campo isdefending se resetea cada turno (isDefending = false).
                player.isDefending = enemy.isDefending = false;
                Console.WriteLine(player.ToString());
                Console.WriteLine("//////////////////////////////////////////////");
                Console.WriteLine(enemy.ToString());
                //Turno jugador
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Turno del jugador");
                Console.ResetColor();
                Console.WriteLine("ingrese 'a' para atacar o 'd' para defender:");
                char choice = Convert.ToChar(Console.ReadLine());
                if (choice == 'a')
                {
                    //funcion para atacar
                    TurnoAtaque(player, enemy);
                }
                else
                {
                    //funcion para defenderse
                    TurnoDefensa(player);
                }
                //Thread.Sleep(1000);
                //turno Enemigo
                if (enemy.HitPoints > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Turno del enemigo");
                    Console.ResetColor();
                    int enemy_choice = rng.Next(0,2);
                    //0 = Ataca ; 1 = Defiende
                    if (enemy_choice == 0)
                    {
                        //ataque enemigo
                        TurnoAtaque(enemy, player);
                    }
                    else
                    {
                        //defiende enemigo
                        TurnoDefensa(enemy);
                    }
                }
            }
            Console.WriteLine(player.ToString());
            Console.WriteLine("//////////////////////////////////////////////");
            Console.WriteLine(enemy.ToString());
            if (player.HitPoints < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Perdiste el juego");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ganaste el juego");
            }
        }
        static void CrearEnemigo(Player enemigo, Random rng) 
        {
            enemigo.Name = "Enemigo";
            enemigo.Attack = rng.Next(10, 21);
            enemigo.Defense = rng.Next(2, 11);
            enemigo.HitPoints = rng.Next(10, 21) * 2;
        }
        static void TurnoAtaque(Player atacante, Player recibidor)
        {
            int ataque = atacante.Attack;
            if (recibidor.isDefending == true)
            {
                ataque -= recibidor.Defense;
                recibidor.isDefending = false;
            }
            recibidor.HitPoints -= ataque;
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"{atacante.Name} ataco a {recibidor.Name} y recibio {ataque} de daño");
            Console.ResetColor();
        }
        static void TurnoDefensa(Player defensor)
        {
            defensor.isDefending = true;
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine($"El {defensor.Name} se defiende");
            Console.ResetColor();
        }
    }
}
