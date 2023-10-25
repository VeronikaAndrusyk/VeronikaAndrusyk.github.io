<?php

$students = array(
    array('id' => 1, 'name' => 'Іванов Іван', 'course' => 2, 'specialty' => 'Інформатика'),
    array('id' => 2, 'name' => 'Петров Петро', 'course' => 3, 'specialty' => 'Математика'),
    array('id' => 3, 'name' => 'Сидорова Марія', 'course' => 1, 'specialty' => 'Фізика'),
    array('id' => 4, 'name' => 'Ковальчук Олександра', 'course' => 4, 'specialty' => 'Хімія'),
    array('id' => 5, 'name' => 'Семенчук Володимир', 'course' => 2, 'specialty' => 'Біологія')
);


$file = fopen('students.csv', 'w');


fputcsv($file, array('ID', 'ПІБ', 'Курс', 'Спеціальність'));


foreach ($students as $student) {
    fputcsv($file, $student);
}


fclose($file);

echo "Дані було успішно збережено в файлі students.csv";
?>
