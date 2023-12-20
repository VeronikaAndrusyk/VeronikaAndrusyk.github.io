-- Виведення прізвища автора, назви книги та року видання за кодом
SELECT surname, title, year FROM Biblioteka WHERE kod = 1;

-- Введення року з клавіатури (замість X)
DECLARE @rok INT;
SET @rok = 2000;

-- Виведення сумарної ціни книг зі сторінками від 100 до 200 та виданих у введеному році
SELECT SUM(prise) AS sumarna_tsina
FROM Biblioteka
WHERE kilkist_storinok BETWEEN 100 AND 200 AND year = @rok;