﻿using System;
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
            Hacker CodingWiz = new Hacker
            {
                Name = "Coding Genius",
                SkillLevel = 88,
                PercentageCut = 45
            };
            Muscle MuscleGuy = new Muscle
            {
                Name = "Max Power",
                SkillLevel = 79,
                PercentageCut = 25
            };
            LockSpecialist LockGuy = new LockSpecialist
            {
                Name = "Loqq Pickins",
                SkillLevel = 83,
                PercentageCut = 38
            };
            Hacker OldSchoolHacker = new Hacker
            {
                Name = "Old School Hacker",
                SkillLevel = 55,
                PercentageCut = 5
            };
            Muscle MentallyTough = new Muscle
            {
                Name = "Not Really All That Tough But Thinks He Is",
                SkillLevel = 22,
                PercentageCut = 90
            };
            LockSpecialist MacGyver = new LockSpecialist
            {
                Name = "Fuckin MacGyver Dude",
                SkillLevel = 99,
                PercentageCut = 85
            };
            List<IRobber> rolodex = new List<IRobber>() {
                CodingWiz, MuscleGuy, LockGuy, OldSchoolHacker, MentallyTough, MacGyver
            };
            Console.WriteLine("WELCOME TO THE SECOND HEIST, THIS TIME IT GETS REAL REAL, NOT LIKE LAST TIME WHERE IT WAS EASY");
            Console.WriteLine();
            Console.WriteLine($"Let's open up the ol' rolodex of criminals. Looks like you've got {rolodex.Count} people in here at the moment.");
            PickTeam();
            Console.WriteLine();
            Console.WriteLine($"All done entering criminals for your little rolodex, huh? Already let's check the numbers again - looks like you've got {rolodex.Count} criminals in here at the moment.");
            Console.WriteLine();
            Console.WriteLine($@"Alright, let's look at the bank you're trying to rob:
            
            **NAME**: The Doofy Bank of All These Rich MFs

            **ALARM SYSTEM RATING**: {heistVictim.AlarmScore}
            **VAULT SECURITY RATING**: {heistVictim.VaultScore}
            **TOTAL SECURITY GUARDS**: {heistVictim.SecurityGuardScore}
            
            **TOTAL CASH ON HAND**: ${heistVictim.CashOnHand.ToString("N0")}
            ");
            void PickTeam()
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
                    if (memberSpecialty == 1)
                    {
                        Hacker newMember = new Hacker() {
                            Name = memberName,
                            SkillLevel = 0,
                            PercentageCut = 0
                        };
                        rolodex.Add(newMember);
                    }
                    else if (memberSpecialty == 3)
                    {
                        LockSpecialist newMember = new LockSpecialist() {
                            Name = memberName,
                            SkillLevel = 0,
                            PercentageCut = 0
                        };
                        rolodex.Add(newMember);
                    }
                    else
                    {
                        Muscle newMember = new Muscle() {
                            Name = memberName,
                            SkillLevel = 0,
                            PercentageCut = 0
                        };
                        rolodex.Add(newMember);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine($"OK, so this {memberName}.... what would you rate their overall skill at {rolodex[rolodex.Count - 1].SpecialtyDesc}? Any positive whole number will work.:  ");
                    int memberSkill = 0;
                    try
                    {
                    memberSkill = Int32.Parse(Console.ReadLine());
                    }
                    catch(Exception)
                    {
                    memberSkill = 0;
                    }
                    rolodex[rolodex.Count - 1].SkillLevel = memberSkill;
                    Console.WriteLine();
                    Console.WriteLine($"OK so that's a {memberSkill} for {memberName}'s {rolodex[rolodex.Count - 1].SpecialtyName} skill. Noted. Seems low. But noted.");
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
                    rolodex[rolodex.Count - 1].PercentageCut = memberCut;
                    Console.WriteLine();
                    Console.WriteLine($"Great, so that's a {memberCut}% cut for {memberName}. I think we should just steal their money and kill them after the heist is over, but that's just me, a brutally tough criminal computer. So let's move on!");
                    Console.WriteLine();
                }
            }

        }
    }
}