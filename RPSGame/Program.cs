using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;

namespace RPSGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Because why not?
            SpeechSynthesizer synth = new SpeechSynthesizer();
            

            Console.WriteLine("Player name: ");
            synth.Speak("What is your name?");
            string inputName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Opponent name: ");
            synth.Speak("What is your opponent's name?");
            string oppName = Console.ReadLine();

            Console.Clear();
            Player newPlyr = new Player(inputName);
            Opponent newOpp = new Opponent(oppName);
            bool isRunning = true;

            while (isRunning == true)
            {
                while (newPlyr.IsAlive && newOpp.IsAlive)
                {
                    Console.Clear();
                    for (int i = 1; i < 9; i++)
                    {
                        Console.Clear();
                        Console.WriteLine($"{inputName} vs. {oppName}!");
                        synth.Speak($"{inputName} versus {oppName}!");
                        Console.WriteLine($"Round {i}");
                        synth.Speak($"Round {i}");
                        
                        if (newPlyr.Wins > newOpp.Wins)
                        {
                            Console.WriteLine($"{inputName} leads {newPlyr.Wins} wins to {newOpp.Wins}");
                            synth.Speak($"{inputName} leads {newPlyr.Wins} wins to {newOpp.Wins}");
                        }
                        else if (newOpp.Wins > newPlyr.Wins)
                        {
                            Console.WriteLine($"{oppName} leads {newOpp.Wins} wins to {newPlyr.Wins}");
                            synth.Speak($"{oppName} leads {newOpp.Wins} wins to {newPlyr.Wins}");
                        }
                        else
                        {
                            Console.WriteLine($"It's currently a tie {newPlyr.Wins} wins apiece");
                            synth.Speak($"It's currently a tie {newPlyr.Wins} wins apiece");
                        }

                        Console.WriteLine("Choose your weapon:");
                        synth.Speak($"What'll it be, {inputName}?");
                        Console.Write("0: Rock\n" +
                                      "1: Paper\n" +
                                      "2: Scissors\n");
                        int pChoice = Int32.Parse(Console.ReadLine());
                        Player.Weapon plyrWeapon = (Player.Weapon)pChoice;

                        switch (plyrWeapon)
                        {
                            case Player.Weapon.Rock:
                                if (newOpp.Attack() == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Both players threw rock, it's a tie.");
                                    synth.Speak("Tie.");
                                    Thread.Sleep(3000);
                                    i = i - 1;
                                }
                                else if (newOpp.Attack() == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Paper covers rock, {oppName} wins this round.");
                                    synth.Speak($"{oppName} wins.");
                                    Thread.Sleep(3000);
                                    newOpp.Wins = newOpp.Wins + 1;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Rock smashes scissors, {inputName} wins this round.");
                                    synth.Speak($"{inputName} wins.");
                                    Thread.Sleep(3000);
                                    newPlyr.Wins = newPlyr.Wins + 1;
                                }
                                break;
                            case Player.Weapon.Paper:
                                if (newOpp.Attack() == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Paper covers rock, {inputName} wins this round.");
                                    synth.Speak($"{inputName} wins.");
                                    Thread.Sleep(3000);
                                    newPlyr.Wins = newPlyr.Wins + 1;
                                }
                                else if (newOpp.Attack() == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Both players threw paper, it's a tie.");
                                    synth.Speak("Tie.");
                                    Thread.Sleep(3000);
                                    i = i - 1;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Scissors cuts paper, {oppName} wins this round.");
                                    synth.Speak($"{oppName} wins.");
                                    Thread.Sleep(3000);
                                    newOpp.Wins = newOpp.Wins + 1;
                                }
                                break;
                            case Player.Weapon.Scissors:
                                if (newOpp.Attack() == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Rock smashes scissors, {oppName} wins this round.");
                                    synth.Speak($"{oppName} wins.");
                                    Thread.Sleep(3000);
                                    newOpp.Wins = newOpp.Wins + 1;
                                }
                                else if (newOpp.Attack() == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Scissors cuts paper, {inputName} wins this round.");
                                    synth.Speak($"{inputName} wins.");
                                    Thread.Sleep(3000);
                                    newPlyr.Wins = newPlyr.Wins + 1;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Both players threw scissors, it's a tie.");
                                    synth.Speak("Tie.");
                                    Thread.Sleep(3000);
                                    i = i - 1;
                                }
                                break;
                        }

                        if (newPlyr.Wins == 4)
                        {
                            Console.WriteLine($"{inputName} has reached {newPlyr.Wins} wins, {inputName} wins!");
                            synth.Speak($"{inputName} wins. Game over.");
                            Thread.Sleep(3000);
                            newOpp.IsAlive = false;
                            break;
                        }
                        else if (newOpp.Wins == 4)
                        {
                            Console.WriteLine($"{oppName} has reached {newOpp.Wins} wins, {oppName} wins!");
                            synth.Speak($"{oppName} wins. Game over.");
                            Thread.Sleep(3000);
                            newPlyr.IsAlive = false;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if(newPlyr.Wins == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"GAME OVER. {inputName} wins {newPlyr.Wins} to {newOpp.Wins}.");
                    synth.Speak($"GAME OVER. {inputName} wins {newPlyr.Wins} to {newOpp.Wins}.");
                    Thread.Sleep(10000);
                    isRunning = false;
                }
                else if(newOpp.Wins == 4)
                {
                    Console.Clear();
                    Console.WriteLine($"GAME OVER. {oppName} wins {newOpp.Wins} to {newPlyr.Wins}.");
                    synth.Speak($"GAME OVER. {oppName} wins {newOpp.Wins} to {newPlyr.Wins}.");
                    Thread.Sleep(10000);
                    isRunning = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("BUG!");
                    synth.Speak("How did you even get here? You're not supposed to be here!");
                    Thread.Sleep(10000);
                    isRunning = false;
                }
            }
            Console.ReadLine();
        }
    }
}
