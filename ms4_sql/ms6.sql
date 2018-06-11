select * from Promotions;

ALTER TABLE Promotions ADD ProductID int FOREIGN KEY REFERENCES Products(ID);
--Our Carts Promotions Table already had a CartID column with the exact specifications
ALTER TABLE CartsPromotions DROP FKCartsPromotionsProducts;
ALTER TABLE CartsPromotions DROP COLUMN ProductID;
--Name is not long enough
ALTER TABLE Products ALTER COLUMN Name varchar(40);
--Add first and last name
ALTER TABLE Users ADD FirstName varchar(50);
ALTER TABLE Users ADD LastName varchar(50);

UPDATE Products SET ImageUrl = '/Content/Images/Products/xboxone/fifa16.jpg' WHERE Featured = 1;
UPDATE Categories SET IconUrl = 'Content/Images/Icons/' + SUBSTRING(IconUrl, 8, 10000);

--We already have 20 Categories from the Previous Milestone

INSERT INTO Publishers(Name)
	VALUES ('Konami'),
	('Warner Brothers'),
	('Microsoft'),
	('Nintendo');

DELETE FROM Products WHERE ID != 1;

--Already exists product entry for Fifa 16 from last Milestone
INSERT INTO Products(Name, Description, ImageUrl, Price, ReleaseDate, Featured, CategoryID, PublisherId) VALUES 
    ('Halo 5', 'Get ready for the next Halo game as the story continues in one of the most iconic shooters of all time', '/Content/Images/Products/xboxone/halo5.jpg', 59.99, '10/27/15', 0, 1, 4),
	('Halo Master Chief Collection', 'Replay the legendary Halo games in stunning HD on Xbox One', '/Content/Images/Products/xboxone/halomasterchiefcollection.jpg', 59.99, '11/11/14', 0, 1, 4),
	('Lego The Hobbit', 'Adventure through the story of the Hobbit Lego Style!', '/Content/Images/Products/xboxone/legothehobbit.jpg', 49.99, '4/11/14', 0, 1, 3),
	('Metal Gear Solid 5', 'Sneak around as Snake in this critically acclaimed game.', '/Content/Images/Products/xboxone/metalgearsolid5.jpg', 59.99, '9/1/15', 0, 1, 2),
	('Minecraft', 'Build your Kingdom out of whatever you like in this expansive mining and world-creation game.', '/Content/Images/Products/xboxone/minecraft.jpg', 19.99, '9/5/14', 0, 1, 4),
	('NBA Live 14', 'Play pickup games or try to lead your team to the NBA Championship.', '/Content/Images/Products/xboxone/nbalive14.jpg', 39.99, '11/9/13', 0, 1, 1),
	('Need for Speed Rivals', 'Race your rivals as you aim to have the best skills and car.', '/Content/Images/Products/xboxone/needforspeedrivals.jpg', 59.99, '11/15/13', 0, 1, 1),
	('NHL 15', 'Take to the Ice in NHL 15.', '/Content/Images/Products/xboxone/nhl15.jpg', 59.99, '9/9/14', 0, 1, 1),
	('Star Wars Battlefront', 'Play the remake of the original highly successful Star Wars Battlefront.', '/Content/Images/Products/xboxone/swbattlefront.png', 59.99, '11/17/15', 0, 1, 1),
	('Donkey Kong Country Tropical Freeze', 'Retake Donkey Island from the Northern invaders.', '/Content/Images/Products/wiiu/donkeykongcountrytropicalfreeze.jpg', 49.99, '2/13/14', 0, 2, 5),
	('Hyrule Warriors', 'Default tons of enemies as characters from the Legend of Zelda.', '/Content/Images/Products/wiiu/hyrulewarriors.jpg', 49.99, '8/14/14', 0, 2, 5),
	('Lego City Undercover', 'Explore and save the Lego world as an undercover cop.', '/Content/Images/Products/wiiu/legocityundercover.png', 49.99, '3/18/13', 0, 2, 5),
	('Mario Kart 8', 'Race your friends in person and online in the best Mario Kart yet.', '/Content/Images/Products/wiiu/mariokart8.jpg', 59.99, '5/29/14', 0, 2, 5),
	('Mario Maker', 'Always dreamed of making your own Mario levels? Now you finally can!', '/Content/Images/Products/wiiu/mariomaker.jpg', 59.99, '9/11/15', 0, 2, 5),
	('New Super Mario Bros. Wii U', 'Save Princess Peach again in the latest return to the 2D Mushroom Kingdom', '/Content/Images/Products/wiiu/newsupermariobroswiiu.jpg', 59.99, '11/18/12', 0, 2, 5),
	('Splatoon', 'Cover the course with as much ink as possible to win!', '/Content/Images/Products/wiiu/splatoon.png', 59.99, '5/28/15', 0, 2, 5),
	('Super Mario 3D World', 'Explore the 3D Mushroom Kingdom and defeat Bowser in this brilliant game.', '/Content/Images/Products/wiiu/supermario3dworld.jpg', 59.99, '11/21/13', 0, 2, 5),
	('Super Smash Bros. Wii U', 'Compete to be the best with your friends as you fight as the best Nintendo chacters.', '/Content/Images/Products/wiiu/supersmashbroswiiu.png', 59.99, '9/13/14', 0, 2, 5),
	('The Legend of Zelda: The Wind Waker HD', 'Embark on this classic Zelda Adventure in HD.', '/Content/Images/Products/wiiu/windwakerhd.jpg', 49.99, '9/20/13', 0, 2, 5);

INSERT INTO Promotions(Name, Description, StartDate, EndDate, SalePrice, Zip, PromotionType, ProductId) VALUES
	('Smashing November', 'Small Price, hours of Smash Bros. this November!', '11/1/15', '12/1/15', 29.99, 01984, 'Product', 19),
	('Middle Earth October', 'Enjoy a great adventure, not a great price!', '10/1/15', '10/31/15', 19.99, 01984, 'Product', 4);