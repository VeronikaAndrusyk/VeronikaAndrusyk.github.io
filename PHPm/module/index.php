<?php

$students = array(
    array('id' => 1, 'name' => 'Іванов Іван', 'course' => 2, 'specialty' => 'Інформатика'),
    array('id' => 2, 'name' => 'Петров Петро', 'course' => 3, 'specialty' => 'Математика'),
    array('id' => 3, 'name' => 'Сидорова Марія', 'course' => 1, 'specialty' => 'Фізика'),
    array('id' => 4, 'name' => 'Ковальчук Олександра', 'course' => 4, 'specialty' => 'Хімія'),
    array('id' => 5, 'name' => 'Семенчук Володимир', 'course' => 2, 'specialty' => 'Біологія')
);
?>

<!DOCTYPE html>
<html>
<head>
    <title>Список студентів</title>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>

<h2>Список студентів</h2>

<table>
    <tr>
        <th>ID</th>
        <th>ПІБ</th>
        <th>Курс</th>
        <th>Спеціальність</th>
    </tr>
    <?php foreach ($students as $student) : ?>
        <tr>
            <td><?php echo $student['id']; ?></td>
            <td><a href="student.php?id=<?php echo $student['id']; ?>"><?php echo $student['name']; ?></a></td>
            <td><?php echo $student['course']; ?></td>
            <td><?php echo $student['specialty']; ?></td>
        </tr>
    <?php endforeach; ?>
</table>

</body>
</html>
