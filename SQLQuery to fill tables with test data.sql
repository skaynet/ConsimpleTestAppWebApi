USE [ConsimpleTestDB]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [FullName], [DateBirth], [DateRegistration]) VALUES (2, N'Уильям Генри Гейтс III', CAST(N'1955-10-28' AS Date), CAST(N'2025-02-14' AS Date))
GO
INSERT [dbo].[Customer] ([Id], [FullName], [DateBirth], [DateRegistration]) VALUES (4, N'Стивен Пол Джобс', CAST(N'1955-02-24' AS Date), CAST(N'2025-02-15' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchases] ON 
GO
INSERT [dbo].[Purchases] ([Id], [Date], [TotalCost], [CustomerId]) VALUES (2, CAST(N'2025-02-14' AS Date), 200, 2)
GO
INSERT [dbo].[Purchases] ([Id], [Date], [TotalCost], [CustomerId]) VALUES (3, CAST(N'2025-02-15' AS Date), 9000, 2)
GO
INSERT [dbo].[Purchases] ([Id], [Date], [TotalCost], [CustomerId]) VALUES (4, CAST(N'2025-02-16' AS Date), 100500, 4)
GO
SET IDENTITY_INSERT [dbo].[Purchases] OFF
GO
SET IDENTITY_INSERT [dbo].[Сategory] ON 
GO
INSERT [dbo].[Сategory] ([Id], [Name]) VALUES (1, N'Операционные системы')
GO
INSERT [dbo].[Сategory] ([Id], [Name]) VALUES (2, N'Сматрфоны')
GO
SET IDENTITY_INSERT [dbo].[Сategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Name], [СategoryId], [Article], [Price]) VALUES (1, N'Windows 10', 1, N'HAJ-00083', 100)
GO
INSERT [dbo].[Products] ([Id], [Name], [СategoryId], [Article], [Price]) VALUES (2, N'Xiaomi Poco X3 Pro', 2, N'SKU123', 9000)
GO
INSERT [dbo].[Products] ([Id], [Name], [СategoryId], [Article], [Price]) VALUES (3, N'Apple iPhone 11', 2, N'SKU321', 100500)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseProducts] ON 
GO
INSERT [dbo].[PurchaseProducts] ([Id], [PurchaseId], [ProductId], [Amount]) VALUES (1, 2, 1, 2)
GO
INSERT [dbo].[PurchaseProducts] ([Id], [PurchaseId], [ProductId], [Amount]) VALUES (2, 3, 2, 1)
GO
INSERT [dbo].[PurchaseProducts] ([Id], [PurchaseId], [ProductId], [Amount]) VALUES (3, 4, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[PurchaseProducts] OFF
GO
