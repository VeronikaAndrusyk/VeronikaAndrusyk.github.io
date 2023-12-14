/*b) запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;*/


/* студенти з факультету 'Фізика' та прізвище починається на 'Петр'*/
  SELECT * FROM Students WHERE  [Group] = 'A123' AND [City] LIKE 'Ки%';

/* студенти, у яких місце роботи не вказане */
  SELECT * FROM Students WHERE [Workplace] IS NULL;


/* студенти з групи 'A123' і 'B456'*/
  SELECT * FROM Students WHERE [Group] IN ('A123', 'B456');


/* Вибрати студентів, які народилися від 1998 до 2000 року*/
  SELECT * FROM Students WHERE [BirthYear] BETWEEN 1998 AND 2000;
