function Enterprise(code, name, quantityEmployees, branch, address) {
    this.code = code;
    this.name = name;
    this.quantityEmployees = quantityEmployees;
    this.branch = branch;
    this.address = address;

    this.printInfo = function() {
        console.log(`Код: ${this.code}`);
        console.log(`Назва підприємства: ${this.name}`);
        console.log(`Кількість співробітників: ${this.quantityEmployees}`);
        console.log(`Галузь: ${this.branch}`);
        console.log(`Адреса: ${this.address}`);
    }
}


const business1 = new Enterprise('Код','Назва підприємства','Кількість співробітників','Галузь','Адреса');
const business2 = new Enterprise('Код','Назва підприємства','Кількість співробітників','Галузь','Адреса');
const business3 = new Enterprise('Код','Назва підприємства','Кількість співробітників','Галузь','Адреса');



business1.printInfo();
business2.printInfo();
business3.printInfo();
=======================================

function EmploymentCenter(code, name, gender, birthYear, education,specialty,dateOfEmployment) {
    this.code = code;
    this.name = name;
    this.gender =  gender;
    this.birthYear = birthYear;
    this.education = education;
    this.specialty= specialty;
    this.dateOfEmployment = dateOfEmployment;

    this.printInfo = function() {
        console.log(`Код: ${this.code}`);
        console.log(`ПІБ : ${this.name}`);
        console.log(`Стать:${this.gender}`);
        console.log(`Рік народження: ${this.birthYear}`);
        console.log(`Освіта: ${this.education}`);
        console.log(`Спеціальність: ${this.specialty}`);
        console.log(`Дата прийняття: ${this.dateOfEmployment}`);
    }
}


const employee1 = new EmploymentCenter(1, 'Імя', 'Жінка', '1987', 'Освіта','Спеціальність','Дата прийняття');
const employee2 = new EmploymentCenter(2, 'Імя', 'Чоловік', '1973', 'Освіта','Спеціальність','Дата прийняття');
const employee3 = new EmploymentCenter(3, 'Імя', 'Жінка', '1977', 'Освіта','Спеціальність');



employee1.printInfo();
employee2.printInfo();
employee3.printInfo();
=================================
function Subscriber(phoneNumber, homeAddress, owner, duration,account) {
    this.phoneNumber = phoneNumber;
    this.homeAddress = homeAddress;
    this.owner = owner;
    this.duration = duration;
    this.account = account;

    this.printInfo = function() {
        console.log(`Номер телефону: ${this.phoneNumber}`);
        console.log(`Адреса : ${this.homeAddress}`);
        console.log(`Власник:${this.owner}`);
        console.log(`Сумарна тривалість розмов: ${this.duration}`);
        console.log(`Рахунок: ${this.account}`);
    }
}


const subscriber1 = new Subscriber('Номер телефону','Адреса','Власник','Сумарна тривалість розмов','Рахунок');
const subscriber2 = new Subscriber('Номер телефону','Адреса','Власник','Сумарна тривалість розмов','Рахунок');
const subscriber3 = new Subscriber('Номер телефону','Адреса','Власник','Сумарна тривалість розмов','Рахунок');



subscriber1.printInfo();
subscriber2.printInfo();
subscriber3.printInfo();