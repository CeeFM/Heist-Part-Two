using Heist;

public interface IRobber
{
    string Name { get; set; }
    int SkillLevel { get; set; }
    int PercentageCut { get; set; }
    string SpecialtyName { get; }
    string SpecialtyDesc { get; }
    void PerformSkill(Bank bank);
}