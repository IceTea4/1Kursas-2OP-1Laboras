using System.Text; //Naudojama biblioteka teksto koduotei (Encoding)

namespace U1_24KompiuterinisZaidimas
{
    /*U1-24. Kompiuterinis žaidimas. Kuriate „fantasy“ kompiuterinį žaidimą.
     *Duomenų faile turite informacija apie žaidimo herojus: vardas, rasė,
     *klasė, gyvybės taškai, mana, žalos taškai, gynybos taškai, jėga, vikrumas,
     *intelektas, ypatinga galia.
        • Raskite daugiausiai gyvybės taškų turintį herojų, ekrane
        atspausdinkite jo vardą, rasę, klasę ir gyvybės taškų kiekį. Jei yra
        keli, spausdinkite visus.
        • Raskite žaidėją, kurio gynybos ir žalos taškų skirtumas yra
        mažiausias. Atspausdinkite informaciją apie žaidėją į ekraną. Jei yra
        keli, spausdinkite visus.
        • Sudarykite visų herojų klasių sąrašą, klasių pavadinimus įrašykite į
        failą „Klasės.csv“. Klasių pavadinimai neturi kartotis.
    */

    //Klasė, kurioje sukuriamas konstruktorius
    public class Hero
    {
        public string name { get; }
        public string race { get; }
        public int number { get; }
        public int health { get; }
        public int mana { get; }
        public int damage { get; }
        public int defend { get; }
        public int strength { get; }
        public int speed { get; }
        public int intellect { get; }
        public string power { get; }

        //Sukuria herojaus konstruktorių
        public Hero(string name, string race, int number, int health, int mana,
            int damage, int defend, int strength, int speed, int intellect,
            string power)
        {
            this.name = name;
            this.race = race;
            this.number = number;
            this.health = health;
            this.mana = mana;
            this.damage = damage;
            this.defend = defend;
            this.strength = strength;
            this.speed = speed;
            this.intellect = intellect;
            this.power = power;
        }
    }

    //Klasė vykdanti nuskaitymus ir spausdinimus
    public class InputOutput
    {
        //Metodas nuskaitantis herojus ir jų duomenis iš "Herojus.csv" failo
        public static List<Hero> ReadHeroes(string fileName)
        {
            List<Hero> heroes = new List<Hero>();

            //Nuskaito visas eilutes iš failo UTF-8 encoding
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);

            //Analizuoja kiekvieną eilutę
            foreach (string line in Lines)
            {
                string[] values = line.Split(";");
                string name = values[0];
                string race = values[1];
                int number = int.Parse(values[2]);
                int health = int.Parse(values[3]);
                int mana = int.Parse(values[4]);
                int damage = int.Parse(values[5]);
                int defend = int.Parse(values[6]);
                int strength = int.Parse(values[7]);
                int speed = int.Parse(values[8]);
                int intellect = int.Parse(values[9]);
                string power = values[10];

                //Sukuria naują herojaus objektą
                Hero hero = new Hero(name, race, number, health, mana, damage,
                    defend, strength, speed, intellect, power);

                //Sukurtą objektą hero prideda į heroes sąrašą
                heroes.Add(hero);
            }

            return heroes;
        }

        //Metodas spausdinantis visus herojus ir jų duomenis į koncolę
        public static void PrintAllHeroes(List<Hero> heroes)
        {
            //Sukuriama lentelė duomenims talpinti
            Console.WriteLine("Registro informacija:");
            Console.WriteLine(new string('-', 146));
            Console.WriteLine("| {0,-12} | {1,-15} | {2,-5} | {3,-14} | " +
                "{4,-4} | {5,-12} | {6,-14} | {7,-4} | {8,-8} | {9,-10} | " +
                "{10,-14} |", "Vardas", "Rasė", "Klasė", "Gyvybės taškai",
                "Mana", "Žalos taškai", "Gynybos taškai", "Jėga", "Vikrumas",
                "Intelektas", "Ypatinga galia");
            Console.WriteLine(new string('-', 146));

            foreach (Hero hero in heroes)
            {
                Console.WriteLine("| {0,-12} | {1,-15} | {2,5} | {3,14} | " +
                    "{4,4} | {5,12} | {6,14} | {7,4} | {8,8} | {9,10} | " +
                    "{10,-14} |", hero.name, hero.race, hero.number,
                    hero.health, hero.mana, hero.damage, hero.defend,
                    hero.strength, hero.speed, hero.intellect, hero.power);
            }

            Console.WriteLine(new string('-', 146));
        }

        //Metodas atspausdinantis visus herojus ir jų duomenis į txt failą
        //Duomenys talpinami lentelėje
        public static void PrintAllHeroesToTxt(string fileNameTxt, List<Hero> heroes)
        {
            string[] lines = new string[heroes.Count + 5];

            lines[0] = String.Format("Registro informacija:");
            lines[1] = String.Format(new string('-', 146));
            lines[2] = String.Format("| {0,-12} | {1,-15} | {2,-5} | {3,-14}" +
                " | {4,-4} | {5,-12} | {6,-14} | {7,-4} | {8,-8} | " +
                "{9,-10} | {10,-14} |", "Vardas", "Rasė", "Klasė",
                "Gyvybės taškai", "Mana", "Žalos taškai", "Gynybos taškai",
                "Jėga", "Vikrumas", "Intelektas", "Ypatinga galia");
            lines[3] = String.Format(new string('-', 146));

            int x = 4;

            foreach (Hero hero in heroes)
            {
                lines[x] = String.Format("| {0,-12} | {1,-15} | {2,5} | " +
                    "{3,14} | {4,4} | {5,12} | {6,14} | {7,4} | {8,8} | " +
                    "{9,10} | {10,-14} |", hero.name, hero.race, hero.number,
                    hero.health, hero.mana, hero.damage, hero.defend,
                    hero.strength, hero.speed, hero.intellect, hero.power);
                x++;
            }

            lines[x] = String.Format(new string('-', 146));

            //Atspausdinama į kiekvieną failo eilutę
            File.WriteAllLines(fileNameTxt, lines, Encoding.UTF8);
        }

        //Metodas spausdina daugiausiai gyvybės taškų turintį/turinčius herojus
        //ir jų duomenis (vardą, rasę, klasę, gyvybės taškus)
        //Duomenys talpinami į lentelę
        public static void PrintHealthiest(List<Hero> heroes)
        {
            //Į stipriausių sąrašą yra įrašomi daugiausiai gyvybės taškų
            //turintys herojai
            List<Hero> strongest = Tasks.FindMostHealth(heroes);

            Console.WriteLine("Daugiausiai gyvybės taškų:");
            Console.WriteLine(new string('-', 59));
            Console.WriteLine("| {0,-12} | {1,-15} | {2,5} | {3,14} |",
                "Vardas", "Rasė", "Klasė", "Gyvybės taškai");
            Console.WriteLine(new string('-', 59));

            foreach (Hero hero in strongest)
            {
                Console.WriteLine("| {0,-12} | {1,-15} | {2,5} | {3,14} |",
                    hero.name, hero.race, hero.number, hero.health);
            }

            Console.WriteLine(new string('-', 59));
        }

        //Metodas spausdina mažiausią skirtumą (gynybos taškai - žalos taškai)
        //turintį/turinčius herojus
        //Spausdinami visi herojaus duomenys
        //Duomenys talpinami į lentelę
        public static void PrintWithSmallestDifference(List<Hero> heroes)
        {
            List<Hero> strongest = Tasks.FindBalance(heroes);

            Console.WriteLine("Mažiausias skirtumas tarp gynybos ir žalos " +
                "taškų:");
            Console.WriteLine(new string('-', 146));
            Console.WriteLine("| {0,-12} | {1,-15} | {2,-5} | {3,-14} | " +
                "{4,-4} | {5,-12} | {6,-14} | {7,-4} | {8,-8} | {9,-10} | " +
                "{10,-14} |", "Vardas", "Rasė", "Klasė", "Gyvybės taškai",
                "Mana", "Žalos taškai", "Gynybos taškai", "Jėga", "Vikrumas",
                "Intelektas", "Ypatinga galia");
            Console.WriteLine(new string('-', 146));

            foreach (Hero hero in strongest)
            {
                Console.WriteLine("| {0,-12} | {1,-15} | {2,5} | {3,14} | " +
                    "{4,4} | {5,12} | {6,14} | {7,4} | {8,8} | {9,10} | " +
                    "{10,-14} |", hero.name, hero.race, hero.number,
                    hero.health, hero.mana, hero.damage, hero.defend,
                    hero.strength, hero.speed, hero.intellect, hero.power);
            }

            Console.WriteLine(new string('-', 146));
        }

        //Metodas spausdina herojų klases (be pasikartojimų) į
        //"Klases.csv" failą
        public static void PrintNumbers(string fileName, List<Hero> heroes)
        {
            //Iš Tasks klasės pasiimamos skirtingos herojų klasės ir surašomos
            //į numbers sąrašą
            List<int> numbers = Tasks.FindClasses(heroes);
            string[] lines = new string[numbers.Count + 1];

            lines[0] = String.Format("Herojų klasės:");

            for (int i = 0; i < numbers.Count; i++)
            {
                lines[i + 1] = String.Format("{0}", numbers[i]);
            }

            //Atspausdina į visas failo eilutes
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }

    //Klasė, kurioje yra atliekami skaičiavimai
    public class Tasks
    {
        //Privatus metodas apskaičiuojantis, koks yra didžiausias gyvybės
        //taškų skaičius 
        private static int FindHugeHealth(List<Hero> heroes)
        {
            //Daroma prielaida, kad gyvybės taškai bus didesni nei -1
            int strong = -1;

            foreach (Hero hero in heroes)
            {
                if (hero.health > strong)
                {
                    strong = hero.health;
                }
            }
            return strong;
        }

        //Metodas kuris randa visus herojus turinčius didžiausią gyvybės
        //taškų kiekį
        public static List<Hero> FindMostHealth(List<Hero> heroes)
        {
            //Susikuriamas naujas sąrašas, kuriame bus talpinami visi herojai
            //turintys didžiausią gyvybės taškų kiekį
            List<Hero> healthiest = new List<Hero>();
            int strong = FindHugeHealth(heroes);

            foreach (Hero hero in heroes)
            {
                if (strong == hero.health)
                {
                    //Į naująjį sąrašą įdedamas herojaus objektas atitinkantis
                    //sąlygą
                    healthiest.Add(hero);
                }
            }
            return healthiest;
        }

        //Privatus metodas ieškantis mažiausio skirtumo
        //(gynybos taškai - žalos taškai) tarp visų herojų
        private static double FindSmallestDifference(List<Hero> heroes)
        {
            double difference = heroes[0].defend - heroes[0].damage;

            foreach (Hero hero in heroes)
            {
                if (difference > (hero.defend - hero.damage))
                {
                    difference = hero.defend - hero.damage;
                }
            }

            return difference;
        }

        //Metodas randantis visus herojus turinčius mažiausią skirtumą
        //(gynybos taškai - žalos taškai) ir sudedantis juos į vieną sąrašą
        public static List<Hero> FindBalance(List<Hero> heroes)
        {
            //Sukuria naują sąrašą skirtą talpinti atrinktiems herojams
            List<Hero> difference = new List<Hero>();
            double strong = FindSmallestDifference(heroes);

            foreach (Hero hero in heroes)
            {
                if (strong == hero.defend - hero.damage)
                {
                    //Sąlygą atitikę herojai pridedami į naująjį sąrašą
                    difference.Add(hero);
                }
            }
            return difference;
        }

        //Metodas ieškantis herojų klasių ir lyginantis jas taip atrekantis
        //vienodas klases
        public static List<int> FindClasses(List<Hero> heroes)
        {
            //Sukuriamas naujas sąrašas, kuriame bus talpinamos herojų klasės
            //nesutampančios su buvusiomis
            List<int> numbers = new List<int>();

            foreach (Hero hero in heroes)
            {
                int nr = hero.number;

                if (!numbers.Contains(nr))
                {
                    //Sąlygą atitinkančios klasės yra pridedamos į naująjį sąrašą
                    numbers.Add(nr);
                }
            }
            return numbers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Iš failo "Herojus.csv" yra nuskaitomi herojai ir jų duomenys,
            //kurie yra patalpinami į allHeroes sąrašą
            List<Hero> allHeroes = InputOutput.ReadHeroes(@"../../../../Herojus.csv");

            //Į konsolę yra atspausdinami visi herojai ir jų duomenys lentelėje
            InputOutput.PrintAllHeroes(allHeroes);

            //Visi herojai ir jų duomenys lentelėje yra atspausdinami į
            //"Duomenys.txt" failą
            string fileNameTxt = "Duomenys.txt";
            InputOutput.PrintAllHeroesToTxt(fileNameTxt, allHeroes);

            //Atspausdinama tuščia eilutė, kad nesusimaišytų rezultatai
            Console.WriteLine();

            //Į konsolę atspausdinami pirmos užduoties rezultatai (herojai
            //turintys daugiausiai gyvybės taškų)
            InputOutput.PrintHealthiest(allHeroes);

            //Atspausdinama tuščia eilutė, kad nesusimaišytų rezultatai
            Console.WriteLine();

            //Į koncolę spausdinami antrosios užduoties rezultatai (herojai
            //turintys mažiausią skirtumą (gynybos taškai - žalos taškai)
            InputOutput.PrintWithSmallestDifference(allHeroes);

            //Trečiosios užduoties rezultatas (visos skirtingos herojų klasės)
            //yra atspausdinamas į "Klases.csv" failą
            string fileName = "Klases.csv";
            InputOutput.PrintNumbers(fileName, allHeroes);
        }
    }

}
