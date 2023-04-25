# Design-Patterns

Using a 2D game to test a strategy pattern and a factory pattern.

Gaming Scenario: In a 2D world there are two distinct factions, the Humans(Allies) and the creatures(Enemies). You as the player are to navigate this world and defeat the lower tiered Goblins to gather the loot they drop, which in this case are healing and strength potions, and finally defeat the boss Troll.
You play as a human, picking either the Paladin or a Ranger class which each have their own benefits. The Ranger will use his Ranged Attack more often than the Paladin but the Paladin has higher starting health and strength which scales the further into your run.
The ranged attack has a special feature in which it will skip the enemies next turn because they are out of reach from the player, allowing the player to attack again and vica versa. The Melee attack is a regular attack.
Attack Damage is calculated using a random number generator and multiplying it with the Ally or Enemies strength stat divided by 10 and then flooring the result. (Floor(RandomNum\*(Strength/10)))
One Troll will be spawned per run and a random number of Goblins will be spawned thereafter. The Troll is too strong to fight before killing any of the other goblins and increasing your HP and strength. Both the Troll and the Goblins have an equal chance of using their ranged or melee attack.
When a Player moves into the same position as a Goblin or Troll, the Conflict sequence will start. A simulated battle to the death where if the player dies, the game will end and if a goblin dies, you gain its loot and if you beat the Troll, you beat the game.
Upon killing a Goblin, it will drop both a healing and a strength potion but both potions should use their own unique formula to determine how much of a buff the player receives.

The spawning of all characters in the game, both humans and creatures, are handled by the factory design pattern and the healing and strength potions are handled through the strategy pattern.
Humans and the creatures are split up by the AllyWorkshop and EnemyWorkshop classes respectively. By using a factory design pattern, I can easily add more human classes or creature types to the game to make it more interesting. Only Human Characters can Move around, while Creatures are stationary.
A Potion will either be a healing or a strength potion that inherits from the PotionType class. The healing and strength potion has each its own unique formula to determine how much HP or strength it gives the player which can be called upon when the player defeats a Goblin.
