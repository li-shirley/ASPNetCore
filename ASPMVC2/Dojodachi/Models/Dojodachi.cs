using System;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Models
{
    public class Dachi
    {
        public int Fullness {get;set;}

        public int Happiness {get;set;}

        public int Meals {get;set;}

        public int Energy {get;set;}

        public string Message {get;set;}

        public bool IsSad {get;set;}

        public string State {
            get{
                if (Energy > 100 && Fullness > 100 && Happiness > 100)
                {
                    return "Win";
                }
                if (Fullness <=0 || Happiness <= 0)
                {
                    return "Lose";
                }
                return "Playing";
            }
            set {}
        }

        public Dachi()
        {
            Fullness = 20;
            Happiness = 20;
            Meals = 3;
            Energy = 50;
            State = "Playing";
            Message = "";
            IsSad = false;
        }

        public void UpdateSession(ISession session)
        {
            session.SetObjectAsJson("Dachi", this);
        }
        public void Feed(ISession session)
        {
            if (Meals > 0)
            {
                if (new Random().Next(4) == 0)
                {
                    Meals -= 1;
                    Message = "You fed your Dojodachi! Your DojoDachi did not like the meal. -1 Meal.";
                    IsSad = true;
                }
                else 
                {
                    Meals -= 1;
                    int FullnessAmount = new Random().Next(5, 11);
                    Fullness += FullnessAmount;
                    Message = $"You fed your Dojodachi! -1 Meal, + {FullnessAmount} Fullness.";
                    IsSad = false;
                }
            }
            else
            {
                Message = "You don't have any meals to feed your DojoDachi.";
                IsSad = true;
            }
            UpdateSession(session);
        }

        public void Play(ISession session)
        {
            if (Energy >= 5)
            {
                if (new Random().Next(4) == 0)
                {
                    Energy -= 5;
                    Message = "You played with your Dojodachi! Your DojoDachi did not want to play. -5 Energy.";
                    IsSad = true;
                }
                else
                {
                    Energy -= 5;
                    int HappinessAmount = new Random().Next(5, 11);
                    Happiness += HappinessAmount;
                    Message = $"You played with your Dojodachi! -5 Energy, + {HappinessAmount} Happiness.";
                    IsSad = false;
                }
            }
            else 
            {
                Message = "Your DojoDachi does not have enough Energy to Play right now.";
                IsSad = true;
            }
            UpdateSession(session);
        }

        public void Work(ISession session)
        {
            if (Energy >= 5)
            {
                Energy -= 5;
                int MealsAmount = new Random().Next(1, 4);
                Meals += MealsAmount;
                Message = $"Your DojoDachi worked! -5 Energy, +{MealsAmount} Meals.";
                IsSad = false;
            }
            else
            {
                Message = "Your DojoDachi does not have enough Energy to Work right now.";
                IsSad = true;
            }
            UpdateSession(session);
        }

        public void Sleep(ISession session)
        {
            if (Fullness >= 5 && Happiness >= 5)
            {
                Fullness -= 5;
                Happiness -= 5;
                Energy += 15;
                Message = "Your DojoDachi Slept! -5 Fullness, -5 Happiness, +15 Energy.";
                IsSad = false;
            }
            else
            {
                Message = "Your DojoDachi does not have enough Fullness and/or Happiness to Work right now.";
                IsSad = true;
            }
            UpdateSession(session);
        }

    }
}