using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Heist
{
    class Program
    {
        static void Main (string[] args)
        {
            Bank heistVictim = new Bank() {
                AlarmScore = new Random().Next(100) + 1,
                VaultScore = new Random().Next(100) + 1,
                SecurityGuardScore = new Random().Next(100) + 1,
                CashOnHand = new Random().Next(49999, 1000000) + 1
            };

            Dictionary<string, int> bankRatings = new Dictionary<string, int>();
            bankRatings.Add("Alarm", heistVictim.AlarmScore);
            bankRatings.Add("Vault", heistVictim.VaultScore);
            bankRatings.Add("Security Guards", heistVictim.SecurityGuardScore);
            var sortedBankRatings = bankRatings.OrderBy(pair => pair.Value);
            List<IRobber> crew = new List<IRobber>();


            Hacker CodingWiz = new Hacker
            {
                Name = "Coding Genius",
                SkillLevel = 88,
                PercentageCut = 29,
                id = 1
            };
            Muscle MuscleGuy = new Muscle
            {
                Name = "Max Power",
                SkillLevel = 79,
                PercentageCut = 25,
                id = 2
            };
            LockSpecialist LockGuy = new LockSpecialist
            {
                Name = "Loqq Pickins",
                SkillLevel = 83,
                PercentageCut = 31,
                id = 3
            };
            Hacker OldSchoolHacker = new Hacker
            {
                Name = "Old School Hacker",
                SkillLevel = 55,
                PercentageCut = 5,
                id = 4
            };
            Muscle MentallyTough = new Muscle
            {
                Name = "Not Really All That Tough But Thinks He Is",
                SkillLevel = 22,
                PercentageCut = 65,
                id = 5
            };
            LockSpecialist MacGyver = new LockSpecialist
            {
                Name = "Fuckin MacGyver Dude",
                SkillLevel = 99,
                PercentageCut = 69,
                id = 6
            };
            List<IRobber> rolodex = new List<IRobber>() {
                CodingWiz, MuscleGuy, LockGuy, OldSchoolHacker, MentallyTough, MacGyver
            };
            Console.WriteLine($@"
            
            
            ");
            Console.WriteLine("WELCOME TO THE SECOND HEIST, THIS TIME IT GETS REAL REAL, NOT LIKE LAST TIME WHERE IT WAS EASY");
            Console.WriteLine();
            Console.WriteLine($"Let's open up the ol' rolodex of criminals. Looks like you've got {rolodex.Count} people in here at the moment.");
            CreateTeam();
            Console.WriteLine();
            Console.WriteLine($"All done entering criminals for your little rolodex, huh? Already let's check the numbers again - looks like you've got {rolodex.Count} criminals in here at the moment.");
            Console.WriteLine();
            Console.WriteLine($@"Alright, let's look at the bank you're trying to rob:
            
            **NAME**: The Doofy Bank of All These Rich MFs

            **MOST SECURE AND INTIMIDATING SECURITY SYSTEM**: {sortedBankRatings.ElementAt(2).Key}
            **LEAST SECURE AND EASIEST SYSTEM TO MESS UP**: {sortedBankRatings.ElementAt(0).Key}
            
            **TOTAL CASH ON HAND**: ${heistVictim.CashOnHand.ToString("N0")}
            ");
            Console.WriteLine();
            PickTeam();
            LetsHeist();

            void CreateTeam()
            {
                bool ending = false;
                while(!ending)
                {
                    Console.WriteLine();
                    Console.WriteLine("If you want to add a new criminal to the rolodex, enter their name. If you're ready to Heist, just press ENTER -->   ");
                    Console.WriteLine();
                    int i = rolodex.Count;
                    string memberName = Console.ReadLine();
                    if (memberName == "") {
                        break;
                    }
                    Console.WriteLine();
                    Console.WriteLine($@"OK great, got it, {memberName}. What is their specialty?
                    - For HACKER (disables alarms) - Enter 1
                    - For MUSCLE (disarms security guards) - Enter 2
                    - For LOCK SPECIALIST (cracks vault) - Enter 3
                    (If you don't select one of these three options, your new criminal will be defaulted to MUSCLE specialty)
                    ");
                    Console.WriteLine();
                    int memberSpecialty = Convert.ToInt32(Console.ReadLine());
                    string memberSpecialtyName = "";
                    if (memberSpecialty == 1)
                    {
                        memberSpecialtyName = "hackin";
                    }
                    else if (memberSpecialty == 3)
                    {
                        memberSpecialtyName = "lock pickin and vault gittin in";
                    }
                    else
                    {
                        memberSpecialtyName = "pullin up on them MF security guards like MF rocky balboa";
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"OK, so this {memberName}.... what would you rate their overall skill at {memberSpecialtyName}? Any positive whole number will work.:  ");
                    int memberSkill = 0;
                    try
                    {
                    memberSkill = Int32.Parse(Console.ReadLine());
                    }
                    catch(Exception)
                    {
                    memberSkill = 0;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"OK so that's a {memberSkill} for {memberName}'s {memberSpecialtyName} skill. Noted. Seems low. But noted.");
                    Console.WriteLine();
                    Console.WriteLine($"Another quick one about this {memberName} friend of yours.... What percentage cut are they going to demand from this heist? Enter 0 to 100 (if you don't, their cut will default to 5%):  ");
                    int memberCut = 0;
                    try
                    {
                    memberCut = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(Exception)
                    {
                    memberCut = 5;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Great, so that's a {memberCut}% cut for {memberName}. I think we should just steal their money and kill them after the heist is over, but that's just me, a brutally tough criminal computer. So let's move on!");
                    Console.WriteLine();
                    if (memberSpecialty == 1)
                    {
                        Hacker newMember = new Hacker() {
                            Name = memberName,
                            SkillLevel = memberSkill,
                            PercentageCut = memberCut,
                            id = rolodex.Count + 1
                        };
                        rolodex.Add(newMember);
                    }
                    else if (memberSpecialty == 3)
                    {
                        LockSpecialist newMember = new LockSpecialist() {
                            Name = memberName,
                            SkillLevel = memberSkill,
                            PercentageCut = memberCut,
                            id = rolodex.Count + 1
                        };
                        rolodex.Add(newMember);
                    }
                    else
                    {
                        Muscle newMember = new Muscle() {
                            Name = memberName,
                            SkillLevel = memberSkill,
                            PercentageCut = memberCut,
                            id = rolodex.Count + 1
                        };
                        rolodex.Add(newMember);
                    }
                }
            }
        
        void PickTeam()
        {
            bool trigger = false;
            while (!trigger)
            {
            Console.WriteLine();
            int total = crew.Sum(a => a.PercentageCut);
            IEnumerable<IRobber> filteredRobbers = rolodex.Where(robber => robber.PercentageCut + total < 100);
            int count = filteredRobbers.Count();
            if(count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Looks like you ain't got any room left on your crew, all of the cuts of the cash have been claimed. NO TIME TO PREPARE ANYMORE, IT'S TIME TO MF'ING HEIST MY FRIEND");
                Console.WriteLine();
                break;
            }
            Console.WriteLine("Let's pick the lowlife scum that you'll try this heist with. Real cream of the crop here, huh! That's SARCASM by the way.");
            Console.WriteLine();
            foreach(IRobber robber in filteredRobbers){
                Console.WriteLine(@$"**ROBBER PROFILE**
                
                **NAME**: {robber.Name}

                **ID NUMBER**: {robber.id}
                
                **SPECIALTY**: {robber.SpecialtyName}
                
                **SKILL LEVEL**: {robber.SkillLevel}
                
                **DESIRED CUT OF PAY**: {robber.PercentageCut}%
                
                **********************************************
                ");
            }
            Console.WriteLine();
            Console.WriteLine("Enter the ID number of a robber you want to add to your crew (or just press ENTER to start the HEIST PART TWO) -->   ");
            Console.WriteLine();
            string userPick = Console.ReadLine();
            int crewID = 0;
            if (userPick == "")
            {
                break;
            }
            else
            {
                crewID = Convert.ToInt32(userPick);
            }
            crew.Add(rolodex.ElementAt(crewID - 1));
            rolodex.RemoveAt(crewID - 1);
            Console.WriteLine();
            Console.WriteLine($"{crew.ElementAt(crew.Count - 1).Name} has been added to your crew! You have {crew.Count} members in your crew so far.");
            Console.WriteLine();
            }
        }

        void LetsHeist()
        {
            foreach (IRobber robber in crew)
            {
                Console.WriteLine();                
                robber.PerformSkill(heistVictim);
                Console.WriteLine();
            }

            if (heistVictim.IsSecure)
            {
                Console.WriteLine();
                Console.WriteLine("BIG FAILURE! EVERYONE GOT BUSTED!! SOME PEOPLE ARE DEAD!!! PEOPLE DIED BECAUSE YOU WANTED MONEY LET THAT SINK IN!!!!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("HOLY MACARONI YOU DID YOU DONE ROBBED THE DANG JOINT FOR A BAZILLION GEORGIE WASHINGTONIANS BABYYYYYYY WOOOOOOO WE'RE INVINCIBLEEEEEEEEEEEEEEEEEEEEEEEEEEEEE WE'RE NEVER GONNA DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                Console.WriteLine();
                int heistCash = heistVictim.CashOnHand;
                int yourHeistCash = heistCash;
                foreach (IRobber robber in crew)
                {
                    double percentageCut = Convert.ToDouble(robber.PercentageCut);
                    percentageCut = percentageCut / 100;
                    double cut = Convert.ToDouble(heistCash) * percentageCut;
                    Console.WriteLine();
                    Console.WriteLine($"{robber.Name} gets {robber.PercentageCut}% of the bank's cash on hand - meaning they got a total cut of ${cut.ToString("N0")}.");
                    Console.WriteLine();
                    yourHeistCash = (yourHeistCash - Convert.ToInt32(cut));
                    Console.WriteLine();
                }
                Console.WriteLine($"Which means you take home a whopping total of ${Convert.ToDouble(yourHeistCash).ToString("N0")}! Wow good for you! Crime pays!!!! SERIOUSLY!!!!");
                
            }
        }

        }
    }
}