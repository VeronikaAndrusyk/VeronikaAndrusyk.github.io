class Accountant {
  constructor(fullName, position, salary, childrenQuantity, seniority) {
    this.fullName = fullName;
    this.position = position;
    this.salary = salary;
    this.childrenQuantity = childrenQuantity;
    this.seniority = seniority;
   
  }
}

class Accountants {
  constructor() {
    this.accountants = [];
  }

  add(user) {
    if (!(user instanceof Accountant))
      throw `${user} is not an instance of Accountant`;
    this.accountants.push(user);
  }

  getById(id) {
    return this.accountants.find(user => user.code === id);
  }

  update(id, newUser) {
    let user = this.getById(id);
    if (!user)
      throw "Not found";
    for (let k of ["fullName", "position", "salary", "childrenQuantity", "seniority"]) {
      if (newUser[k])
        user[k] = newUser[k];
    }
  }

  delete(id) {
    let userIndex = this.accountants.findIndex(user => user.code === id);
    if (userIndex === -1)
      throw "Not found";
    this.accountants.splice(userIndex, 1);
  }

  getByPosition(position) {
    return this.accountants.filter(user => user.position.toLowerCase() === position.toLowerCase());
  }

  getByChildren(childrenQuantity) {
    return this.accountants.filter(user => Number(user.childrenQuantity) >= Number(childrenQuantity));
  }
}

const accountantsTable = document.getElementById('accountantsTable');//посилання на таблицю
const addAccountantForm = document.forms.addAccountantForm;//посилання на форму
const getByChildrenButton = document.getElementById('getByChildrenButton');
const getByPositionButton = document.getElementById('getByPositionButton');

const accountants = new Accountants();//новий об'єкт, який передає колекцію

function refreshAccountantsTable(accountantsList) {
  const tbody = accountantsTable.getElementsByTagName('tbody')[0];//посилання на елемент tbody
  tbody.innerHTML = '';

  for (const accountant of accountantsList) {
    const row = document.createElement('tr');//рядок
    const fullNameCell = document.createElement('td');//комірка для відображення
    fullNameCell.textContent = accountant.fullName;//заповнення
    row.appendChild(fullNameCell);// appendChild означає додавання елемента fullNameCell як дочірнього елемента до рядка 

    const positionCell = document.createElement('td');
    positionCell.textContent = accountant.position;
    row.appendChild(positionCell);

    const salaryCell = document.createElement('td');
    salaryCell.textContent = accountant.salary;
    row.appendChild(salaryCell);

    const childrenQuantityCell = document.createElement('td');
    childrenQuantityCell.textContent = accountant.childrenQuantity;
    row.appendChild(childrenQuantityCell);

    const seniorityCell = document.createElement('td');
    seniorityCell.textContent = accountant.seniority;
    row.appendChild(seniorityCell);

    const actionCell = document.createElement('td');
    const deleteButton = document.createElement('button');//створює новий елемент <button>.
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => {
      accountants.delete(accountant.code);//викликається метод delete об'єкта accountants для видалення бухгалтера з вказаним кодом.
      row.remove();
    });
    actionCell.appendChild(deleteButton);//додає кнопку видалення (deleteButton) в комірку "Action" (actionCell).
    row.appendChild(actionCell);//додає комірку "Action" (actionCell) до поточного рядка (row).

    tbody.appendChild(row);
  }
}

addAccountantForm.addEventListener('submit', (e) => {
  e.preventDefault();

  const fullName = addAccountantForm.fullName.value;
  const position = addAccountantForm.position.value;
  const salary = parseFloat(addAccountantForm.salary.value);
  const childrenQuantity = parseInt(addAccountantForm.childrenQuantity.value);
  const seniority = addAccountantForm.seniority.value;

  const newAccountant = new Accountant(fullName, position, salary, childrenQuantity, seniority);//створення нового об'єкту Accountant зі зчитаними значеннями полів форми

  accountants.add(newAccountant);//додавання нового об'єкту Accountant до списку облікових записів 

  refreshAccountantsTable(accountants.accountants);
  addAccountantForm.reset();//очищення для наступного введення
});

getByChildrenButton.addEventListener('click', () => {
  const childrenQuantity = document.getElementById('childrenQuantityFilter').value;//значення введеного поля
  const filteredAccountants = accountants.getByChildren(childrenQuantity);//виклик метода
  refreshAccountantsTable(filteredAccountants);
});

getByPositionButton.addEventListener('click', () => {
  const position = document.getElementById('positionFilter').value;
  const filteredAccountants = accountants.getByPosition(position);
  refreshAccountantsTable(filteredAccountants);
});

let firstUser = new Accountant("Новікова Руслана", "Студент", 0, 0, "1 курс");
let secondUser = new Accountant("Шимон Артем", "Перекладач", 0, 1, "1 клас");
accountants.add(firstUser);
accountants.add(secondUser);
refreshAccountantsTable(accountants.accountants);

