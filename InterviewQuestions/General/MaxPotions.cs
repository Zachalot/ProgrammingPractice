using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.General
{
    public class MaxPotions
    {

        /*
            Constraints/rules:
                1) Must traverse potions array from left to right
                2) cannot let health drop below 0
                3) for each potion in array, I can either drink or not drink.
                4) health starts at 0.
                5) 
            Test Cases:
                1) empty array, return 0.
                2) all positive, drink all potions.
                3) sum of all potions = exactly 0 [4, -4, 3, -3, 8, -8]
                4) all negative potions presented first [ -2, -3, -5, 2, 2, 7]

            Approach:
                1) always drink positive potions.
                2) if negative potion drops health below 0, do not drink
                3) if negative potion would cause me to NOT be able to drink future negative potions, do not drink this negative potion.
                4) [-3, -1, -1], need to use max priority queue, where least negative potions are at the top
                    4.1) if drinkingg this poition would prevent me from drinking the NEXT potion in the priority queue, dont drink it
                    4.2) if drinking this potion would not necessarily prevent me from drinking the other potions in the priority queue
                

            Algorithm/DataStructures:
         
         */
        public int DrinkMaxPotions(int[] potions) 
        {
            int health = 0;
            int potionCount = 0;

            return -1;

        }
    }
}
