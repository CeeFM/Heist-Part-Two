namespace Heist
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int id { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string SpecialtyName { get ;} = "Hacker";
        public string SpecialtyDesc { get; } = "gettin nerdy and bleep blorpin with those 1's and 0's, big hacker stuff";          
        public void PerformSkill(Bank bank)
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} started hacking the dang alarm system. Their skill level is {SkillLevel}, so the bank's Alarm Score has been reduced by {SkillLevel}. The bank's Alarm Score is now {bank.AlarmScore - SkillLevel}.");
            bank.AlarmScore = bank.AlarmScore - SkillLevel;
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{Name} has disabled the alarm system! Huzzah huzzah what a wonderful criminal!!");
            }
        }
    }
}