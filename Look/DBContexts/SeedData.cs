﻿using Look.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Look.DBContexts
{
    public class SeedData
    {

        public static void SeedDatabase(DBConnection context)
        {
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                Order sherzod=new Order {DateTime=DateTime.Now,Count="1"};
                Employee tohirbek= new Employee { EmployeeName="Tohirbek",PhoneNamber="+998944006668",Orders=sherzod};
                Category foods = new Category { CategoryName = "Foods", Slug="foods",Employees=tohirbek };
                Category drinks = new Category { CategoryName = "Drinks",Slug="drinks" , Employees = tohirbek };

                context.Products.AddRange(
                        new Product
                        {
                            ProductName = "Burger",
                            Slug = "burger",
                            Description = "Gig burger",
                            Price = 1.50M,
                            Category = foods,
                            Image = "burgers.jp"
                        },
                        new Product
                        {
                            ProductName = "Kfc",
                            Slug= "kfc",
                            Price = 2M,
                            Description= "box master kfc",
                            Category = foods,
                            Image = "kfc.jp"
                        },
                        new Product
                        {
                            ProductName = "Pizza",
                            Slug= "pizza",
                            Description= "pizza dominos",
                            Price = 0.50M,
                            Category = foods,
                            Image = "pizza.jp"
                        },
                        new Product
                        {
                            ProductName = "Lavash",
                            Slug= "lavash",
                            Description= "tandir lavash",
                            Price = 2.50M,
                            Category = foods,
                            Image = "lavash.png"
                        },
                        new Product
                        {
                            ProductName = "Fre",
                            Slug= "fre",
                            Description= "Fre 300g",
                            Price = 2.50M,
                            Category = foods,
                            Image = "free.jp"
                        },
                        new Product
                        {
                            ProductName = "Coco-cola",
                            Slug="coco-cola",
                            Description= "Coco-cola 05L",
                            Price = 5.99M,
                            Category = drinks,
                            Image = "cola05.jp"
                        },
                        new Product
                        {
                            ProductName = "Coco-cola",
                            Slug="coco-cola",
                            Description= "Coco-cola 025L",
                            Price = 5.99M,
                            Category = drinks,
                            Image = "cola250.jp"
                        },
                        new Product
                        {
                            ProductName = "Coco-cola",
                            Slug="coco-cola",
                            Description= "Coco-cola 1.5L",
                            Price = 5.99M,
                            Category = drinks,
                            Image = "cola1.5.jp"
                        },
                        new Product
                        {
                            ProductName = "Mojito",
                            Slug = "mojito",
                            Description = "Apple Juicy mojito",
                            Price = 7.99M,
                            Category = drinks,
                            Image = "mojitos.jp"
                        },
                        new Product
                        {
                            ProductName = "Cofe",
                            Slug= "cofe",
                            Description= "MacCofe Gold",
                            Price = 9.99M,
                            Category = drinks,
                            Image = "cofee.jp"
                        },
                        new Product
                        {
                            ProductName = "Tropic",
                            Slug="tropic",
                            Description="Tropic Juicy bananas",
                            Price = 11.99M,
                            Category = drinks,
                            Image = "tropic.jp"
                        }
                );

                context.SaveChanges();
            }
        }
    }
}