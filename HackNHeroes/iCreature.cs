namespace HackNHeroes
{
    interface ICreature
    {
        string Name { get; set; }
        int Damage { get; set; }
        int Hp { get; set; }
        int HpMax { get; set; }

        bool isAlive();
    }
}