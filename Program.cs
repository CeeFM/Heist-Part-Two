using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Heist
{
    class Program
    {
        static void Main (string[] args)
        {
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
            Console.WriteLine("If you want to add a new criminal to the rolodex, enter their name. If you're ready to Heist, just press ENTER -->   ");
            string response = Console.ReadLine();
            if (response == "")
            {

            }
            else
            {
                
            }

        }
    }
}