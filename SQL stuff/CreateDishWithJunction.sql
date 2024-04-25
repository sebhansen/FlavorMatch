-- Replace all with actual name/type etc.
DECLARE @dishName NVARCHAR(100) = 'Tomato S';
DECLARE @dishDescription NVARCHAR(255) = 'Description of the new dish';
DECLARE @dishRecipe NVARCHAR(MAX) = 'Recipe for the new dish';
DECLARE @dishType NVARCHAR(50) = 'Type of the new dish';
DECLARE @dishOrigin NVARCHAR(50) = 'Origin of the new dish';
DECLARE @dishImage NVARCHAR(255) = 'image_url.jpg';

-- Insert the new dish into the Dishes table
INSERT INTO Dishes (Name, Description, Recipe, Type, Origin, Image)
VALUES (@dishName, @dishDescription, @dishRecipe, @dishType, @dishOrigin, @dishImage);

-- Get the ID of the newly inserted dish
DECLARE @dishId INT;
SET @dishId = SCOPE_IDENTITY();

-- Insert the associated ingredients into the DishesIngredients junction table
INSERT INTO DishesIngredients (DishId, IngredientId)
VALUES
    -- Replace the numbers with the actual IngredientIds for the ingredients of the new dish
	-- Remember to remove or add extra ingredients if needed
    (@dishId, 1),  -- Example IngredientId
    (@dishId, 2),  -- Example IngredientId
    (@dishId, 3);  -- Example IngredientId
