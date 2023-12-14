/*e) Запит з використанням обчислювального поля: */

/*  середній бал студентів разом із різницею від максимального балу*/

SELECT [AverageGrade], [AverageGrade] - (SELECT MAX([AverageGrade]) FROM Students) AS 'Різниця від максимального балу' FROM Students;
