CREATE TABLE DishesIngredients (
    DishId INT,
    IngredientId INT,
    PRIMARY KEY (DishId, IngredientId),
    FOREIGN KEY (DishId) REFERENCES Dishes(Id),
    FOREIGN KEY (IngredientId) REFERENCES Ingredients(Id)
);
