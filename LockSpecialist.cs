namespace Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string SpecialtyName { get; } = "Lock Specialist";
        public string SpecialtyDesc { get; } = "pickin them MF locks 'n vaults boi";      
        public void PerformSkill(Bank bank)
        {
            Console.Write($"{Name} picking the vault lock. Their lockpicking skill level is {SkillLevel}, so the bank's vault security has reduced {SkillLevel}. The vault now only has an integrity of {bank.VaultScore - SkillLevel}.");
            bank.VaultScore = bank.VaultScore - SkillLevel;
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has picked the dang vault lock! Good lord how'd they do that they only had a single toothpick and an american flag!!");
            }
        }
    }
}