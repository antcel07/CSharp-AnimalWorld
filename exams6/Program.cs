using System;

namespace exams6
{
    class Program
    {
        public static void Main()
        {
            
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();
            
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            
            Console.ReadKey();
        }
    }
    
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
   
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new gazelle();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Tiger();
        }
    }
    
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Crocodile();
        }
    }
   
    abstract class Herbivore
    {
    }
    
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
 
    class gazelle : Herbivore
    {
    }
    
    class Tiger : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
   
    class Bison : Herbivore
    {
    }

    class Crocodile : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }
   
    class AnimalWorld
    {
        private Herbivore herb;
        private Carnivore carn;
        
        public AnimalWorld(ContinentFactory factory)
        {
            carn = factory.CreateCarnivore();
            herb = factory.CreateHerbivore();
        }
        public void RunFoodChain()
        {
            carn.Eat(herb);
        }
    }
}
    
