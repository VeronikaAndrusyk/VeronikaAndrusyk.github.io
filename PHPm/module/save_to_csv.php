<?php
// Приклад даних студентів
$students = array(
    array('id' => 1, 'name' => 'Іванов Іван', 'course' => 2, 'specialty' => 'Інформатика'),
    array('id' => 2, 'name' => 'Петров Петро', 'course' => 3, 'specialty' => 'Математика'),
    array('id' => 3, 'name' => 'Сидорова Марія', 'course' => 1, 'specialty' => 'Фізика'),
    array('id' => 4, 'name' => 'Ковальчук Олександра', 'course' => 4, 'specialty' => 'Хімія'),
    array('id' => 5, 'name' => 'Семенчук Володимир', 'course' => 2, 'specialty' => 'Біологія')
);

// Відкриття файлу для запису
$file = fopen('students.csv', 'w');

// Запис заголовків у файл
fputcsv($file, array('ID', 'ПІБ', 'Курс', 'Спеціальність'));

// Запис даних про студентів у файл
foreach ($students as $student) {
    fputcsv($file, $student);
}

// Закриття файлу
fclose($file);

echo "Дані було успішно збережено в файлі students.csv";
?>
