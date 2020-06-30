namespace OIprojekt.Migrations
{
    using OIprojekt.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OIprojekt.DAL.PrzepisyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OIprojekt.DAL.PrzepisyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var recipes = new List<Recipe>
            {
                new Recipe { RecipeName = "Bananowiec",
                    Sources = "https://www.mojewypieki.com/",
                    Preparation = "Wszystkie składniki powinny być w temperaturze pokojowej. Mąkę i sodę oczyszczoną wymieszać, przesiać i odłożyć.W przepisie tym nie trzeba używać miksera. W dużym naczyniu wymieszać roztopione masło z rozgniecionymi bananami (wystarczy rozgnieść je widelcem). Wmieszać cukier, lekko roztrzepane jajko, wanilię. Na końcu dodać mąkę wymieszaną z sodą i szczypta soli. Wymieszać widelcem lub rózgą kuchenną, tylko do połączenia się składników. Ciasto przełożyć do keksówki o wymiarach 10 x 20 cm wysmarowanej masłem i oprószonej mąką pszenną.Piec przez 50 - 60 minut w piekarniku nagrzanym do 170°C, lub krócej, do tzw.suchego patyczka. Wyjąć, przestudzić w formie.",
                Date=DateTime.Parse("2013-01-05")},

                new Recipe { RecipeName = "Racuchy",
                    Sources = "https://www.mojewypieki.com/",
                    Preparation = "Jabłka obrać, usunąć gniazda nasienne, pokroić na ćwiartki a następnie w plasterki. W naczyniu wymieszać rózgą kuchenną jajka z jogurtem, do połączenia. Dodać cukier, wanilię, sól i ponownie wymieszać. Bezpośrednio do mieszanki przesiać mąkę pszenną z proszkiem do pieczenia i wymieszać rózgą kuchenną. Dodać plasterki jabłek i wymieszać. Smażyć natychmiast na średniej mocy palnika, na minimalnej ilości oleju, z obu stron, na złoty kolor. Na każdego placka nabierać pełną łyżkę ciasta z jabłkami.",
                Date=DateTime.Parse("2016-01-05")},
                new Recipe { RecipeName = "Biszkopt",
                    Sources = "https://www.mojewypieki.com/",
                    Preparation = "Wszystkie składniki powinny być w temperaturze pokojowej. Mąkę i skrobię przesiać. Białka oddzielić od żółtek, ubić na sztywną pianę (uważając, by ich nie 'przebić'). Pod koniec ubijania dodawać partiami cukier, łyżka po łyżce, ubijając po każdym dodaniu. Dodawać po kolei żółtka, nadal ubijając. Do masy jajecznej wsypać przesianą mąkę. Delikatnie wymieszać do przy pomocy szpatułki lub rózgi kuchennej, by składniki się połączyły. Składniki wmieszane szpatułką spowodują, że biszkopt będzie bardzo puszysty i wypełni formę wyrastając do wysokości jej boków. Wymieszanie składników szpatułką jest również metodą najbezpieczniejszą, nie należy mieszać przy pomocy miksera. Tortownicę o średnicy 23 - 25 cm wyłożyć papierem do pieczenia (samo dno), nie smarować boków. Delikatnie przełożyć ciasto, wyrównać. Piec w temperaturze 160 - 170ºC przez około 35 - 40 minut lub do tzw. suchego patyczka. Gorące ciasto wyjąć z piekarnika, z wysokości około 30 cm upuścić je (w formie) na podłogę, wystudzić w temperaturze pokojowej. Wystudzony, przekroić na 3 - 4 blaty.",
                Date=DateTime.Parse("2013-06-05")},
                new Recipe{RecipeName="Lody różane",
                Sources="https://www.mojewypieki.com/",
               Preparation="Śmietana, mleko skondensowane i woda różana powinny być schłodzone przez 24h. Śmietanę kremówkę umieścić w misie miksera i ubić. Pod koniec ubijania, kiedy bita śmietana zacznie gęstnieć a mieszadła będą pozostawiały na niej ślad zacząć wlewać mleko skondensowane słodzone, nie zaprzestając ubijania. Dodać barwnik spożywczy i wlewać wodę różaną, nie zaprzestając ubijania. Ubijać ostrożnie by nie spowodować zwarzenia się mieszanki. Ubitą i gotową mieszankę przełożyć do pojemnika spożywczego (co warstwę posypując posiekanymi pistacjami) i przykryć, schować w zamrażarce. Mrozić przez kilka godzin. Po 3 godzinach lody nadają się już do podania (jeśli zostały umieszczone w płaskim i szerszym pojemniku).",
                Date=DateTime.Parse("2018-04-13")},
                new Recipe{RecipeName="Chocolate Chip Cookies",
                Sources="",
                Preparation="Wszystkie składniki, oprócz czekolady, umieścić w malakserze i zmiksować. Następnie dodać czekoladę, orzechy, wymieszać. Z ciasta formować kulki wielkości orzecha włoskiego. Na wysmarowanej tłuszczem blaszce układać je w dużych odstępach - rozpłyną się mocno na boki; nie trzeba ich spłaszczać przed pieczeniem. Piec w temperaturze 180 - 190ºC przez około 12 minut lub do momentu, gdy brzegi zaczną się brązowić. Pozostawić kilka minut do przestygnięcia na blaszce, następnie przenieść na kratkę.",
                Date=DateTime.Parse("2020-01-01")},


            };
            //recipes.ForEach(x => context.Recipes.AddOrUpdate(p=>p.RecipeID, x)
            //recipes.ForEach(s => context.Recipes.AddOrUpdate(p => p.RecipeID, s));
            recipes.ForEach(x => context.Recipes.AddOrUpdate(y => y.RecipeName, x));
            context.SaveChanges();

            var measurements = new List<Measurement>
            {
                new Measurement{MeasurementID=1, MeasurementName="g"},
                new Measurement{MeasurementID=2, MeasurementName="szt"}
            };
            measurements.ForEach(x => context.Measurements.AddOrUpdate(y => y.MeasurementName, x));
            context.SaveChanges();
            var ingredients = new List<Ingredient>
            {
                new Ingredient{IngredientID =1, IngredientName="banan", CaloriesQuantity=95},
                new Ingredient{IngredientID =2, IngredientName="masło", CaloriesQuantity=735},
                new Ingredient{IngredientID =3, IngredientName="cukier brązowy", CaloriesQuantity=380},
                new Ingredient{IngredientID =4, IngredientName="jajko", CaloriesQuantity=150},
                new Ingredient{IngredientID =5, IngredientName="ekstrakt z wanilii", CaloriesQuantity=288},
                new Ingredient{IngredientID =6, IngredientName="soda oczyszczona", CaloriesQuantity=0},
                new Ingredient{IngredientID =7, IngredientName="sól", CaloriesQuantity=0},
                new Ingredient{IngredientID =8, IngredientName="mąka pszenna", CaloriesQuantity=342},
                new Ingredient{IngredientID =9, IngredientName="mąka ziemniaczana", CaloriesQuantity=340},
                new Ingredient{IngredientID =10, IngredientName="jogurt naturalny", CaloriesQuantity=60},
                new Ingredient{IngredientID =11, IngredientName="proszek do pieczenia", CaloriesQuantity=53},
                new Ingredient{IngredientID =12, IngredientName="jabłko", CaloriesQuantity=46},
                new Ingredient{IngredientID=13, IngredientName="mleko słododzone z puszki", CaloriesQuantity=326},
                new Ingredient{IngredientID=14, IngredientName="śmietana 30%", CaloriesQuantity=287},
                new Ingredient{IngredientID=15, IngredientName="Woda różana", CaloriesQuantity=0},
                new Ingredient{IngredientID=16, IngredientName="barwnik spożywczy", CaloriesQuantity=0},
           new Ingredient{IngredientID=17, IngredientName="groszki czekoladowe", CaloriesQuantity=503},
           new Ingredient{IngredientID=18, IngredientName="cukier biały", CaloriesQuantity=387},
           new Ingredient{IngredientID=19, IngredientName="żółtko", CaloriesQuantity=70},
            };
            ingredients.ForEach(x => context.Ingredients.AddOrUpdate(y => y.IngredientName, x));
            context.SaveChanges();
            var quantities = new List<Quantity>
            {
                new Quantity{RecipeID=1,QuantityID=1, IngredientID=1, IngredientQuantity=1000, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=2, IngredientID=2, IngredientQuantity=75, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=3, IngredientID=3, IngredientQuantity=100, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=4, IngredientID=4, IngredientQuantity=1, MeasurementID=2},
                new Quantity{RecipeID=1,QuantityID=5, IngredientID=5, IngredientQuantity=10, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=6, IngredientID=6, IngredientQuantity=10, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=7, IngredientID=8, IngredientQuantity=240, MeasurementID=1},
                new Quantity{RecipeID=1,QuantityID=8, IngredientID=7, IngredientQuantity=5, MeasurementID=1},

                new Quantity{RecipeID=2,QuantityID=9, IngredientID=4, IngredientQuantity=4, MeasurementID=2},
                new Quantity{RecipeID=2,QuantityID=10, IngredientID=3, IngredientQuantity=180, MeasurementID=1},
                new Quantity{RecipeID=2,QuantityID=11, IngredientID=8, IngredientQuantity=120, MeasurementID=1},
                new Quantity{RecipeID=2,QuantityID=12, IngredientID=9, IngredientQuantity=50, MeasurementID=1},

                new Quantity{RecipeID=3,QuantityID=13, IngredientID=10, IngredientQuantity=200, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=14, IngredientID=4, IngredientQuantity=2, MeasurementID=2},
                new Quantity{RecipeID=3,QuantityID=15, IngredientID=3, IngredientQuantity=50, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=16, IngredientID=8, IngredientQuantity=130, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=17, IngredientID=11, IngredientQuantity=5, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=18, IngredientID=5, IngredientQuantity=10, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=19, IngredientID=7, IngredientQuantity=5, MeasurementID=1},
                new Quantity{RecipeID=3,QuantityID=20, IngredientID=2, IngredientQuantity=2, MeasurementID=2},

                new Quantity{RecipeID=4,QuantityID=21, IngredientID=13, IngredientQuantity=250, MeasurementID=1},
                new Quantity{RecipeID=4,QuantityID=22, IngredientID=14, IngredientQuantity=320, MeasurementID=1},
                new Quantity{RecipeID=4,QuantityID=23, IngredientID=15, IngredientQuantity=100, MeasurementID=1},
                new Quantity{RecipeID=4,QuantityID=24, IngredientID=16, IngredientQuantity=5, MeasurementID=1},

                new Quantity{RecipeID=5,QuantityID=25, IngredientID=17, IngredientQuantity=200, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=26, IngredientID=8, IngredientQuantity=160, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=27, IngredientID=6, IngredientQuantity=3, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=28, IngredientID=7, IngredientQuantity=3, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=29, IngredientID=2, IngredientQuantity=170, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=30, IngredientID=3, IngredientQuantity=50, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=31, IngredientID=18, IngredientQuantity=50, MeasurementID=1},
                new Quantity{RecipeID=5,QuantityID=32, IngredientID=19, IngredientQuantity=1, MeasurementID=2},
                new Quantity{RecipeID=5,QuantityID=33, IngredientID=5, IngredientQuantity=10, MeasurementID=1},
            };
            quantities.ForEach(x => context.Quantities.AddOrUpdate(y => y.QuantityID, x));
            context.SaveChanges();

        }
    }
    }

