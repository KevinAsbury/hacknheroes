namespace HackNHeroes
{
    interface ICreature
    {
        string name { get; set; }
        int damage { get; set; }
        int hp { get; set; }
        int hpMax { get; set; }

        void Save();
    }
}