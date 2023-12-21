namespace Heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int id { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string SpecialtyName { get ;} = "Muscle";
        public string SpecialtyDesc { get; } = "pullin up and using them hands like MF rocky balboa";  
        public void PerformSkill(Bank bank)
        {
            Console.WriteLine();
            Console.Write($"{Name} started kicking security butts. Their buttkicking skill level is {SkillLevel}, so the bank's security guard total has reduced {SkillLevel}. The bank now only has {bank.SecurityGuardScore - SkillLevel} security guards.");
            Console.WriteLine();
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            if (bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine();
                Console.WriteLine($"{Name} has kicked every single security guard's butt! Bang boom crash look at this criminal do the dang thing!!");
                Console.WriteLine();
            }
        }
    }
}