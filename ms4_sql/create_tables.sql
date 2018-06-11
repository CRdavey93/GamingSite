--Create the Users Table
CREATE TABLE [dbo].[Users] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[UsersDate] datetime NOT NULL DEFAULT GETDATE(),
	[Username] varchar(20) NOT NULL UNIQUE CHECK(LEN([username]) > 5),
	[Email] varchar(60) NOT NULL UNIQUE CHECK(LEN([email]) > 5),
	[Password] varchar(20) NOT NULL CHECK(LEN([password]) > 5),
	[UserType] varchar(7) NOT NULL CHECK([UserType] = 'Admin' OR [UserType] = 'Shopper')
);

--Create the Categories Table
CREATE TABLE [dbo].[Categories] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(20) NOT NULL UNIQUE,
	[IconUrl] varchar(100) NOT NULL,
	[CategoryOrder] int NOT NULL UNIQUE
);

--Create the Publishers Table
CREATE TABLE [dbo].[Publishers] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(20) NOT NULL UNIQUE
);

--Create the Products Table
CREATE TABLE [dbo].[Products] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(20) NOT NULL,
	[Description] varchar(200) NOT NULL,
	[ImageUrl] varchar(100) NOT NULL,
	[Price] money NOT NULL,
	[ReleaseDate] datetime NOT NULL,
	[Featured] bit NOT NULL DEFAULT 0,
	[CategoryID] int NOT NULL,
	[PublisherID] int NOT NULL,
	CONSTRAINT [FKProductsCategories] FOREIGN KEY ([CategoryID]) REFERENCES [Categories]([ID]),
	CONSTRAINT [FKProductsPublishers] FOREIGN KEY ([PublisherID]) REFERENCES [Publishers]([ID])
);

--Create the Promotions Table
CREATE TABLE [dbo].[Promotions] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(20) NOT NULL,
	[Description] varchar(200) NOT NULL,
	[StartDate] datetime NOT NULL,
	[EndDate] datetime NOT NULL,
	[DateCreated] datetime NOT NULL DEFAULT GETDATE(),
	[SalePrice] money,
	[OverallDiscountAmount] money,
	[Zip] int,
	[PromotionType] varchar(13) NOT NULL CHECK([PromotionType] IN ('Product','Overall','Free Shipping')),
	CONSTRAINT [EndStartDate] CHECK([EndDate] >= [StartDate])
);

--Create the Carts Table
CREATE TABLE [dbo].[Carts] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Status] varchar(9) NOT NULL CHECK([Status] IN ('New', 'Abandoned', 'Purchased')),
	[DateCreated] datetime NOT NULL DEFAULT GETDATE(),
	[UserID] int NOT NULL UNIQUE,
	[Zip] int,
	CONSTRAINT [FKCartsUsers] FOREIGN KEY ([UserID]) REFERENCES [Users]([ID])
);

--Create the CartsProducts Table
CREATE TABLE [dbo].[CartsProducts] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[CartID] int NOT NULL,
	[ProductID] int NOT NULL,
	[Quantity] int NOT NULL,
	CONSTRAINT [FKCartsProductsCarts] FOREIGN KEY ([CartID]) REFERENCES [Carts]([ID]),
	CONSTRAINT [FKCartsProductsProducts] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ID])	
);

--Create the CartsPromotions Table
CREATE TABLE [dbo].[CartsPromotions] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[PromotionID] int NOT NULL,
	[CartID] int NOT NULL,
	[ProductID] int,
	CONSTRAINT [FKCartsPromotionsCarts] FOREIGN KEY ([CartID]) REFERENCES [Carts]([ID]),
	CONSTRAINT [FKCartsPromotionsPromotions] FOREIGN KEY ([PromotionID]) REFERENCES [Promotions]([ID]),
	CONSTRAINT [FKCartsPromotionsProducts] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ID])
);

--Create the PurchasedTogetherProducts Table
--This table has an entry for each item that is bought together
CREATE TABLE [dbo].[PurchasedTogetherProducts] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Product1] int NOT NULL,
	[Product2] int NOT NULL,
	CONSTRAINT [FKPurchasedTogetherProductsProducts1] FOREIGN KEY ([Product1]) REFERENCES [Products]([ID]),
	CONSTRAINT [FKPurchasedTogetherProductsProducts2] FOREIGN KEY ([Product2]) REFERENCES [Products]([ID])
)

--Create the RelatedProducts Table
--This table has an entry for each item that is related
CREATE TABLE [dbo].[RelatedProducts] (
	[ID] int NOT NULL PRIMARY KEY IDENTITY,
	[Product1] int NOT NULL,
	[Product2] int NOT NULL,
	CONSTRAINT [FKRelatedProductsProducts1] FOREIGN KEY ([Product1]) REFERENCES [Products]([ID]),
	CONSTRAINT [FKRelatedProductsProducts2] FOREIGN KEY ([Product2]) REFERENCES [Products]([ID])
)