# Імпорт бібліотеки Pandas для роботи з даними у форматі DataFrame
import pandas as pd
# Імпорт моделі дерева рішень з бібліотеки Scikit-learn
from sklearn.tree import DecisionTreeRegressor
# Імпорт методів для розділення даних та пошуку оптимальних гіперпараметрів
from sklearn.model_selection import train_test_split, GridSearchCV
# Імпорт метрики середньоквадратичної помилки для оцінки моделі
from sklearn.metrics import mean_squared_error
# Імпорт бібліотеки для візуалізації даних
import matplotlib.pyplot as plt  # Імпорт бібліотеки для візуалізації даних

# 1. Завантаження даних
data = pd.read_csv(r'C:\Users\Asus\Downloads\courwork\housing.csv')

# 2. Обробка даних
X = data[['housing_median_age', 'total_rooms', 'total_bedrooms', 'population', 'households', 'median_income']]
y = data['median_house_value']
# Вибір вхідних ознак (X) та цільової змінної (y) з даних для подальшого аналізу
# X - це набір ознак, що будуть використовуватися для прогнозування
# y - це цільова змінна, яку модель намагатиметься передбачити

# 3. Розділення набору даних на навчальну та тестову частини
# X - набір ознак, y - цільова змінна
# test_size=0.2 вказує, що 20% даних буде використано для тестування, а 80% - для навчання
# random_state=42 забезпечує відтворюваність результатів
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# 4. Вибір моделі дерева рішення та налаштування гіперпараметрів
param_grid = {
    'max_depth': [None, 5, 10, 15], # Перевіряємо різні максимальні глибини
    'min_samples_split': [2, 5, 10], # Перевіряємо різні мінімальні кількості зразків для розділення вузла
    'min_samples_leaf': [1, 2, 4] # Перевіряємо різні мінімальні кількості зразків у листі
}
grid_search = GridSearchCV(estimator=DecisionTreeRegressor(), param_grid=param_grid, cv=5)
grid_search.fit(X_train, y_train)
best_model = grid_search.best_estimator_

# 5. Оцінка моделі на тестових даних
y_pred = best_model.predict(X_test) #за допомогою найкращої моделі best_model, яка була попередньо
                                    # #підібрана, прогнозуються цільові значення для тестових вхідних даних X_test
mse_test = mean_squared_error(y_test, y_pred)# Цей рядок обчислює середньоквадратичну помилку між фактичними цільовими
                                             # значеннями y_test та прогнозованими значеннями y_pred на тестовому наборі даних.
print("Test Mean Squared Error:", mse_test)

# 6. Візуалізація дерева
# Визначення розміру фігури для візуалізації дерева
plt.figure(figsize=(20, 10))
# Імпорт функції plot_tree з бібліотеки sklearn.tree для візуалізації дерева рішень
from sklearn.tree import plot_tree
# Візуалізація дерева рішень
plot_tree(best_model, feature_names=X.columns, filled=True)

# Збереження зображення у файл
plt.savefig('decision_tree.png')

# Очистка буфера зображення
plt.clf()

# 7. Функція для прогнозування ціни на основі введених даних
def predict_price(housing_median_age, total_rooms, total_bedrooms, population, households, median_income):
    input_data = [[housing_median_age, total_rooms, total_bedrooms, population, households, median_income]]
    predicted_price = best_model.predict(input_data)
    return predicted_price[0]

# Введення користувачем даних
housing_median_age = float(input("Введіть медіанний вік житла: "))
total_rooms = float(input("Введіть загальну кількість кімнат: "))
total_bedrooms = float(input("Введіть загальну кількість спалень: "))
population = float(input("Введіть кількість населення (без пробілів): "))
households = float(input("Введіть кількість домогосподарств: "))
median_income = float(input("Введіть медіанний дохід: "))

# Прогнозування ціни
predicted_price = predict_price(housing_median_age, total_rooms, total_bedrooms, population, households, median_income)
print("Приблизна ціна на квартиру: $", predicted_price)



# 7. Функція для прогнозування ціни на основі введених даних
def predict_price(housing_median_age, total_rooms, total_bedrooms, population, households, median_income):
    input_data = [[housing_median_age, total_rooms, total_bedrooms, population, households, median_income]]
    predicted_price = best_model.predict(input_data)
    return predicted_price[0]

# Введення користувачем даних
housing_median_age = float(input("Введіть медіанний вік житла: "))
total_rooms = float(input("Введіть загальну кількість кімнат: "))
total_bedrooms = float(input("Введіть загальну кількість спалень: "))
population = float(input("Введіть кількість населення (без пробілів): "))
households = float(input("Введіть кількість домогосподарств: "))
median_income = float(input("Введіть медіанний дохід: "))

# Прогнозування ціни
predicted_price = predict_price(housing_median_age, total_rooms, total_bedrooms, population, households, median_income)
print("Приблизна ціна на квартиру: $", predicted_price)
