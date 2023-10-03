<?php

// Асоціативний масив “Бухгалтерія”
// (Код, ПІБ; посада; заробітна плата; кількість дітей; стаж)
// Запит працюючих, які обіймають посаду Х і мають не більше, ніж Y дітей.



//4. Передбачити можливість передачі параметрів запиту через рядок стану (наприклад index.php?country=ukraine&min_age=18)

//6. Створити форму редагування даних про об'єкт.
//7. Перед редагуванням здійснити валідацію даних (ПІБ не може бути порожнім рядком, заробітна плата повинна бути невід'ємним числом, тощо)

$accounting = [
    'code' => null,
    'fullName' => null,
    'position' => null,
    'salary' => null,
    'child' => null,
    'experience' => null
];

$accountingList = [
    [
        'code' => 1,
        'fullName' => 'John Smith Jr.',
        'position' => 'male',
        'salary' => 3000,
        'child' => 1,
        'experience' => 4
    ],
    [
        'code' => 2,
        'fullName' => 'Emily Johnson',
        'position' => 'female',
        'salary' => 2500,
        'child' => 2,
        'experience' => 2
    ],
    [
        'code' => 3,
        'fullName' => 'David Wilson III',
        'position' => 'male',
        'salary' => 3600,
        'child' => 1,
        'experience' => 4
    ],
    [
        'code' => 4,
        'fullName' => 'Sarah Davis',
        'position' => 'female',
        'salary' => 5000,
        'child' => 3,
        'experience' => 6
    ],
    [
        'code' => 5,
        'fullName' => 'Michael Brown Sr.',
        'position' => 'male',
        'salary' => 2000,
        'child' => 2,
        'experience' => 1
    ],
];

if (isset($_POST['add_account'])) {
    $accountingList[] = [
        'code' => $_POST['code'] ?? '',
        'fullName' => $_POST['fullName'] ?? '',
        'position' => $_POST['position'] ?? '',
        'salary' => $_POST['salary'] ?? '',
        'child' => $_POST['child'] ?? '',
        'experience' => $_POST['experience'] ?? '',

    ];
}

$accountingList = array_filter($accountingList, function ($element) {
    $return_flag = true;
    if (isset($_GET['position']) && $element['position'] != $_GET['position']) {
        $return_flag = false;
    }
    if ($return_flag && isset($_GET['child']) && $element['child'] != $_GET['child']) {
        $return_flag = false;
    }
    return $return_flag;
});

include 'templates/accounting_table.phtml';
if (isset($_POST['edit'])) {
    include 'templates/accounting_form_editing.phtml';
}
else{
    include 'templates/accounting_form_create.phtml';
}

