-- Введення року з клавіатури
DECLARE @rok INT;
SET @rok = 2000;

-- Виведення сумарної ціни книг
SELECT SUM(priсe) AS sumarna_tsina
FROM Biblioteka
WHERE kilkist_storinok BETWEEN 100 AND 200 AND year = @rok;
