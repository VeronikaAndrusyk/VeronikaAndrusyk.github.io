<!DOCTYPE html>
<html>
<head>
    <title>Інформація про студента</title>
</head>
<body>

<?php
if (isset($_GET['id'])) {
    $students = array(
        array('id' => 1, 'name' => 'Іванов Іван', 'course' => 2, 'specialty' => 'Інформатика'),
        array('id' => 2, 'name' => 'Петров Петро', 'course' => 3, 'specialty' => 'Математика'),
        array('id' => 3, 'name' => 'Сидорова Марія', 'course' => 1, 'specialty' => 'Фізика'),
        array('id' => 4, 'name' => 'Ковальчук Олександра', 'course' => 4, 'specialty' => 'Хімія'),
        array('id' => 5, 'name' => 'Семенчук Володимир', 'course' => 2, 'specialty' => 'Біологія')
    );

    $id = $_GET['id'];
    $student = array_filter($students, function ($element) use ($id) {
        return $element['id'] == $id;
    });

    if ($student) {
        $student = reset($student);
        echo "<h2>Інформація про студента</h2>";
        echo "<p><strong>ID:</strong> " . $student['id'] . "</p>";
        echo "<p><strong>ПІБ:</strong> " . $student['name'] . "</p>";
        echo "<p><strong>Курс:</strong> " . $student['course'] . "</p>";
        echo "<p><strong>Спеціальність:</strong> " . $student['specialty'] . "</p>";

        echo "<p><a href='index.php'>Назад до списку студентів</a></p>";
    } else {
        echo "<p>Студент не знайдений.</p>";
    }
} else {
    echo "<p>Параметр ID не вказано.</p>";
}
?>

</body>
</html>
