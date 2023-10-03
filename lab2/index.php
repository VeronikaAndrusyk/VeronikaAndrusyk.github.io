<?php

$accounting = [
    'code' => null,
    'fullName' => null,
    'position' => null,
    'salary' => null,
    'child' => null,
    'experience' => null
];

function getData()
{
    $json_data = file_get_contents("data.json"); // отримуєм масив з файла коли зп

    $accountingList = json_decode($json_data, true); // перетворю рядок на масив і записує в $accountingList

}

getData();

//$accountingList = [
//    [
//        'code' => 1,
//        'fullName' => 'John Smith Jr.',
//        'position' => 'male',
//        'salary' => 3000,
//        'child' => 1,
//        'experience' => 4
//    ],
//    [
//        'code' => 2,
//        'fullName' => 'Emily Johnson',
//        'position' => 'female',
//        'salary' => 2500,
//        'child' => 2,
//        'experience' => 2
//    ],
//    [
//        'code' => 3,
//        'fullName' => 'David Wilson III',
//        'position' => 'male',
//        'salary' => 3600,
//        'child' => 1,
//        'experience' => 4
//    ],
//    [
//        'code' => 4,
//        'fullName' => 'Sarah Davis',
//        'position' => 'female',
//        'salary' => 5000,
//        'child' => 3,
//        'experience' => 6
//    ],
//    [
//        'code' => 5,
//        'fullName' => 'Michael Brown Sr.',
//        'position' => 'male',
//        'salary' => 2000,
//        'child' => 2,
//        'experience' => 1
//    ],
//];

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


if (isset($_POST['edit_account'])) {
    // Отримуємо ID рядка для редагування
    $idToEdit = $_POST['edit_id'];

    // Отримуємо дані з форми редагування
    $editedCode = $_POST['code'];
    $editedFullName = $_POST['fullName'];
    $editedPosition = $_POST['position'];
    $editedSalary = $_POST['salary'];
    $editedChild = $_POST['child'];
    $editedExperience = $_POST['experience'];

    // Змінюємо запис в масиві $accounting з відповідним кодом
    foreach ($accountingList as $key => $account) {
        if ($account['code'] == $idToEdit) {
            $accountingList[$key]['fullName'] = $editedFullName;
            $accountingList[$key]['position'] = $editedPosition;
            $accountingList[$key]['salary'] = $editedSalary;
            $accountingList[$key]['child'] = $editedChild;
            $accountingList[$key]['experience'] = $editedExperience;
            break;
        }
    }
}

function saveData($accountingList)
{
    $json = json_encode($accountingList);
    file_put_contents("data.json",$json);
}
saveData($accountingList);

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

