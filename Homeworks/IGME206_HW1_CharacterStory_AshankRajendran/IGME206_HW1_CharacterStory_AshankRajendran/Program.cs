namespace IGME206_HW1_CharacterStory_AshankRajendran
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Activity 1: Declare and initialize all variables here
            
            //Main character's details

            string characterName = "Hegg Greffley"; //Main Character's name

            //Base Rizz value determines the character's base attack value
            const double BaseRizz = 6;

            //Maximum Confidence is the character's Maximum Hit Points
            const double MaxConfidence = 100;

            //Current Confidence is the character's Current Hit Points
            double currentConfidence = MaxConfidence;

            double experiencePoints = 0; //Character's experience points
            int characterLevel = 1; //Character's level

            //Girlfriend count. Represents the number of battles won
            int girlfriends = 0;

            //Rejections count. Represents the number of battles lost
            int rejections = 0;

            //Enemy details
            string enemyName = "Feather Fills";
            const double EnemyMaxHitPoints = 50;
            const double EnemyBaseDefence = 100;
            const double EnemyBaseAttack = 35;
            double enemyCurrentHitPoints = EnemyMaxHitPoints;

            //Other variables
            //Damage variable to store calculated damage of current attack
            //Formula for main characters damage is damage = BaseRizz - EnemyBaseDefence
            //Enemy attack damage values are absolute, main character does not reduce enemy damage
            double damage = 0;

            //Amount of experience gained after winning a battle.
            //Only half of this value is gained if player loses the battle
            double experienceGain = 250;

            //Amount of experience points required to level up once
            double levelUpValue = 100;

            //Damage multiplier for critical hits
            double criticalHitMultiplier = 2.5f;

            //Activity 2: Print character introduction and starting stats here
            Console.WriteLine("WELCOME TO DIARY OF A SIMPY KID!");
            Console.WriteLine("\n======== Introduction ========");
            Console.WriteLine("Introducing " + characterName + "!" +
                " A young, geeky teenager who is determined to one day become the ultimate Rizz Lord!");

            Console.WriteLine("\n-------- Initial Character Stats --------");
            Console.WriteLine("Max Confidence: " + MaxConfidence);
            Console.WriteLine("Current Confidence: " + currentConfidence);
            Console.WriteLine("Experience Points: " + experiencePoints);
            Console.WriteLine("Level: " + characterLevel);
            Console.WriteLine("Girlfriends: " + girlfriends);
            Console.WriteLine("Rejections: " + rejections);

            //Activity 3: Print the character's actions and calculation results here
            Console.WriteLine("\n=== The Adventure ===\n");
            Console.WriteLine(characterName + " approaches " + enemyName +"...");

            //Turn 1
            Console.WriteLine();
            Console.WriteLine(characterName + " uses 'Pay Compliment'");

            //Calculate the damage done by this attack. Reduce enemy health by damage.
            damage = BaseRizz - EnemyBaseDefence;
            damage = Math.Max(damage, 0); //If damage is negative, make it 0.
            enemyCurrentHitPoints = enemyCurrentHitPoints - damage;

            Console.WriteLine("It is not very effective!");
            Console.WriteLine("'Pay Compliment' did " + damage + " damage!");
            Console.WriteLine(enemyName + "'s current HP: " + enemyCurrentHitPoints);

            //Turn 2
            Console.WriteLine();
            Console.WriteLine(enemyName + " uses 'Ignore'");
            Console.WriteLine(characterName + "'s feelings are hurt!");

            //Calculate enemy damage. Reduce Confidence by damage
            damage = EnemyBaseAttack;
            currentConfidence = currentConfidence - damage;
            Console.WriteLine("The attack did " + damage + " damage!");
            Console.WriteLine(characterName + "'s current Confidence: " + currentConfidence);

            //Turn 3
            Console.WriteLine();
            Console.WriteLine(characterName + " uses 'Self-motivate'");
            Console.WriteLine(characterName + " feels more confident!");

            //Heal current confidence by 10% of max confidence
            currentConfidence += MaxConfidence * 0.1;
            Console.WriteLine(characterName + " healed himself for " + (MaxConfidence * 0.1) + " points");
            Console.WriteLine(characterName + "'s current Confidence: " + currentConfidence);

            //Turn 4
            Console.WriteLine();
            Console.WriteLine(enemyName + " uses 'I have a boyfriend'");
            Console.WriteLine("It's a critical hit!");

            //Calculate enemy damage with critical hit multiplier. Reduce confidence by damage.
            damage = EnemyBaseAttack * criticalHitMultiplier;
            currentConfidence = currentConfidence - damage;
            currentConfidence = Math.Max(currentConfidence, 0);
            Console.WriteLine("The attack did " + damage + " damage!");
            Console.WriteLine(characterName + "'s current Confidence: " + currentConfidence);

            //Battle Over
            Console.WriteLine();
            Console.WriteLine("Battle Over! " + characterName + " lost.");

            //Increment loss count aka rejections
            rejections += 1;

            Console.WriteLine(characterName + " gained " + experienceGain / 2 + " experience");

            //Add experience points for battle loss and calculate new character level
            experiencePoints += experienceGain / 2;
            characterLevel = 1 + (int)experiencePoints / (int)levelUpValue;

            Console.WriteLine(characterName + " is now level " + characterLevel);

            //Calculate and print how much experience required to reach next level
            Console.WriteLine("Experience points required to reach level " +
                (characterLevel + 1) + ": " +                           //character's next level
                (levelUpValue - experiencePoints % levelUpValue)
                );

            //Activity 4: Print the conclusion here
            Console.WriteLine();
            Console.WriteLine("====== Conclusion =====");
            Console.WriteLine(characterName + " has lost all confidence in himself. " +
                "\nHe will never speak to another girl again.");

            Console.WriteLine("\n-------- Final Character Stats --------");
            Console.WriteLine("Max Confidence: " + MaxConfidence);
            Console.WriteLine("Current Confidence: " + currentConfidence);
            Console.WriteLine("Experience Points: " + experiencePoints);
            Console.WriteLine("Level: " + characterLevel);
            Console.WriteLine("Girlfriends: " + girlfriends);
            Console.WriteLine("Rejections: " + rejections);
        }
    }
}
