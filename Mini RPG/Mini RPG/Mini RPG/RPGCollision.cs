using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_RPG
{
    class RPGCollision
    {
        public RPGCollision()
        {

        }
        public void Update()
        {
            for (int i = 0; i < TileCount; i++)
            {
                Tiles[i].location -= Party.going;
                if (Party.box().Intersects(Tiles[i].box()) && Tiles[i].collision == 1)
                {
                    if (Tiles[i].location.X > Party.location.X && Party.going.X > 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.Y -= Party.going.Y;
                            Tiles[j].location.X += Party.going.X;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.X += Party.going.X;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.X += Party.going.X;
                            }
                        }
                        Party.place.X -= Party.going.X;
                    }
                    else if (Tiles[i].location.X < Party.location.X && Party.going.X < 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.Y -= Party.going.Y;
                            Tiles[j].location.X += Party.going.X;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.X += Party.going.X;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.X += Party.going.X;
                            }
                        }
                        Party.place.X -= Party.going.X;
                    }
                    if (Tiles[i].location.Y > Party.location.Y && Party.going.Y > 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.X -= Party.going.X;
                            Tiles[j].location.Y += Party.going.Y;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.Y += Party.going.Y;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.Y += Party.going.Y;
                            }
                        }
                        Party.place.Y -= Party.going.Y;
                    }
                    else if (Tiles[i].location.Y < Party.location.Y && Party.going.Y < 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.X -= Party.going.X;
                            Tiles[j].location.Y += Party.going.Y;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.Y += Party.going.Y;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.Y += Party.going.Y;
                            }
                        }
                        Party.place.Y -= Party.going.Y;
                    }
                }
                if (Party.box().Intersects(Tiles[i].box()) && Tiles[i].collision == 4)
                {
                    if (AreRightNow == "Reatra")
                    {
                        if (Party.place.X > 1202 && Party.place.X < 1356 && Party.place.Y > 2599 && Party.place.Y < 2679)
                        {
                            Console.WriteLine("Entering Outer West Samtha Mountains");
                        }
                        if (Party.place.X < 1540 && Party.place.X > 1356 && Party.place.Y > 2599 && Party.place.Y < 2679)
                        {
                            Console.WriteLine("Entering Inner West Samtha Mountains");
                        }
                        if (Party.place.X < 3100 && Party.place.X > 2942 && Party.place.Y > 2297 && Party.place.Y < 2364)
                        {
                            Console.WriteLine("Entering Inner East Samtha Mountains");
                        }
                        if (Party.place.X > 3100 && Party.place.X < 3282 && Party.place.Y > 2288 && Party.place.Y < 2377)
                        {
                            Console.WriteLine("Entering Outer East Samtha Mountains");
                        }
                    }
                    if (Tiles[i].location.X > Party.location.X && Party.going.X > 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.Y -= Party.going.Y;
                            Tiles[j].location.X += Party.going.X;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.X += Party.going.X;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.X += Party.going.X;
                            }
                        }
                        Party.place.X -= Party.going.X;
                    }
                    else if (Tiles[i].location.X < Party.location.X && Party.going.X < 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.Y -= Party.going.Y;
                            Tiles[j].location.X += Party.going.X;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.X += Party.going.X;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.X += Party.going.X;
                            }
                        }
                        Party.place.X -= Party.going.X;
                    }
                    if (Tiles[i].location.Y > Party.location.Y && Party.going.Y > 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.X -= Party.going.X;
                            Tiles[j].location.Y += Party.going.Y;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.Y += Party.going.Y;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.Y += Party.going.Y;
                            }
                        }
                        Party.place.Y -= Party.going.Y;
                    }
                    else if (Tiles[i].location.Y < Party.location.Y && Party.going.Y < 0)
                    {
                        for (int j = 0; j < TileCount; j++)
                        {
                            //Tiles[j].location.X -= Party.going.X;
                            Tiles[j].location.Y += Party.going.Y;
                        }
                        if (AreaMap == true)
                        {
                            for (int j = 0; j < buildingCounter; j++)
                            {
                                building[j].location.Y += Party.going.Y;
                            }
                            for (int j = 0; j < NPCCounter; j++)
                            {
                                NPCs[j].location.Y += Party.going.Y;
                            }
                        }
                        Party.place.Y -= Party.going.Y;
                    }
                }
                if (Party.box().Intersects(Tiles[i].box()) && Tiles[i].collision == 2)
                {
                    //WereJustBefore = AreRightNow;
                    //ContinentalMap = false;
                    //AreaMap = true;
                    //Encounters = false;

                    //WereJustBefore = AreRightNow;
                    if (AreRightNow == "Iminia")
                    {
                        if (Party.place.X < 100 && Party.place.Y > 3300)
                        {//Tiarma
                            Console.WriteLine("Entering Tiarma");
                            AreRightNow = "Tiarma";
                            /*Are = "Tiarma";*/
                            Are = "Iminia";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            //Console.WriteLine(Party);
                            EnterStore();
                        }
                        if (Party.place.X > 2940 && Party.place.Y > 3200)
                        {//Norve
                            Console.WriteLine("Entering Norve");
                            //AreRightNow = "Norve";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (Diabolus == true)
                            {
                                AreRightNow = "Coul";
                                WereJustBefore = "Karnapp";
                            }
                            else
                            {
                                AreRightNow = "Iminia";
                                WereJustBefore = "Norve";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "Please! Defeat Diabolus in the town north of here! Help us!";
                                Crying = true;
                            }
                        }
                        if (Party.place.Y < 1500 && Party.place.Y > 1300)
                        {//HarnN
                            Console.WriteLine("Entering North Harn");
                            //AreRightNow = "Harn";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Iminia";
                            WereJustBefore = "SouthHarn";
                        }
                        if (Party.place.Y < 1800 && Party.place.Y > 1500)
                        {//HarnS
                            Console.WriteLine("Entering South Harn");
                            //AreRightNow = "Harn";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Iminia";
                            WereJustBefore = "NorthHarn";
                        }
                        if (Party.place.Y < 1000)
                        {//Darkan
                            Console.WriteLine("Entering Darkan");
                            WereJustBefore = "Darkan";
                            if (Diabolus == false || Doom == true)
                            {
                                PlannedEncounter(0, new Vector2(75, 150));
                            }
                        }
                    }
                    else if (AreRightNow == "Coul")
                    {
                        if (Party.place.X > 1960 && Party.place.Y < 500)
                        {//Karnapp
                            Console.WriteLine("Entering Karnapp");
                            //AreRightNow = "Karnapp";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Iminia";
                            WereJustBefore = "Norve";
                        }
                        else if (Party.place.X > 1700 && Party.place.Y > 3400)
                        {//Quirtaff
                            Console.WriteLine("Entering Quirtaff");
                            //AreRightNow = "Quirtaff";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (Winter == true && Mech == true)
                            {
                                AreRightNow = "Roswary";
                                WereJustBefore = "CoulBoat";
                            }
                            else
                            {
                                AreRightNow = "Coul";
                                WereJustBefore = "Quirtaff";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                if (Winter == false)
                                {
                                    texts[400] = "Please! Defeat the monster in the town inside the forests in the mountains! Help us!";
                                }
                                else
                                {
                                    texts[400] = "We can't allow you to go here yet... It's too dangerous.";
                                }
                                Crying = true;
                            }
                        }
                        else if (Party.place.X < 700 && Party.place.Y > 3500)
                        {//Orkayn
                            Console.WriteLine("Entering Orkayn");
                            //AreRightNow = "Orkayn";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (Winter == true)
                            {
                                AreRightNow = "Seastum";
                                WereJustBefore = "Kiman";
                            }
                            else
                            {
                                AreRightNow = "Coul";
                                WereJustBefore = "Orkayn";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "Please! Defeat the monster in the town inside the forests in the mountains! Help us!";
                                Crying = true;
                            }
                        }
                        else if (Party.place.X < 400 && Party.place.Y < 1500)
                        {//Oracle
                            Console.WriteLine("Entering the Oracles house");
                            AreRightNow = "Oracle";
                            Are = "Coul";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                        else
                        {
                            Console.WriteLine("Entering Kostandivor");
                            WereJustBefore = "KostandivorForest";
                            if (Winter == false || Doom == true)
                            {
                                PlannedEncounter(16, new Vector2(50, 70));
                            }
                        }
                    }
                    else if (AreRightNow == "Kragonya")
                    {
                        if (Party.place.Y > 3500)
                        {//Shorea
                            Console.WriteLine("Entering Shorea");
                            //AreRightNow = "Shorea";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Reatra";
                            WereJustBefore = "Partive";
                        }
                        if (Party.place.Y < 2900 && Party.place.Y > 2700)
                        {//South Smildev
                            Console.WriteLine("Entering South Smildev");
                            AreRightNow = "Smildev";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Kragonya";
                            WereJustBefore = "NorthSmildev";
                        }
                        if (Party.place.Y < 2700 && Party.place.Y > 2400)
                        {//North Smildev
                            Console.WriteLine("Entering North Smildev");
                            AreRightNow = "Smildev";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Kragonya";
                            WereJustBefore = "SouthSmildev";
                        }
                        if (Party.place.X < 1500 && Party.place.Y < 1000)
                        {//Parthay
                            Console.WriteLine("Entering Parthay");
                            //AreRightNow = "Parthay";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (Mech == true)
                            {
                                AreRightNow = "Roswary";
                                WereJustBefore = "KragonyaCamp";
                            }
                            else
                            {
                                AreRightNow = "Kragonya";
                                WereJustBefore = "Parthay";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "You must aid us! A giant robot is going frenzy in the capital west of here!";
                                Crying = true;
                            }
                        }
                        if (Party.place.X > 3400 && Party.place.Y < 500)
                        {//Kief
                            Console.WriteLine("Entering Kief");
                            AreRightNow = "Kief";
                            Are = "Kragonya";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                        if (Party.place.X < 3300 && Party.place.X > 2600 && Party.place.Y > 800 && Party.place.Y < 1450)
                        {//Arthana
                            if (Party.place.X > 2978 && Party.going.X < 0)
                            {//East
                                Console.WriteLine("Entering East Arthana");
                                WereJustBefore = "ArthanaW";
                                if (Mech == false || Doom == true)
                                {
                                    PlannedEncounter(44, new Vector2(30, 60));
                                }
                            }
                            if (Party.place.X < 2978 && Party.going.X > 0)
                            {//West
                                Console.WriteLine("Entering West Arthana");
                                WereJustBefore = "ArthanaE";
                                if (Mech == false || Doom == true)
                                {
                                    PlannedEncounter(44, new Vector2(30, 60));
                                }
                            }
                            if (Party.place.Y > 1107 && Party.going.Y < 0)
                            {//South
                                Console.WriteLine("Entering South Arthana");
                                WereJustBefore = "ArthanaN";
                                if (Mech == false || Doom == true)
                                {
                                    PlannedEncounter(44, new Vector2(30, 60));
                                }
                            }
                            if (Party.place.Y < 1107 && Party.going.Y > 0)
                            {//North
                                Console.WriteLine("Entering North Arthana");
                                WereJustBefore = "ArthanaS";
                                if (Mech == false || Doom == true)
                                {
                                    PlannedEncounter(44, new Vector2(30, 60));
                                }
                            }
                        }
                    }
                    else if (AreRightNow == "Roswary")
                    {
                        if (Party.place.X < 2109 && Party.place.Y > 1410)
                        {//Ikratan
                            Console.WriteLine("Entering Ikratan");
                            //AreRightNow = "Ikratan";
                            AreRightNow = "Roswary";
                            WereJustBefore = "Ikratan";
                            if (GigaTyrmadite == false || Doom == true)
                            {
                                PlannedEncounter(57, new Vector2(20, 40));
                            }
                        }
                        if (Party.place.X < 600 && Party.place.X > 69)
                        {//Coul Camp
                            Console.WriteLine("Entering Coul Military Camp");
                            AreRightNow = "CoulCamp";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Reatra";
                            WereJustBefore = "Trowd";
                        }
                        if (Party.place.X < 69)
                        {//Coul Dock
                            Console.WriteLine("Entering Coul Docks");
                            //AreRightNow = "CoulDock";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Coul";
                            WereJustBefore = "Quirtaff";
                        }
                        if (Party.place.X > 3140 && Party.place.Y > 915)
                        {//Kragonya Camp
                            Console.WriteLine("Entering Kragonyan Military Camp");
                            //AreRightNow = "KragonyaCamp";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Kragonya";
                            WereJustBefore = "Parthay";
                        }
                        if (Party.place.X > 3140 && Party.place.Y < 915)
                        {//Tranpas Island
                            Console.WriteLine("Entering Tranpas Island");
                            AreRightNow = "Tranpas";
                        }
                        if (Party.place.X < 1720 && Party.place.Y < 125)
                        {//Fishermens Outpost
                            Console.WriteLine("Entering The Fishermens Outpost");
                            AreRightNow = "Fisherhouse";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (GigaTyrmadite == true && Mech == true)
                            {
                                AreRightNow = "Yllessrey";
                                WereJustBefore = "YllessreyDock";
                            }
                            else
                            {
                                AreRightNow = "Roswary";
                                WereJustBefore = "Fisherhouse";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "A true evil waits beyond here. Can't let you pass unless you destroy all evils attacking towns around here.";
                                Crying = true;
                            }
                        }
                        if (Party.place.X < 2265 && Party.place.X > 2050)
                        {//Kyorth
                            Console.WriteLine("Entering Kyorth's House");
                            AreRightNow = "Kyorth";
                            Are = "Roswary";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                    }
                    else if (AreRightNow == "Reatra")
                    {
                        if (Party.place.X < 1650 && Party.place.Y < 480)
                        {//Trowd
                            Console.WriteLine("Entering Trowd");
                            //AreRightNow = "Trowd";
                            AreaMap = false;
                            Encounters = true;
                            ContinentalMap = true;
                            if (Mech == true && KingTank == true)
                            {
                                AreRightNow = "Roswary";
                                WereJustBefore = "CoulCamp";
                            }
                            else
                            {
                                AreRightNow = "Reatra";
                                WereJustBefore = "Trowd";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                if (KingTank == false)
                                {
                                    texts[400] = "Our king has gone mad with the new technology! Please help us bring him down!";
                                }
                                else
                                {
                                    texts[400] = "Em... Great saviors... Past here is a land to dangerous to cross, even for you. Sorry.";
                                }
                                Crying = true;
                            }
                        }
                        if (Party.place.X < 2222 && Party.place.X > 1850)
                        {//West Remarta
                            Console.WriteLine("Entering West Remarta");
                            WereJustBefore = "EastRemarta";
                            if (KingTank == false || Doom == true)
                            {
                                PlannedEncounter(35, new Vector2(-30, 100));
                            }
                        }
                        if (Party.place.X < 2630 && Party.place.X > 2222)
                        {//East Remarta
                            Console.WriteLine("Entering East Remarta");
                            WereJustBefore = "WestRemarta";
                            if (KingTank == false || Doom == true)
                            {
                                PlannedEncounter(35, new Vector2(-30, 100));
                            }
                        }
                        if (Party.place.X > 3160 && Party.place.Y < 162)
                        {//Partive
                            Console.WriteLine("Entering Partive");
                            //AreRightNow = "Partive";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            if (KingTank == true)
                            {
                                AreRightNow = "Kragonya";
                                WereJustBefore = "Shorea";
                            }
                            else
                            {
                                AreRightNow = "Reatra";
                                WereJustBefore = "Partive";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "Our king has gone mad with the new technology! Please help us bring him down!";
                                Crying = true;
                            }
                        }
                        if (Party.place.X > 4000)
                        {//Murgas
                            Console.WriteLine("Entering Murgas House");
                            AreRightNow = "Murgas";
                            Are = "Reatra";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                        if (Party.place.X < 450 && Party.place.Y > 3700)
                        {//Border
                            Console.WriteLine("Entering Border");
                            //AreRightNow = "Border";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Seastum";
                            WereJustBefore = "SouthBorder";
                        }
                        if (Party.place.X < 520 && Party.place.Y < 2880 && Party.place.Y > 2400)
                        {//Wallentah
                            Console.WriteLine("Entering Wallentah");
                            AreRightNow = "Wallentah";
                            Are = "Reatra";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                    }
                    else if (AreRightNow == "Seastum")
                    {
                        if (Party.place.X > 3440 && Party.place.Y < 1800)
                        {//Border
                            Console.WriteLine("Entering Border");
                            //AreRightNow = "Border";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            Console.WriteLine("Desert == " + Desert);
                            if (Desert == true)
                            {
                                AreRightNow = "Reatra";
                                WereJustBefore = "NorthBorder";
                            }
                            else
                            {
                                AreRightNow = "Seastum";
                                WereJustBefore = "SouthBorder";
                                textPlace[400].X = 50;
                                textPlace[400].Y = 50;
                                texts[400] = "... Our capital is being ravaged by a giant storm. Call me crazy, but I thought I saw eyes in it...";
                                Crying = true;
                            }
                        }
                        if (Party.place.X < 780 && Party.place.Y < 2080)
                        {//Kiman
                            Console.WriteLine("Entering Kiman");
                            //AreRightNow = "Kiman";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Coul";
                            WereJustBefore = "Orkayn";
                        }
                        if (Party.place.X > 2250 && Party.place.Y > 3500)
                        {//Gertan
                            Console.WriteLine("Entering Gertan");
                            AreRightNow = "Gertan";
                            Are = "Seastum";
                            convCounter = 0;
                            cent = true;
                            charFile = 0;
                            menuNumb = 1;
                            WorldMap = false;
                            texts[1] = AreRightNow;
                            textPlace[1].X = 55;
                            textPlace[1].Y = 30;
                            //Shopping = true;
                            TownMenu = true;
                            Conversation3 = true;
                            EnterStore();
                            //Console.WriteLine(Party);
                        }
                        if (Party.place.X < 2824 && Party.place.X > 2654)
                        {//East Egerta
                            Console.WriteLine("Entering East Egerta");
                            WereJustBefore = "WestEgerta";
                            if (Desert == false || Doom == true)
                            {
                                PlannedEncounter(25, new Vector2(-180, -280));
                            }
                        }
                        if (Party.place.X < 2246 && Party.place.X > 2000)
                        {//West Egerta
                            Console.WriteLine("Entering West Egerta");
                            WereJustBefore = "EastEgerta";
                            if (Desert == false || Doom == true)
                            {
                                PlannedEncounter(25, new Vector2(-180, -280));
                            }
                        }
                        if (Party.place.Y < 2229 && Party.place.Y > 2059)
                        {//South Egerta
                            Console.WriteLine("Entering South Egerta");
                            WereJustBefore = "EastEgerta";
                            if (Desert == false || Doom == true)
                            {
                                PlannedEncounter(25, new Vector2(-180, -280));
                            }
                        }
                    }
                    else if (AreRightNow == "Yllessrey")
                    {
                        if (Party.place.X > 336 && Party.place.Y > 448)
                        {//Boat
                            Console.WriteLine("Entering Docks");
                            //AreRightNow = "YllessreyDock";
                            AreaMap = false;
                            ContinentalMap = true;
                            Encounters = true;
                            AreRightNow = "Roswary";
                            WereJustBefore = "Fisherhouse";
                        }
                        else
                        {//City
                            Console.WriteLine("Entering City");
                            WereJustBefore = "YllessreyCity";
                            PlannedEncounter(60, new Vector2(-10, -100));
                        }
                    }
                    else if (InteriorMap == true)
                    {
                        WereJustBefore = "House";
                        //Are = "";
                        InteriorMap = false;
                        AreaMap = true;
                    }
                    LoadArea();
                }
            }
        }
    }
}
