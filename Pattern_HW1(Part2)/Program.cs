using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pattern_HW1_Part2_.VoinFactory;

//Абстрактная фабрика(Abstract Factory)

namespace Pattern_HW1_Part2_
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();

            Console.ReadLine();
        }
    }

    //абстрактный класс - оружие
    abstract class Weapon
    {
        public abstract void Hit();
    }

    // абстрактный класс движение
    abstract class Movement
    {
        public abstract void Move();
    }

    //*****************************************************
    // класс арбалет
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Arbalet shots");
        }
    }

    // класс меч
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Sword hits");
        }
    }

    // движение полета
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Fly");
        }
    }

    // движение - бег
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Run");
        }
    }

    //*****************************************************
    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    //*****************************************************
    // Фабрика создания летящего героя с арбалетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    // Фабрика создания бегущего героя с мечом
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
     // клиент - сам супергерой
     public class Hero
        {
            private Weapon weapon;
            private Movement movement;
            public Hero(HeroFactory factory)
            {
                weapon = factory.CreateWeapon();
                movement = factory.CreateMovement();
            }
            public void Run()
            {
                movement.Move();
            }
            public void Hit()
            {
                weapon.Hit();
            }
        }
    }
}
