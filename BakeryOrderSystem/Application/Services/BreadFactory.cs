using System;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;

namespace BakeryProject.Application.Services
{
    public class BreadFactory : IBreadFactory
    {
        public Bread CreateBread(int choice)
        {
            switch (choice)
            {
                case 1: return new Baguette();
                case 2: return new WhiteBread();
                case 3: return new MilkBread();
                case 4: return new HamburgerBun();
                default: throw new ArgumentException("Invalid bread choice");
            }
        }

        public Bread CreateBread(string breadName)
        {
            switch (breadName.ToLower())
            {
                case "baguette":
                    return new Baguette();
                case "white bread":
                    return new WhiteBread();
                case "milk bread":
                    return new MilkBread();
                case "hamburger bun":
                    return new HamburgerBun();
                default:
                    throw new ArgumentException("Invalid bread name");
            }
        }
    }
}
